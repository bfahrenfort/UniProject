using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UniProject.Annotations;
using UniProject.Models;
using UniProject.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UniProject.ViewModels
{
    public class InfoViewModel : INotifyPropertyChanged
    {
        private SchoolModel _school;
        public SchoolModel School
        {
            get => _school;
            set
            {
                _school = value;
                OnPropertyChanged(nameof(School));
            }
        }

        public InfoViewModel(SchoolModel s)
        {
            School = s;
        }
        
        // Properties for formatting components of the School to display
        public string SchoolNameFormatted => $"{_school.SchoolName}"; // For convenience, in accordance with MVVM
        public string SchoolAddressLabel => $"{_school.SchoolAddress}";
        public string SchoolUrlLabel => $"{_school.ApplicationURL}";
        public string CostLabel => _school.SemesterCost != -1
            ? $"Cost/semester: {Utilities.FormatCurrency(_school.SemesterCost)}"
            : "Cost/semester unavailable";
        public string ClassLabel => _school.StudentsPerFaculty != -1
            ? $"Students:Faculty: {_school.StudentsPerFaculty}:1"
            : "Students:Faculty unavailable";

        public string StatsLabel
        {
            get{
                Console.WriteLine(_school.AverageGPA + " " + _school.AverageSAT);
                return _school. AverageGPA > 0 && _school. AverageSAT != -1
                ? $"Avg. GPA/SAT: { _school. AverageGPA}/{ _school. AverageSAT}"
                :  "Avg. GPA/SAT unavailable";
                
            }
        }

        // Open the apply link
        public ICommand ApplyLinkCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}