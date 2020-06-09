using ComfortWPF.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.ReflectionModel;
using System.Linq;
using System.Reflection;

namespace ComfortWPF.Mvvm
{
    public static class BootStrapper
    {
        public static CompositionContainer Container { get; private set; }
        private static AggregateCatalog _aggregateCatalog = new AggregateCatalog();

        public static AggregateCatalog AddAssemblyCatalog(Type type)
        {
            _aggregateCatalog.AddAssemblyCatalog(type);
            return _aggregateCatalog;
        }

        public static void Initialize()
        {
            Container = new CompositionContainer(_aggregateCatalog);
            var assemblies = GetComposingAssemblies();
            ViewResolver.Instance.RegisterViews(assemblies);
            ViewModelResolver.Instance.RegisterViewModels(assemblies);
            Container.ComposeExportedValue<IViewResolver>(ViewResolver.Instance);
            Container.ComposeExportedValue<IViewModelResolver>(ViewModelResolver.Instance);
        }

        private static IEnumerable<Assembly> GetComposingAssemblies()
        {
            return _aggregateCatalog
                .Select(part => ReflectionModelServices.GetPartType(part).Value.Assembly)
                .Distinct()
                .ToList();
        }

        public static void Dispose()
        {
            _aggregateCatalog.Catalogs.Clear();
            Container.Dispose();
        }
    }
}
