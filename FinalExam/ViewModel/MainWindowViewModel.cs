using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using FinalExam.Model;

namespace FinalExam.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        WorkList worklist = new WorkList();

        ObservableCollection<Work> works;

        public MainWindowViewModel()
        {
            _search = new RelayCommand(SearchExecute);
            _reset = new RelayCommand(ResetExecute);
            _modify = new RelayCommand(ModifyExecute);

            works = worklist.GetWorkList();

            Works = GetWorks();
        }

        ICommand _search;
        public ICommand Search
        {
            get { return _search; }
        }

        ICommand _reset;
        public ICommand Reset
        {
            get { return _reset; }
        }

        ICommand _modify;
        public ICommand Modify
        {
            get { return _modify; }
        }

        string _searchName = "";
        public string SearchName
        {
            get { return _searchName; }
            set
            {
                _searchName = value;
                OnPropertyChanged("SearchName");
            }
        }


        private Work _selectedWork;
        public Work SelectedWork
        {
            get { return _selectedWork; }
            set
            {
                _selectedWork = value;
                if (_selectedWork != null)
                    SelectedProgressRate = _selectedWork.ProgressRate;
                else
                    SelectedProgressRate = 0;
                OnPropertyChanged("SelectedWork");
            }
        }

        private int _selectedProgressRate;
        public int SelectedProgressRate
        {
            get { return _selectedProgressRate; }
            set
            {
                _selectedProgressRate = value;
                OnPropertyChanged("SelectedProgressRate");
            }
        }


        ObservableCollection<Work> _works;
        public ObservableCollection<Work> Works
        {
            get { return _works; }
            set
            {
                _works = value;
                OnPropertyChanged("Works");
            }
        }

        void SearchExecute()
        {
            Works = GetWorks(true);
        }

        void ResetExecute()
        {
            Works = GetWorks();
        }


        void ModifyExecute()
        {
            if (SelectedWork != null)
                SelectedWork.ProgressRate = SelectedProgressRate;
        }


        ObservableCollection<Work> GetWorks(bool search = false)
        {
            if (search == true)
            {
                var output = from item in works
                             where item.Manager == SearchName
                             select item;
                return new ObservableCollection<Work>(output);
            }

            return works;
        }
    }
}
