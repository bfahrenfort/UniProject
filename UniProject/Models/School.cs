using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace UniProject.Models
{
    public class School
    {
        private string name;
        public string Name { get; set; }

        private string acronym;
        public string Acronym { get; set; }

        private double tuition;
        public double Tuition { get; set; }

        public School()
        {
            
        }
    }
}