// This is an example of a Model, which will be used to store data by the program.

using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace UniProject.Models
{
    public class School
    {
        // Some sample fields, subject to change as database spec is created
        private string _schoolName;
        public string SchoolName { get; set; }

        private string _schoolAddress;
        public string SchoolAddress { get; set; }

        private string _applicationURL;
        public string ApplicationURL { get; set; }
        
        private string _schoolAcronym;
        public string SchoolAcronym { get; set; }

        public School(string n, string a, string u, string c)
        {
            SchoolName = n;
            _schoolAddress = a;
            _applicationURL = u;
            _schoolAcronym = c;
        }
    }
}