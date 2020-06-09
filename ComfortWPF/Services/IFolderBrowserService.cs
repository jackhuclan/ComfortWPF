using System;

namespace ComfortWPF.Services
{
    public interface IFolderBrowserService
    {
        string SelectedPath { get; set; }
        bool ShowNewFolderButton { get; set; }
        Environment.SpecialFolder RootFolder { get; set; }
        bool ShowDialog();
    }


}