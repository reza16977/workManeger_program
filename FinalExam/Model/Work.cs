using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalExam.ViewModel;

namespace FinalExam.Model
{
    enum WorkStatus
    {
        None, // 판단 불가
        Complete,   // 업무 완료
        EndPeriod,  // 기간이 종료됐지만 업무가 완료되지 않음
        NormalProgress, // 정상 진행
        SlowProgress, // 업무 진행 속도가 느림
    }

    class Work : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private string _startDate;
        public string StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                UpdateCurrentPeriod();
                UpdateStatus();
                OnPropertyChanged("StartDate");
            }
        }

        private string _endDate;
        public string EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                UpdateCurrentPeriod();
                UpdateStatus();
                OnPropertyChanged("EndDate");
            }
        }

        private string _manager;
        public string Manager
        {
            get { return _manager; }
            set
            {
                _manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private int _currentPeriodRate;
        public int CurrentPeriodRate
        {
            get { return _currentPeriodRate; }
            set
            {
                _currentPeriodRate = value;
                OnPropertyChanged("CurrentPeriodRate");
            }
        }

        private int _progressRate;
        public int ProgressRate
        {
            get { return _progressRate; }
            set
            {
                _progressRate = value;
                UpdateStatus();
                OnPropertyChanged("ProgressRate");
            }
        }

        private WorkStatus _status;
        public WorkStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private void UpdateCurrentPeriod()
        {
            if (StartDate != null && EndDate != null)
            {
                DateTime today = DateTime.Now;
                DateTime startDate = DateTime.ParseExact(StartDate, "yyyyMMdd", null);
                DateTime endDate = DateTime.ParseExact(EndDate, "yyyyMMdd", null);

                int entireDays = (endDate - startDate).Days;
                int currentDays = (today - startDate).Days;
                CurrentPeriodRate = (int)(((double)currentDays / (double)entireDays) * 100);
                if (CurrentPeriodRate > 100)
                    CurrentPeriodRate = 100;
                else if (CurrentPeriodRate < 0)
                    CurrentPeriodRate = 0;
            }
            else
            {
                CurrentPeriodRate = 0;
            }
        }

        private void UpdateStatus()
        {
            if (ProgressRate >= 100)
                Status = WorkStatus.Complete;
            else if (CurrentPeriodRate >= 0)
            {
                if (CurrentPeriodRate >= 100)
                    Status = WorkStatus.EndPeriod;
                else if (CurrentPeriodRate <= ProgressRate)
                    Status = WorkStatus.NormalProgress;
                else
                    Status = WorkStatus.SlowProgress;
            }
            else
                Status = WorkStatus.None;
        }
    }
}
