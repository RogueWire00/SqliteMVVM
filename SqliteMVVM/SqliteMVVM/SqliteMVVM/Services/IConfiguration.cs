using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Interop;

namespace SqliteMVVM.Services
{
    public interface IConfiguration
    {
        string directorio { get; set; }

        ISQLitePlatform plataforma { get; }


    }
}
