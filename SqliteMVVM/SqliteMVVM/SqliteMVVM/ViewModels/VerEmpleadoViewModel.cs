using SqliteMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SqliteMVVM.Services;

namespace SqliteMVVM.ViewModels
{
    public class VerEmpleadoViewModel : Empleados
    {
        private ObservableCollection<Empleados> ListadoEmpleados;

        public VerEmpleadoViewModel()
        {

        }


        public ObservableCollection<Empleados> ListadoEmpleado1
        {
            get
            {
                if (ListadoEmpleados == null)
                {
                    LlenarPersonas();
                }

                return ListadoEmpleados;
            }

            set
            {
                ListadoEmpleados = value;
            }
        }

        public void LlenarPersonas()
        {
            using (var contexto = new DataContext())
            {
                ObservableCollection<Empleados> modelo = new ObservableCollection<Empleados>(contexto.Consultar());
                ListadoEmpleados = modelo;
            }



        }
    }
}
