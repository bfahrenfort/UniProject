using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UniProject.Models;
using UniProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComparePage : CarouselPage
    {
        public ComparePage(SchoolModel s1, SchoolModel s2)
        {
            BindingContext = new CompareViewModel(s1, s2);
            InitializeComponent();
        }
    }
}