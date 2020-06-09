using System;
using System.Windows;


namespace ComfortWPF.Services
{
    /// <summary>
    /// This interface defines a interface that will allow 
    /// a ViewModel to save a file
    /// </summary>
    public interface ISaveFileService
    {
        /// <summary>
        /// FileName
        /// </summary>
        bool OverwritePrompt { get; set; }

        /// <summary>
        /// FileName
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Filter
        /// </summary>
        string Filter { get; set; }

        /// <summary>
        /// Filter
        /// </summary>
        string InitialDirectory { get; set; }

        /// <summary>
        /// This method should show a window that allows a file to be saved
        /// </summary>
        /// <param name="owner">The owner window of the dialog</param>
        /// <returns>A bool from the ShowDialog call</returns>
        bool? ShowDialog(Window owner);
    }
}
