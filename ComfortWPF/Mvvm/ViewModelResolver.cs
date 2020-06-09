using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace ComfortWPF.Mvvm
{
    public class ViewModelResolver : IViewModelResolver
    {
        private static readonly Dictionary<Type, object> _registeredInstances = new Dictionary<Type, object>();
        private static bool? _isInDesignMode;
        private static ViewModelResolver viewModelResolver;

        private static bool IsInDesignMode
        {
            get
            {
                if (!_isInDesignMode.HasValue)
                {
                    var prop = DesignerProperties.IsInDesignModeProperty;
                    _isInDesignMode = (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
                }

                return _isInDesignMode.Value;
            }
        }

        public static ViewModelResolver Instance
        {
            get
            {
                if (viewModelResolver == null)
                {
                    viewModelResolver = new ViewModelResolver();
                }
                return viewModelResolver;
            }
        }

        public T Resolve<T>()
        {
            lock (_registeredInstances)
            {
                if (_registeredInstances.ContainsKey(typeof(T)))
                {
                    return (T)_registeredInstances[typeof(T)];
                }
            }
            return default(T);
        }

        internal void AttachViewModelToView(string viewModelTypeFullName, FrameworkElement containerElement, CreationPolicy policy)
        {
            var export = GetExportByContract(viewModelTypeFullName, policy);
            if (!IsInDesignMode) // if at runtime
            {
                DependencyPropertyChangedEventHandler handler = null;
                handler = delegate
                {
                    if (containerElement.DataContext != null) // it means we have the VM instance now we should inject the services
                    {
                        var data = containerElement.DataContext.GetType().GetCustomAttributes(typeof(InjectedViewModelAttribute), true).FirstOrDefault();

                        if (data == null)
                            return;

                        SatisfyImports(containerElement.DataContext, containerElement);
                    }
                };

                containerElement.DataContextChanged -= handler;
                if (containerElement.DataContext == null)
                    containerElement.DataContextChanged += handler; // we need to wait until the context is set
                else // DataContext is already set 
                {
                    handler(null, default(DependencyPropertyChangedEventArgs));
                }

                CreateViewModel(export, containerElement);
            }


            if (IsInDesignMode)
            {
                CreateViewModel(export, containerElement); // this will create the VM and set it as DataContext
            }
        }

        private ViewModelResolver()
        {
        }

        internal void RegisterViewModels(IEnumerable<Assembly> assembliesToExamine)
        {
            try
            {
                _registeredInstances.Clear();
                foreach (Assembly ass in assembliesToExamine)
                {
                    foreach (Type type in ass.GetTypes())
                    {
                        foreach (var attrib in type.GetCustomAttributes(typeof(InjectedViewModelAttribute), true))
                        {
                            InjectedViewModelAttribute viewMetadataAtt = (InjectedViewModelAttribute)attrib;
                            lock (_registeredInstances)
                            {
                                _registeredInstances.Add(viewMetadataAtt.ContractType, null);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ViewResolver is unable to ResolveViewLookups based on current parameters", ex);
            }
        }

        private Export GetExportByContract(string contractName, CreationPolicy policy)
        {
            if (BootStrapper.Container == null)
                return null;

            var type = GetViewModelTypeByItsFullName(contractName);
            if (type == null)
            {
                return null;
            }

            var viewModelTypeIdentity = AttributedModelServices.GetTypeIdentity(type);
            var definition = new ContractBasedImportDefinition(contractName, viewModelTypeIdentity,
                                                               null, ImportCardinality.ExactlyOne, false,
                                                               false, policy);

            var vmExports = BootStrapper.Container.GetExports(definition);

            var vmExport = vmExports.FirstOrDefault();
            if (vmExport != null)
                return vmExport;
            return null;
        }

        private static Type GetViewModelTypeByItsFullName(string contractName)
        {
            return _registeredInstances.Keys.FirstOrDefault(x => x.FullName == contractName);
        }

        private void SatisfyImports(object attributedPart, object contextToInject)
        {
            BootStrapper.Container.SatisfyImportsOnce(attributedPart);
        }

        private void CreateViewModel(Export viewModelExport, FrameworkElement containerElement)
        {
            var vm = viewModelExport.Value;
            if (vm == null)
                throw new InvalidOperationException(CannotFindViewModel);

            containerElement.DataContext = vm;
            RefreshCache(viewModelExport.Definition.ContractName, vm);
            RegisterEvents(containerElement, vm);
        }

        private static void RegisterEvents(FrameworkElement containerElement, object vm)
        {
            var viewModel = vm as ViewModelBase;
            var win = containerElement as Window;
            if (viewModel != null && win != null)
            {
                viewModel.CloseRequest += (s, e) =>
                {
                    try
                    {
                        win.DialogResult = e.Result;
                    }
                    catch (InvalidOperationException)
                    {
                        win.Close();
                    }
                };
            }
        }

        private static void RefreshCache(string contractName, object vm)
        {
            var type = GetViewModelTypeByItsFullName(contractName);
            if (_registeredInstances.ContainsKey(type))
            {
                _registeredInstances.Remove(type);
            }
            _registeredInstances.Add(type, vm);
        }

        protected const string CannotFindViewModel = "Cannot get ViewModel. Please check that you applied the ExportViewModel attribute and that the ViewModel inherits from BaseViewModel";
    }
}
