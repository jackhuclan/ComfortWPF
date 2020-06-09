using ComfortWPF.Event;
using System;

namespace ComfortWPF.Services
{
    /// <summary>
    /// This interface defines a UI controller which can be used to display dialogs
    /// in either modal or modaless form from a ViewModel.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// This method displays a modaless dialog associated with the given key.
        /// </summary>
        /// <param name="setOwner">Set the owner of the window</param>
        /// <param name="completedProc">Callback used when UI closes (may be null)</param>
        /// <returns>True/False if UI is displayed</returns>
        bool Show<TPopup>( bool setOwner, EventHandler<UICompletedEventArgs> completedProc);

        /// <summary>
        /// This method displays a modal dialog associated with the given key.
        /// </summary>
        /// <returns>True/False if UI is displayed.</returns>
        bool? ShowDialog<TPopup>();
    }
}
