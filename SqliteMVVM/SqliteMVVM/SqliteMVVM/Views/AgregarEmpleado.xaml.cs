using SqliteMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarEmpleado : ContentPage
    {
        public AgregarEmpleado()
        {
            InitializeComponent();
            this.BindingContext = new AgregarEmpleadoViewModel();
            btnnuevo.Clicked += Btnnuevo_Clicked;
            btnver.Clicked += Btnver_Clicked;
        }

        private void Btnnuevo_Clicked(object sender, EventArgs e)
        {
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtedad.Text = "";
            txtdireccion.Text = "";
            txtpuesto.Text = "";
        }

        private void Btnver_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new VerEmpleado());
        }
    }
}
