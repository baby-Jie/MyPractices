using Ayx.AvalonDI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfSample.Infrastructure;
using WpfSample.Repository;
using WpfSample.ViewModels;
using WpfSample.Views;

namespace WpfSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AvalonContainer VM;

        public static AyxContainer Container;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            InitDependency();
            //显示主窗口
            VM.GetView<MainWindow>()?.Show();
        }

        private void InitDependency()
        {
            //依赖服务配置
            Container = new AyxContainer();
            Container.Wire<ITestDataRepo, TestDataRepo>();
            Container.WireSingleton<ILogger, SimpleLogger>();

            //使用自带的容器创建View和ViewModel的容器
            VM = new AvalonContainer(new DefaultContainer(Container));
            //View和ViewModel依赖配置
            VM.WireVM<MainWindow, MainWindowViewModel>();
            VM.WireVM<TestOneView, TestOneViewModel>();
        }
    }
}
