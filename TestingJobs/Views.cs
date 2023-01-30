using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TestingJobs.Models;

namespace TestingJobs
{
    public static class Views
    {
        public static ObservableCollection<Employee> ?EmployeeView { get; set; }
        public static ObservableCollection<Initiator> ?InitiatorView { get; set; }
        public static ObservableCollection<NameRequest>? NameRequestView { get; set; } 
        public static ObservableCollection<Post> ?PostView { get; set; }
        public static ObservableCollection<Priority> ?PriorityView { get; set; }
        public static ObservableCollection<Request> ?RequestView { get; set; } 
        public static ObservableCollection<Status> ?StatusView { get; set; }
        public static ObservableCollection<TypeRequest> ?TypeRequestView { get; set; }
    }
}
