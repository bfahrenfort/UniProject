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
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }
        
        //Prevents Android users from using the (hardware) back button.
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        
        //Button Action: Sends an email to the input email (if it exists) with a way to recover/reset their password.
        private void SendEmailButtonClicked(object sender, EventArgs e)
        {
            String email = TextEmail.Text;

            var emailExists = DbConn2.QueryScalar("SELECT Email FROM user WHERE Email = @1", email);

            //Checks if the user left any fields empty.
            if (string.IsNullOrEmpty(email))
            {
                EmailErrorLabel.TextColor = Color.Red;
                EmailErrorLabel.Text = "Please don't leave the field blank";
            }
            //Email Doesn't Exist
            else if (emailExists == null)
            {
                //Displays an error if the input email is doesn't exist in our database.
                //DisplayAlert("Error", "The input email isn't linked to any account", "Ok");
                EmailErrorLabel.TextColor = Color.Red;
                EmailErrorLabel.Text = "The input email isn't linked to any account";
            }
            //Email does exist, send email recovery email.
            else
            {
                //Displays a message saying an email was sent and returns them to the Login screen.
                DisplayAlert("Password Recovery", "An email has been sent with instructions to recover your password.", "Ok");
                Navigation.PopModalAsync();
            }
        }
        
        //Button Action: Take them back to the Login Page.
        private void CancelButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}