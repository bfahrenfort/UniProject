using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UniProject.Models;
using UniProject.Utils;
using Xamarin.Forms;
using UniProject.Annotations;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System;

//View Model Displaying list of different buildings on campus

namespace UniProject.ViewModels
{
    public class BuildingViewModel: INotifyPropertyChanged
    {
        public InfoViewModel InfoVm { get; set; }
        
        private ObservableCollection<BuildingModel> _buildings;
        public ObservableCollection<BuildingModel> Buildings
        { 
            get => _buildings;
            set
            {
                _buildings = value;
                OnPropertyChanged(nameof(Buildings));
            } 
        }

        public BuildingModel Selected { get; set; } // The building in Buildings currently selected
        
        public BuildingViewModel(SchoolModel s)
        {
            InfoVm = new InfoViewModel(s);
            //returns from database buildings from selected school
            //query API to return schools based on a string in the search
            try
            {
                Buildings = (ObservableCollection<BuildingModel>)JsonConvert.DeserializeObject(APIConn.Request("api/Buildings?name=" + InfoVm.School.SchoolName), typeof(ObservableCollection<BuildingModel>));
            }
            catch (Exception) { throw; }
        }

        public SchoolModel SchoolFromVm => InfoVm.School;

        // Required definitions to update the view
        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
