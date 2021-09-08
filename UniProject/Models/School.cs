// This is an example of a Model, which will be used to store data by the program.

using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace UniProject.Models
{
    public class School
    {
        // Some sample fields, subject to change as database spec is created
        private string name;
        public string Name { get; set; }

        private string acronym;
        public string Acronym { get; set; }

        private double tuition;
        public double Tuition { get; set; }

        public School()
        {
            // TODO: Add constructor
        }
    }
}