using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace SqliteMVVM.Models
{
    public class Empleados 
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido{ get; set; }
    public String Edad{ get; set; }
        public String Direccion{ get; set; }
public String Puesto{ get; set; }



       
      

      

        
        public override string ToString()
        {
            return this.Nombre + " " + this.Apellido + "(" + this.Puesto + ")";
        }
    }
}
