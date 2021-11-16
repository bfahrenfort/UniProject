using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            
            String username = NewUsername.Text;
            String email = NewEmail.Text;
            String password = NewPassword.Text;
            String cPassword = NewPasswordConfirm.Text;
            
            //Checks if the user left any fields empty.
            if (username == null || email == null || password == null || cPassword == null )
            {
                PasswordConfirmErrorLabel.TextColor = Color.Red;
                PasswordConfirmErrorLabel.Text = "Please fill out all fields";
                await DisplayAlert("Test!", "Password: " + password, "Thanks!");
            }
            
            //All fields are filled out.
            else
            {
                var usernameExists = DbConn2.QueryScalar("SELECT Username FROM user WHERE Username = @1", username);
                
                //Username already used.
                if (usernameExists != null) 
                {
                    UserErrorLabel.TextColor = Color.Red;
                    UserErrorLabel.Text = "Username already exists";
                }
                //Username can be used (but there are additional field errors).
                else
                {
                    UserErrorLabel.TextColor = Color.Green;
                    UserErrorLabel.Text = "Username is Valid";
                }
                
                //Email Input Validation Successful.
                if (RegexUtil.ValidEmailAddress().IsMatch(email))
                {
                    var emailExists = DbConn2.QueryScalar("SELECT Email FROM user WHERE Email = @1", email);
                 
                    //Let the user know the email is valid.
                    if (emailExists == null)
                    {
                        EmailErrorLabel.TextColor = Color.Green;
                        EmailErrorLabel.Text = "Email is Valid";
                    }
                    
                    //Let the user know the email is in use.
                    else
                    {
                        EmailErrorLabel.TextColor = Color.Red;
                        EmailErrorLabel.Text = "Email is already taken";
                    }
                }
            
                //Email Input Validation Unsuccessful.
                else
                {
                    EmailErrorLabel.TextColor = Color.Red;
                    EmailErrorLabel.Text = "Email is Invalid";
                }
                
                //Password Input Validation Successful.
                if (RegexUtil.ValidPassword().IsMatch(password)) 
                {
                    if (password != cPassword)
                    {
                        PasswordConfirmErrorLabel.TextColor = Color.Red;
                        PasswordConfirmErrorLabel.Text = "Passwords don't match";
                    }
                    else
                    {
                        PasswordConfirmErrorLabel.TextColor = Color.Green;
                        PasswordConfirmErrorLabel.Text = "Passwords Match";
                    }


                }
                //Password Input Validation Unsuccessful.
                else
                {
                    PasswordConfirmErrorLabel.TextColor = Color.Red;
                    PasswordConfirmErrorLabel.Text = "Password must contain: \nMinimum eight characters \nAt least one uppercase letter \nOne lowercase letter \nOne number (0 - 9) \nOne special character (@$!%*?&)";
                }

                if (UserErrorLabel.TextColor == Color.Green && EmailErrorLabel.TextColor == Color.Green &&
                    PasswordConfirmErrorLabel.TextColor == Color.Green)
                {
                    DbConn2.Query("INSERT INTO user (Username, Password, Email) Values (@1, @2, @3)", NewUsername.Text, NewPassword.Text, NewEmail.Text);
                    await Navigation.PopModalAsync();
                    await DisplayAlert("Congratulations!", "Account Successfully Created! We're glad we can be a part of your search for higher education!", "Thanks!");

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