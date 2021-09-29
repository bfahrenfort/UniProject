// This ViewModel provides a View with access to lists of the School model which it can use in ListViews etc.

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UniProject.Models;
using UniProject.Utils;
using Xamarin.Forms;

using MySqlConnector;
using UniProject.Annotations;

namespace UniProject.ViewModels
{
    public class SchoolViewModel : INotifyPropertyChanged
    {
        private const string TextSearchQuery = "select * from School where SchoolName like @Search";

        private ObservableCollection<School> _schools;
        public ObservableCollection<School> Schools
        { 
            get => _schools;
            set
            {
                _schools = value;
                OnPropertyChanged(nameof(Schools));
            } 
        }

        public SchoolViewModel()
        {
            Schools = new ObservableCollection<School>();
        }
        
        public ICommand Search => new Command<string>((query) =>
        {
            // Create a command
            var cmd = new MySqlCommand();
            cmd.CommandText = TextSearchQuery;
            cmd.Parameters.AddWithValue("@Search", '%' + query + '%'); // To mitigate the risk of SQL injection
            
            MySqlDataReader result;
            
            // Connect to database and execute command
            using (var dbConn = new MySqlConnection(Utilities.UniConnString))
            {
                Schools = new ObservableCollection<School>();
                dbConn.Open();
                cmd.Connection = dbConn;
                result = cmd.ExecuteReader();

                // Populate the list
                while (result.Read())
                {
                    var school = new School(result.GetString(0),
                                               result.GetString(1),
                                               result.GetString(2),
                                               result.GetString(3));
                    Schools.Add(school);
                }
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}