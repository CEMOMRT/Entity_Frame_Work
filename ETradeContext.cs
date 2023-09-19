using System;
using System.Collections.Generic;
using System.Data.Entity;//DbContext'in kütüphanesi
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Frame_Work//Project fail
{
    public class ETradeContext:DbContext//public olarak olmadı
    {
        public DbSet<Product> Products { get; set; }//Product'ı bir entityset olarak kulllanacak (tablo şeklinde)
        //Hatayı çözemedim.
    }
}
