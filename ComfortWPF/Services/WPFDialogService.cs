using System;
using System.Windows;
using System.ComponentModel.Composition;

namespace ComfortWPF.Services
{
    /// <summary>
    /// This class implements the IDialogService for WPF purposes.
    /// If you have attributed up your views using the PopupViewAttribute
    /// Registration of Views with the IDialogService service is automatic.
    /// </summary>
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IDialogService))]
    public class WPFDialogService : IDialogService
    {
        public WPFDialogService()
        {
        }

        /// <summary>
        /// This method displays a modaless dialog associated with the given key.
        /// </summary>
        /// <param name="setOwner">Set the owner of the window</param>
        /// <param name="completedProc">Callback used when UI closes (may be null)</param>
        /// <returns>True/False if UI is displayed</returns>
        public bool Show<TPopup>(bool setOwner, EventHandler<Event.UICompletedEventArgs> completedProc)
        {
            Window win = GetWindow<TPopup>(setOwner, completedProc, false);
            if (win != null)
            {
                win.Show();
                return true;
            }
            return false;
        }
        /// <summary>
        /// This method displays a modal dialog associated with the given key.
        /// </summary>
        /// <returns>True/False if UI is displayed.</returns>
        public bool? ShowDialog<TPopup>()
        {
            Window win = GetWindow<TPopup>(true, null, true);
            if (win != null)
                return win.ShowDialog();

            return false;
        }

        #region Private Methods
        /// <summary>
        /// This creates the WPF window from a key.
        /// </summary>
        /// <param name="setOwner">True/False to set ownership to MainWindow</param>
        /// <param name="completedProc">Callback</param>
        /// <param name="isModal">True if this is a ShowDialog request</param>
        /// <returns>Success code</returns>
        private Window GetWindow<TPopup>(bool setOwner, EventHandler<Event.UICompletedEventArgs> completedProc, bool isModal)
        {
            var win = Mvvm.ViewResolver.Instance.Resolve<TPopup>() as Window;
            if (win == null)
            {
                throw new Exception("Popup must be window!");
            }

            if (setOwner && !win.Equals(Application.Current.MainWindow))
                win.Owner = Application.Current.MainWindow;

            win.Closed += (s, e) =>
            {
                var dataContext = win.DataContext;
                win.DataContext = null;
                if (completedProc != null)
                {
                    completedProc(this, new Event.UICompletedEventArgs()
                    {
                        State = dataContext,
                        Result = isModal ? win.DialogResult : null
                    });
                }
            };

            return win;
        }
        #endregion
    }
}
