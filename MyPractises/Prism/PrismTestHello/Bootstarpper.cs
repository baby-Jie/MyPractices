using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using System.Windows;
using Microsoft.Practices.Unity;

namespace PrismTestHello
{
    class Bootstarpper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //Shell shell = new PrismTestHello.Shell();
            //shell.Show();
           // return shell;
             return this.Container.Resolve<Shell>();
        }


        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(HelloWorldModule.HelloWorldModule));
        }
    }
}
