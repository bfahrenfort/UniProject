using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniProject.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        
        //Prevents Android users from using the (hardware) back button.
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        
        //Button Action: Create the exist or return an error.
        //If account successfully created, take them to login page.
        private void CreateAccountButtonClicked(object sender, EventArgs e)
        {
            var usernameExists = DbConn2.QueryScalar("SELECT * FROM user WHERE Username = @1", NewUsername.Text);
            var emailExists = DbConn2.QueryScalar("SELECT * FROM user WHERE Email = @1", NewEmail.Text);
            if (usernameExists != null) // username already used
            {
                DisplayAlert("Error!", "Username already in use", "Ok");
            }
            else if (emailExists != null) // email already used
            {
                DisplayAlert("Error!", "Email already in use", "Ok");
            }
            else //passwords do not match
            {
                if (NewPassword.Text != NewPasswordConfirm.Text)
                {
                    DisplayAlert("Error", "Passwords don't match. Please try again.", "Ok");
                }
                else //account created successfully
                {
                    DbConn2.Query("INSERT INTO user (Username, Password, Email) Values (@1, @2, @3)", NewUsername.Text, NewPassword.Text, NewEmail.Text);
                    DisplayAlert("Account Creation", "Account Successfully Created!", "Ok");
                    Navigation.PopModalAsync(); 
                }
            }
        }

        //Button Action: If the account already exists, take them to login page.
        private void ExistingAccountButtonTapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(); 
        }
    }
}