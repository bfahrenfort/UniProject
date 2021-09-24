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
            name = "";
            acronym = "";
            tuition = 0.0;
        }

        public School(string n, string a, double t)
        {
            name = n;
            acronym = a;
            tuition = t;
        }
    }
}