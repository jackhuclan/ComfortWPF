﻿using System.Windows;
using Microsoft.Win32;
using System.ComponentModel.Composition;

namespace ComfortWPF.Services
{
    /// <summary>
    /// This class implements the IOpenFileService for WPF purposes.
    /// </summary>
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IOpenFileService))]
    public class WPFOpenFileService : IOpenFileService
    {
        #region Data

        /// <summary>
        /// Embedded OpenFileDialog to pass back correctly selected
        /// values to ViewModel
        /// </summary>
        private OpenFileDialog ofd = new OpenFileDialog();

        #endregion

        #region IOpenFileService Members
        /// <summary>
        /// This method should show a window that allows a file to be selected
        /// </summary>
        /// <param name="owner">The owner window of the dialog</param>
        /// <returns>A bool from the ShowDialog call</returns>
        public bool? ShowDialog(Window owner)
        {
            //Set embedded OpenFileDialog.Filter
            if (!string.IsNullOrEmpty(Filter))
                ofd.Filter = Filter;

            //Set embedded OpenFileDialog.InitialDirectory
            if (!string.IsNullOrEmpty(InitialDirectory))
                ofd.InitialDirectory = InitialDirectory;

            //return results
            return ofd.ShowDialog(owner);
        }

        /// <summary>
        /// FileName : Simply use embedded OpenFileDialog.FileName
        /// Also allow users to set new FileName, which sets OpenFileDialog.FileName
        /// </summary>
        public string FileName
        {
            get { return ofd.FileName; }
            set { ofd.FileName = value; }
        }

        /// <summary>
        /// Filter : Simply use embedded OpenFileDialog.Filter
        /// </summary>
        public string Filter
        {
            get { return ofd.Filter; }
            set { ofd.Filter = value; }
        }

        /// <summary>
        /// Filter : Simply use embedded OpenFileDialog.InitialDirectory
        /// </summary>
        public string InitialDirectory
        {
            get { return ofd.InitialDirectory; }
            set { ofd.InitialDirectory = value; }
        }

        #endregion
    }
}
