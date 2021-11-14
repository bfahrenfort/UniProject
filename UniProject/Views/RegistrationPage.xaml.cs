using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private async void CreateAccountButtonClicked(object sender, EventArgs e)
        {
    
            //Checks if the user left any fields empty
            if (NewUsername.Text == null || NewEmail.Text == null || NewPassword.Text == null || NewPasswordConfirm.Text == null )
            {
                await DisplayAlert("Error", "Please fill out all fields.", "Ok");
            }

            //All fields were filled out
            else
            {
                
                var usernameExists = DbConn2.QueryScalar("SELECT Username FROM user WHERE Username = @1", NewUsername.Text);
                var emailExists = DbConn2.QueryScalar("SELECT Email FROM user WHERE Email = @1", NewEmail.Text);
                
                //Username already used.
                if (usernameExists != null) 
                {
                    bool answer = await DisplayAlert("Error!", "Username already exists. Do you already have an account?", "Yes", "No");
                    if (answer == true)
                    {
                        await Navigation.PopModalAsync(); 
                    }
                }
                
                //Email already used.
                else if (emailExists != null)
                {
                    bool answer = await DisplayAlert("Error!", "Email already exists. Do you already have an account?", "Yes", "No");
                    if (answer == true)
                    {
                        await Navigation.PopModalAsync(); 
                    }
                }
                
                //User's credentials don't exist in database.
                else
                {
                    //Passwords do not match.
                    if (NewPassword.Text != NewPasswordConfirm.Text)
                    {
                        await DisplayAlert("Error", "Passwords don't match. Please try again.", "Ok");
                    }
                    
                    //Account created successfully!
                    else 
                    {
                        DbConn2.Query("INSERT INTO user (Username, Password, Email) Values (@1, @2, @3)", NewUsername.Text, NewPassword.Text, NewEmail.Text);
                        await DisplayAlert("Congratulations!", "Account Successfully Created!", "Ok");
                        await Navigation.PopModalAsync(); 
                    }
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