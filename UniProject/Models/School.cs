// This is an example of a Model, which will be used to store data by the program.

using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace UniProject.Models
{
    public class SchoolModel
    {
        // Some sample Properties, subject to change as database spec is created
        public string SchoolName { get; set; }

        public string SchoolAddress { get; set; }

        public string ApplicationURL { get; set; }

        public string SchoolAcronym { get; set; }

        // Kirby: Credit to Josh for fixing our binding issue due to auto-property tomfoolery and my incomplete knowledge of C#
        public SchoolModel(string n, string a, string u, string c)
        {
            SchoolName = n;
            SchoolAddress = a;
            ApplicationURL = u;
            SchoolAcronym = c;
        }
    }
}