using System;

namespace ComfortWPF.Mvvm
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PartialViewAttribute: Attribute
    {
        public Type ViewType { get; private set; }

        public PartialViewAttribute( Type viewType)
        {
            ViewType = viewType;
        }
    }
}
