using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSample.Infrastructure;
using WpfSample.Models;
using WpfSample.MVVM;
using WpfSample.Repository;

namespace WpfSample.ViewModels
{
    public class TestOneViewModel:NotificationObject
    {
        private ITestDataRepo _repo;
        private ILogger _logger;


        public TestOneViewModel(ITestDataRepo repo, ILogger logger)
        {
            _repo = repo;
            _logger = logger;

            _logger?.ToConsole("Test view1 opened");
        }



        private TestData _SelectData;
        public TestData SelectedData
        {
            get { return _SelectData; }
            set
            {
                _SelectData = value;
                this.RaisePropertyChanged("SelectedData");
            }
        }



        private ObservableCollection<TestData> _DataList;
        public ObservableCollection<TestData> DataList
        {
            get { return _DataList; }
            set
            {
                _DataList = value;
                this.RaisePropertyChanged("DataList");
            }
        }

        #region Command


        private AyxCommand _CmdGet;
        public AyxCommand CmdGet
        {
            get
            {
                if (_CmdGet == null)
                    _CmdGet = new AyxCommand(
                    o =>
                    {
                        var data = _repo.Get(200);
                        DataList = new ObservableCollection<TestData>(data);
                        _logger?.ToConsole($"Get data count:{DataList.Count}");
                    });
                return _CmdGet;
            }
            set
            {
                _CmdGet = value;
                this.RaisePropertyChanged("CmdGet");
            }
        }


        

        private AyxCommand _CmdDelete;
        public AyxCommand CmdDelete
        {
            get
            {
                if (_CmdDelete == null)
                    _CmdDelete = new AyxCommand(
                    o =>
                    {
                        _repo.Delete(SelectedData);
                        var id = SelectedData.Id;
                        DataList.Remove(SelectedData);
                        _logger?.ToConsole($"Removed item id:{id}");
                    }, o => SelectedData != null);
                return _CmdDelete;
            }
            set
            {
                _CmdDelete = value;
                this.RaisePropertyChanged("CmdDelete");
            }
        }


        private AyxCommand _CmdUpdate;
        /// <summary>
        /// Gets the CmdUpdate.
        /// </summary>
        public AyxCommand CmdUpdate
        {
            get
            {
                if (_CmdUpdate == null)
                    _CmdUpdate = new AyxCommand(
                    o =>
                    {
                        _repo.Update(SelectedData);
                        _logger.ToConsole($"Update item id:{SelectedData.Id}");
                    }, o => SelectedData != null);
                return _CmdUpdate;
            }
        }



        #endregion
    }
}
