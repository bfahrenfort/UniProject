using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UniProject.Annotations;
using UniProject.Models;
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
        
        public string SchoolNameFormatted => $"{_school.SchoolName}"; // For convenience, in accordance with MVVM
        public string SchoolAddressLabel => $"{_school.SchoolAddress}";
        public string SchoolUrlLabel => $"{_school.ApplicationURL}";
        public ICommand ApplyLinkCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}