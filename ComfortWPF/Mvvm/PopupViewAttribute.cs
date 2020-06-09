using System;

namespace ComfortWPF.Mvvm
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PopupViewAttribute : Attribute
    {
        public Type ViewType { get; private set; }

        public PopupViewAttribute(Type viewType)
        {
            ViewType = viewType;
        }
    }
}
