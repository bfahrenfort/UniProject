using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        //Button Action: Sends an email to the input email (if it exists) with a way to recover/reset their password.
        private void SendEmailButtonClicked(object sender, EventArgs e)
        {
            //Temporary until we can pass information to and from database
            //to validate if the user's credentials exist/is correct
            if (TextEmail.Text != "Gmail@gmail.com")
            {
                //Displays an error if the input email is doesn't exist in our database.
                DisplayAlert("Error", "The input email isn't linked to any account", "Ok");
            }
            else
            {
                //Displays a message saying an email was sent and returns them to the Login screen.
                DisplayAlert("Password Recovery", "An email has been sent to the input email" +
                                                " with instructions to recover your password.", "Ok");
                Navigation.PopAsync(); //Takes you back to the Login Page.
            }
        }
        
        //Button Action: Take them back to the Login Page.
        //I'm not sure whether or not to remove this because they could simply hit
        //the back button instead if they want to go back.
        private void CancelButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}