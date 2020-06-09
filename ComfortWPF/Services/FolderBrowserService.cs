using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace ComfortWPF.Services
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IFolderBrowserService))]
    public class FolderBrowserService : IFolderBrowserService
    {
        public string SelectedPath { get; set; }
        public bool ShowNewFolderButton { get; set; }
        public Environment.SpecialFolder RootFolder { get; set; }
        private readonly FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();

        public bool ShowDialog()
        {
            _folderBrowserDialog.RootFolder = RootFolder;
            _folderBrowserDialog.ShowNewFolderButton = ShowNewFolderButton;
            if (_folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = _folderBrowserDialog.SelectedPath;
                return true;
            }

            return false;
        }
    }
}