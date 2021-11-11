using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace UniProject.Models
{
    // Class to store a single school's data from the database
    public class SchoolModel
    {
        public string SchoolName { get; set; }

        public string SchoolAddress { get; set; }

        public string ApplicationURL { get; set; }

        public string SchoolAcronym { get; set; }

        // Brandon: Credit to Josh for fixing our binding issue due to auto-property tomfoolery and my incomplete knowledge of C#
        public SchoolModel(string n, string a, string u, string c)
        {
            SchoolName = n;
            SchoolAddress = a;
            ApplicationURL = u;
            SchoolAcronym = c;
        }
    }
}
