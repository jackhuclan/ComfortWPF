# ComfortWPF
ComfortWPF is simple Framework for WPF to use MVVM, make WPF application testable, maintainable...

##### What can ComfortWPF  do?

1. ComfortWPF  use a container to manage all instances automatically,  and provide instance to you at any time. 
2. ComfortWPF  contains some common services, and inject automatically, so just use it.
3. DIP principle, all services can be injected by its interface
4. Since all instances are injected via its interface, so they are low-couple and testable.
5. Make it easier to implement SRP principle.
6. Focus Your business only.
7. Only one dll is all, don't depend on any third-party libraries.
8. Not complicated as Prism, etc. Just make you comfortable... 



##### How to use ComfortWPF ?

- how to make ComfortWPF work

  - Install ComfortWPF via nuget

    ```powershell
    Install-Package ComfortWPF -Version 1.0.1
    ```

  - Invoke BootStrapper to register assemblies, then initialize 

  ```c#
   public partial class App : Application
      {
          protected override void OnStartup(StartupEventArgs e)
          {
              base.OnStartup(e);
              BootStrapper.AddAssemblyCatalog(this.GetType())
                          .AddAssemblyCatalog(typeof(BootStrapper));
              BootStrapper.Initialize();
          }
      }
  ```

  

- how to inject a view model to view automatically.

  - xmlns:mvvm="clr-namespace:ComfortWPF.Mvvm;assembly=ComfortWPF"
  - mvvm:ViewModelLocator.ViewModel="ComfortWPF.Demo.ViewModels.UserControl1ViewModel"

  ```xaml
  <UserControl x:Class="ComfortWPF.Demo.UserControl1"
               xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
               xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
               xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
               xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
               xmlns:local="clr-namespace:ComfortWPF.Demo"
               xmlns:mvvm="clr-namespace:ComfortWPF.Mvvm;assembly=ComfortWPF"
               mc:Ignorable="d" 
               d:DesignHeight="450" d:DesignWidth="800"
               mvvm:ViewModelLocator.ViewModel="ComfortWPF.Demo.ViewModels.UserControl1ViewModel">
      <Grid>
          <TextBlock Text="UserControl"/>
      </Grid>
  </UserControl>
  
  ```

  

- how to inject a service to view model automatically

  - all services and all instances are dominates in container, and will be injected view models automatically,

    ```c#
    [ImportingConstructor]
	public MainWindowViewModel(IFileOperator fileOperator, IViewModelResolver viewModelResolver, IViewResolver viewResolver)
	{
		this.fileOperator = fileOperator;
		this.viewModelResolver = viewModelResolver;
		this.viewResolver = viewResolver;
	}
    ```

    

- how to get arbitrary view

  - add PartialView Attribute to user control or add PopupView attribute to dialog 

    ```c#
    [PartialView(typeof(UserControl1))]
        public partial class UserControl1 : UserControl
        {
          public UserControl1()
            {
                InitializeComponent();
            }
        }
    
     [PopupView(typeof(PopupWindow))]
        public partial class PopupWindow : Window
        {
            public PopupWindow()
            {
                InitializeComponent();
            }
        }
    ```
    
    
    
  - after IViewResolver is injected, we can get any view.

    ```c#
     var popupWindow = viewResolver.Resolve<PopupWindow>();
     popupWindow.ShowDialog();
    ```

    

- how to get arbitrary view model

  - Injected view model to a class, make it as a view model

    ```c#
    [InjectedViewModel(typeof(PopupWindowViewModel))]
        public class PopupWindowViewModel : ViewModelBase
      {
            [ImportingConstructor]
            public PopupWindowViewModel()
            {
                
            }
        }
    ```
    
    
    
  - after IViewModelResolver is injected and its view is created, we can get view model of this view.

    ```c#
    var viewModel = viewModelResolver.Resolve<UserControl1ViewModel>();
    ```

    

- how to transfer data between view models

  - a typical way to do this is injecting IMessageChannel which is a Message bus once ComfortWPF is initialized. You can inject it by constructor injection or setter injection.

    ```C#
    [ImportingConstructor]
	public MainWindowViewModel(IMessageChannel  messageChannel)
	{
		this.messageChannel = messageChannel;
	}
    ```

  - another easier way to do this is setting a public property to target view model, then give value to this view model.

  

