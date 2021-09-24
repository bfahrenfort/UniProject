// This ViewModel provides a View with access to lists of the School model which it can use in ListViews etc.

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using UniProject.Annotations;
using UniProject.Models;
using UniProject.Utils;
using Xamarin.Forms;

namespace UniProject.ViewModels
{
    public class SchoolViewModel : INotifyPropertyChanged
    {
        private const string TextSearchQuery = "select * from Schools where SchoolName like '%@Search%'";

        // The list property, currently read-only because set has strange interactions with INotifyPropertyChanged on collections
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

        public ICommand Search => new Command<string>((query) =>
        {
            // Instantiate
            Schools = new ObservableCollection<School>();
            
            // Create a command
            var cmd = new MySqlCommand();
            cmd.CommandText = TextSearchQuery;
            cmd.Parameters.AddWithValue("@Search", query); // To mitigate the risk of SQL injection
            
            DbDataReader result;
            
            // Connect to database and execute command
            using (var dbConn = new MySqlConnection(Utilities.UniConnString))
            {
                dbConn.Open();
                cmd.Connection = dbConn;
                result = cmd.ExecuteReader();
                dbConn.Close();
            }

            // Populate the list
            while (result.Read())
            {
                Schools.Add(new School(result.GetString(0), result.GetString(1), result.GetDouble(2)));
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