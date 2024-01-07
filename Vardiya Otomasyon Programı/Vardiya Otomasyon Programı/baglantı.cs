using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vardiya_Otomasyon_Programı
{
    class baglantı
    {
        public string Adres = System.IO.File.ReadAllText(@"C:\baglantı.txt");
    }
}
