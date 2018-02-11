using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSample.Infrastructure;
using WpfSample.MVVM;
using WpfSample.Views;

namespace WpfSample.ViewModels
{
    class MainWindowViewModel : NotificationObject
    {
        public ILogger Logger { get; set; }

        public MainWindowViewModel(ILogger logger)
        {
            Logger = logger;
            Logger?.ToConsole("MainWindow View opened");
        }




        #region Command
        private AyxCommand cmdOpenTest1;
        public AyxCommand CmdOpenTest1
        {
            get
            {
                if (null == cmdOpenTest1)
                    cmdOpenTest1 = new AyxCommand(OpenTest1);
                return cmdOpenTest1;
            }
            set
            {
                cmdOpenTest1 = value;
                this.RaisePropertyChanged("CmdOpenTest1");
            }
        }

        void OpenTest1(object o)
        {

            Logger?.ToConsole("Try to open test1 view!");

            //获取View，设置了ViewModel并注入了ViewModel的依赖
            App.VM.GetView<TestOneView>()?.ShowDialog();

            Logger?.ToConsole("Test1 view closed!");

        }


        private AyxCommand cmdOpenTest2;
        public AyxCommand CmdOpenTest2
        {
            get
            {
                if (null == cmdOpenTest2)
                    cmdOpenTest2 = new AyxCommand(OpenTest2);
                return cmdOpenTest2;
            }
            set
            {
                cmdOpenTest2 = value;
                this.RaisePropertyChanged("CmdOpenTest2");
            }
        }

        void OpenTest2(object o)
        {
            Logger?.ToConsole("Open test2 view!");
        }

        private AyxCommand clrLog;
        public AyxCommand ClearLog
        {
            get
            {
                if (null == clrLog)
                    clrLog = new AyxCommand(ClearLogList);
                return clrLog;
            }
            set
            {
                clrLog = value;
                this.RaisePropertyChanged("ClearLog");
            }
        }

        void ClearLogList(object o)
        {
            Logger?.ClearList();
        }
        #endregion

    }
}
