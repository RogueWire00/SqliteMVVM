using SqliteMVVM.Models;
using SqliteMVVM.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SqliteMVVM.ViewModels
{
    class AgregarEmpleadoViewModel : Empleados
    {
        public ICommand Guardar { get; private set; }
        public ICommand Nuevo { get; private set; }
        public AgregarEmpleadoViewModel()
        {
            Nuevo = new Command(() =>
            {

                Nombre = string.Empty;
                Apellido = string.Empty;
                Edad = string.Empty;
                Direccion = string.Empty;
                Puesto = string.Empty;


            }
          );


            Guardar = new Command(() =>
            {
                Empleados modelo = new Empleados()
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Edad = Edad,
                    Direccion = Direccion,
                    Puesto = Puesto

                };

                using (var contexto = new DataContext())
                {
                    contexto.Insertar(modelo);
                    
                }
                 

            }
             );
        }
    }
}
