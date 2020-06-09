# ComfortWPF
ComfortWPF is simple Framework for WPF to use MVVM, make WPF application testable, maintainable...

- how to make ComfortWPF work

  - Install ComfortWPF via nuget

    ```powershell
    Install-Package ComfortWPF
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

  

- how to 

