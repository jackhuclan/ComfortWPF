using ComfortWPF.Services;
using System.ComponentModel.Composition;

namespace ComfortWPF.Tests
{
    public class SetterInjection
    {
        [Import]
        public IDialogService DialogService { get; set; }
    }
}
