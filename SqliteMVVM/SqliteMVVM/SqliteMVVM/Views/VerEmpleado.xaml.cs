using SQLite;
using SqliteMVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqliteMVVM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerEmpleado : ContentPage
    {
       
        public VerEmpleado()
        {
            InitializeComponent();

            this.BindingContext = new VerEmpleadoViewModel();
        }
    }
}