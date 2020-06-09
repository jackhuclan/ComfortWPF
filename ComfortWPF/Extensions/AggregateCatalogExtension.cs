using System;
using System.ComponentModel.Composition.Hosting;

namespace ComfortWPF.Extensions
{
    public static class AggregateCatalogExtension
    {
        public static AggregateCatalog AddAssemblyCatalog(this AggregateCatalog baseCatalog, Type TContainedType)
        {
            baseCatalog.Catalogs.Add(new AssemblyCatalog(TContainedType.Assembly));
            return baseCatalog;
        }

        public static AggregateCatalog AddAssemblyCatalog<TContainedType>(this AggregateCatalog baseCatalog)
        {
            baseCatalog.Catalogs.Add(new AssemblyCatalog(typeof(TContainedType).Assembly));
            return baseCatalog;
        }
    }
}
