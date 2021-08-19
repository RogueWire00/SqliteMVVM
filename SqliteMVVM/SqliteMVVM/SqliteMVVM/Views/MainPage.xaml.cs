using SqliteMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SqliteMVVM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btn_crear_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarEmpleado());
        }
        private async void btn_listado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerEmpleado());
        }

        private async void btn_editar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarEmpleado());
        }
    }
}
