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

//View Model Displaying where to enter username and password for account login/sign-up.

namespace UniProject.ViewModels
{
    public class UserViewModel: INotifyPropertyChanged
    {
        private UserModel user;

        

        public UserViewModel(UserModel u)
        {
            //Not needed yet;i
            //DataTable test2 = DbConn.query("select * from building where Username = @1", u.Username);
        }
   
        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}