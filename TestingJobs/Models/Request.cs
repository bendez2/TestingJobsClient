using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestingJobs.Models
{
    public class Request : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private DateTime _dateCreate { get; set; }
        public DateTime DateCreate
        {
            get { return _dateCreate; }
            set
            {
                _dateCreate = value;
                OnPropertyChanged("DateCreate");
            }
        }
        private int _typeId { get; set; }
        public int TypeId
        {
            get { return _typeId; }
            set
            {
                _typeId = value;
                OnPropertyChanged("TypeId");
            }
        }
        public TypeRequest Type { get; set; }

        private string _text { get; set; }
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }
        private string _location { get; set; }
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        private DateTime exucationTime { get; set; }
        public DateTime ExucationTime
        {
            get { return exucationTime; }
            set
            {
                exucationTime = value;
                OnPropertyChanged("ExucationTime");
            }
        }

        private int _statusId { get; set; }
        public int StatusId
        {
            get { return _statusId; }
            set
            {
                _statusId = value;
                OnPropertyChanged("StatusId");
            }
        }
        public Status Status { get; set; }

        private DateTime _changeTime { get; set; }
        public DateTime ChangeTime
        {
            get { return _changeTime; }
            set
            {
                _changeTime = value;
                OnPropertyChanged("ChangeTime");
            }
        }

        private string _comment { get; set; }
        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                OnPropertyChanged("Comment");
            }
        }

        private DateTime? _closeTime { get; set; }
        public DateTime? CloseTime
        {
            get { return _closeTime; }
            set
            {
                _closeTime = value;
                OnPropertyChanged("CloseTime");
            }
        }

        private int _initiatorId { get; set; }
        public int InitiatorId
        {
            get { return _initiatorId; }
            set
            {
                _initiatorId = value;
                OnPropertyChanged("InitiatorId");
            }
        }
        public Initiator Initiator { get; set; }

        private string _historyExecutor { get; set; }
        public string HistoryExecutor
        {
            get { return _historyExecutor; }
            set
            {
                _historyExecutor = value;
                OnPropertyChanged("HistoryExecutor");
            }
        }

        private DateTime? _startDateTime { get; set; }
        public DateTime? StartDateTime
        {
            get { return _startDateTime; }
            set
            {
                _startDateTime = value;
                OnPropertyChanged("StartDateTime");
            }
        }

        private int? _employeeId { get; set; }
        public int? EmployeeId
        {
            get { return _employeeId; }
            set
            {
                _employeeId = value;
                OnPropertyChanged("EmployeeId");
            }
        }
        public Employee? Employee { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
