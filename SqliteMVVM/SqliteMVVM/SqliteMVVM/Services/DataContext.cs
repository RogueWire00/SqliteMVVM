using SQLite;
using SqliteMVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteMVVM.Services
{
    public class DataContext : IDisposable
    {



        public SQLiteConnection cnn;

        public DataContext()
    {

            String _db = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbempleados.db3");
            cnn = new SQLiteConnection(_db);
            cnn.CreateTable<Empleados>();
        }
        public void conexion()
        {
           
        }

        public void Dispose()
    {
           
            cnn.Dispose();
    }

    public async void Insertar(Empleados modelo)
    {

        cnn.Insert(modelo);
        await App.Current.MainPage.DisplayAlert("Guardado con exito", "Empleado "+modelo.Nombre +" Guardado", "OK");
          

        }
    public async void Actualizar(Empleados modelo)
    {
        cnn.Update(modelo);
         await App.Current.MainPage.DisplayAlert("Modificado con exito", "Empleado " + modelo.Nombre + " Modificado", "OK");
        }
    public async void Eliminar(Empleados modelo)
    {
        cnn.Delete(modelo);
            await App.Current.MainPage.DisplayAlert("Eliminado con exito", "Empleado " + modelo.Nombre + " Eliminado", "OK");
        }
    public Empleados Consultar(int Id)
    {
            return cnn.Table<Empleados>().FirstOrDefault(p => p.Id == Id);
        }

    public List<Empleados> Consultar()
    {
        return cnn.Table<Empleados>().ToList();
    }

}
}