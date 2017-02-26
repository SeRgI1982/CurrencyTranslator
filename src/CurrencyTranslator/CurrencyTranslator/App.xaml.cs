using System;
using System.Diagnostics;
using System.Windows;

namespace CurrencyTranslator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                var bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                Trace.Write(ex);
                throw;
            }

            base.OnStartup(e);
        }
    }
}
