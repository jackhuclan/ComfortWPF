using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace ComfortWPF.Mvvm
{
    public class ViewResolver : IViewResolver
    {
        private static readonly Dictionary<Type, object> _registeredViewInstances = new Dictionary<Type, object>();
        private static ViewResolver viewResolver;

        public static ViewResolver Instance
        {
            get
            {
                if (viewResolver == null)
                {
                    viewResolver = new ViewResolver();
                }
                return viewResolver;
            }
        }

        public T Resolve<T>()
        {
            var instance = Resolve(typeof(T));
            return instance == null ? default(T) : (T)instance;
        }

        public DependencyObject Resolve(string viewName)
        {
            var type = GetViewTypeByItsFullName(viewName);
            var instance = Resolve(type);
            return instance == null ? null : (DependencyObject)instance;
        }

        internal void RegisterViews(IEnumerable<Assembly> assembliesToExamine)
        {
            try
            {
                _registeredViewInstances.Clear();
                foreach (Assembly ass in assembliesToExamine)
                {
                    foreach (Type type in ass.GetTypes())
                    {
                        RegisterPartialView(type);
                        RegisterPopupView(type);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("ViewResolver is unable to ResolveViewLookups based on current parameters", ex);
            }
        }

        private static void RegisterPopupView(Type type)
        {
            foreach (var attrib in type.GetCustomAttributes(typeof(PopupViewAttribute), true))
            {
                PopupViewAttribute viewMetadataAtt = (PopupViewAttribute)attrib;
                lock (_registeredViewInstances)
                {
                    _registeredViewInstances.Add(viewMetadataAtt.ViewType, null);
                }
            }
        }

        private static void RegisterPartialView(Type type)
        {
            foreach (var attrib in type.GetCustomAttributes(typeof(PartialViewAttribute), true))
            {
                PartialViewAttribute viewMetadataAtt = (PartialViewAttribute)attrib;
                lock (_registeredViewInstances)
                {
                    _registeredViewInstances.Add(viewMetadataAtt.ViewType, null);
                }
            }
        }

        private static object Resolve(Type t)
        {
            lock (_registeredViewInstances)
            {
                if (_registeredViewInstances.ContainsKey(t))
                {
                    _registeredViewInstances.Remove(t);
                    var instance = Activator.CreateInstance(t);
                    _registeredViewInstances.Add(t, instance);
                    return instance;
                }
            }

            return null;
        }

        private static Type GetViewTypeByItsFullName(string contractName)
        {
            return _registeredViewInstances.Keys.FirstOrDefault(x => x.FullName == contractName);
        }
    }
}
