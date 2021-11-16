using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniProject.Annotations;
using UniProject.Models;

namespace UniProject.ViewModels
{
    public class CompareViewModel : INotifyPropertyChanged
    {
        public InfoViewModel S1 { get; set; }
        public InfoViewModel S2 { get; set; }
        private SchoolModel _school1;
        public SchoolModel School1
        {
            get => _school1;
            set 
            {
                _school1 = value; 
                OnPropertyChanged(nameof(School1));
            }
        }
        private SchoolModel _school2;
        public SchoolModel School2
        {
            get => _school2;
            set 
            {
                _school2 = value; 
                OnPropertyChanged(nameof(School2));
            }
        }

        public CompareViewModel(SchoolModel s1, SchoolModel s2)
        {
            School1 = s1;
            School2 = s2;
            S1 = new InfoViewModel(School1);
            S2 = new InfoViewModel(School2);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}