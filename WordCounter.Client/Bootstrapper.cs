using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Unity;
using WordCounter.Client.Core;

namespace WordCounter.Client
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            RegisterTypeIfMissing(typeof(ICount), typeof(StringCounter), true);
        }
    }
}
