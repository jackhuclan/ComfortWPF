using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Windows;

namespace ComfortWPF.Mvvm
{
    public class ViewModelLocator
    {
        /// <summary>
        /// ViewModel Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.RegisterAttached("ViewModel", typeof(string), typeof(ViewModelLocator),
                new PropertyMetadata((string)String.Empty,
                    new PropertyChangedCallback(OnViewModelChanged)));

        /// <summary>
        /// Gets the ViewModel property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static string GetViewModel(DependencyObject d)
        {
            return (string)d.GetValue(ViewModelProperty);
        }

        /// <summary>
        /// Sets the ViewModel property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetViewModel(DependencyObject d, string value)
        {
            d.SetValue(ViewModelProperty, value);
        }

        /// <summary>
        /// Handles changes to the ViewModel property.
        /// </summary>
        private static void OnViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string vmContractName = (string)e.NewValue;
            var element = d as FrameworkElement;
            AttachViewModel(element, vmContractName, CreationPolicy.Any);
        }

        private static void AttachViewModel(FrameworkElement element, string vmContractName, CreationPolicy policy)
        {
            if (element == null)
                throw new ArgumentException(InvalidElementForAttachedProperty);

            try
            {
                if (!string.IsNullOrEmpty(vmContractName))
                {
                    ViewModelResolver.Instance.AttachViewModelToView(vmContractName, element, policy);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error while resolving ViewModel. " + ex);
            }
        }

        const string InvalidElementForAttachedProperty = "ViewModelLocator attached properties need to be assigned to a FrameworkElement";
    }
}
