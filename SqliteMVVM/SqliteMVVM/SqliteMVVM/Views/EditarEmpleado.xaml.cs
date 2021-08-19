using SQLite;
using SqliteMVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarEmpleado : ContentPage
    {
        private Entry _nombre;
        private Entry _apellido;
        private Entry _edad;
        private Entry _direccion;
        private Entry _id;
        private Entry _puesto;

        private Button _guardar;
        private Button _eliminar;

        String _db = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbempleados.db3");
        public EditarEmpleado()
        {
            InitializeComponent();
           
            var conexion = new SQLiteConnection(_db);

            listado.ItemsSource= conexion.Table<Empleados>().OrderBy(x => x.Nombre).ToList();
            listado.ItemSelected += ListaEditar_ItemSelected;
            contenido.Children.Add(listado);

            _id = new Entry();
            _id.Placeholder = "ID";
            _id.IsVisible = false;
            contenido.Children.Add(_id);

            //Nombre
            _nombre = new Entry();
            _nombre.Keyboard = Keyboard.Text;
            _nombre.Placeholder = "Nombre Empleado";
            contenido.Children.Add(_nombre);
            //Apellido
            _apellido = new Entry();
            _apellido.Keyboard = Keyboard.Text;
            _apellido.Placeholder = "Apellido Empleado";
            contenido.Children.Add(_apellido);
            //Edad
            _edad = new Entry();
            _edad.Keyboard = Keyboard.Text;
            _edad.Placeholder = "Edad Empleado";
            contenido.Children.Add(_edad);
            //Direccion
            _direccion = new Entry();
            _direccion.Keyboard = Keyboard.Text;
            _direccion.Placeholder = "Direccion Empleado";
            contenido.Children.Add(_direccion);
            //Puesto
            _puesto = new Entry();
            _puesto.Keyboard = Keyboard.Text;
            _puesto.Placeholder = "Puesto Empleado";
            contenido.Children.Add(_puesto);
            Empleados em = new Empleados();
            _guardar = new Button();
            _guardar.Text = "Actualizar";
            _guardar.Clicked += _guardar_Clicked;
            
            contenido.Children.Add(_guardar);

            _eliminar = new Button();
            _eliminar.Text = "Eliminar";
            _eliminar.Clicked += _eliminar_Clicked;
            
            contenido.Children.Add(_eliminar);
        }

        private async void _guardar_Clicked(object sender, EventArgs e)
        {
            var conexion = new SQLiteConnection(_db);
            Empleados em = new Empleados()
            {
                Id=Convert.ToInt32(_id.Text),
                Nombre = _nombre.Text,
                Apellido = _apellido.Text,
                Edad = _edad.Text,
                Direccion = _direccion.Text,
                Puesto = _puesto.Text,
            };
            conexion.Update(em);
            await Navigation.PopAsync();
            await App.Current.MainPage.DisplayAlert("Modificado con exito", "Empleado " + em.Nombre + " Modificado", "OK");
        }
        private async void _eliminar_Clicked(object sender, EventArgs e)
        {
            var conexion = new SQLiteConnection(_db);
            Empleados em = new Empleados()
            {
                Id = Convert.ToInt32(_id.Text),
                Nombre = _nombre.Text,
                Apellido = _apellido.Text,
                Edad = _edad.Text,
                Direccion = _direccion.Text,
                Puesto = _puesto.Text,
            };
            conexion.Delete(em);
            await App.Current.MainPage.DisplayAlert("Eliminado con exito", "Empleado " + em.Nombre + " Eliminado", "OK");
            await Navigation.PopAsync();
        }

        private void ListaEditar_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Empleados em = (Empleados)e.SelectedItem;
            _id.Text = em.Id.ToString();
            _nombre.Text = em.Nombre.ToString();
            _apellido.Text = em.Apellido.ToString();
            _edad.Text = em.Edad.ToString();
            _direccion.Text = em.Direccion.ToString();
            _puesto.Text = em.Puesto.ToString();
        }
    }
}