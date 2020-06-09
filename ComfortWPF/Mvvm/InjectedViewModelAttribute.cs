using System;
using System.ComponentModel.Composition;

namespace ComfortWPF.Mvvm
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectedViewModelAttribute : ExportAttribute
    {
        public CreationPolicy CreationPolicy { get; private set; }
        public InjectedViewModelAttribute(Type contractType) : base(contractType.FullName, contractType)
        {
            CreationPolicy = CreationPolicy.Any;
        }

        public InjectedViewModelAttribute(Type contractType, CreationPolicy creationPolicy) : base(contractType.FullName, contractType)
        {
            CreationPolicy = creationPolicy;
        }
    }
}
