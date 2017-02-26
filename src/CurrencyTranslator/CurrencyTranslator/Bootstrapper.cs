using System.Windows;
using CurrencyTranslator.ServiceLayer;
using CurrencyTranslator.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace CurrencyTranslator
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RegisterTypes();
        }

        private void RegisterTypes()
        {
            Container.RegisterType<ICurrencyService>(new InjectionFactory(x => new CurrencyServiceClient()));
        }

        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }
    }
}
