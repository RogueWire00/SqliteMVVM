using SqliteMVVM.Models;
using SqliteMVVM.Services;
using SqliteMVVM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SqliteMVVM.ViewModels
{
    class EditarEmpleadoViewModel : Empleados
    {
        public ICommand Modificar { get; private set; }
        public ICommand Eliminar { get; private set; }

        public EditarEmpleadoViewModel()
        {
            Modificar = new Command(() =>
            {
                Empleados modelo = new Empleados()
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Edad = Edad,
                    Direccion = Direccion,
                    Puesto = Puesto,
                    Id = Id
                };

                using (var contexto = new DataContext())
                {
                    contexto.Actualizar(modelo);
                }
            }
                );

            Eliminar = new Command(() =>
            {
                Empleados modelo = new Empleados()
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Edad = Edad,
                    Direccion = Direccion,
                    Puesto = Puesto,
                    Id = Id
                };

                using (var contexto = new DataContext())
                {
                    contexto.Eliminar(modelo);
                }
            }
           );
        }
    }
}