using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIForChildren.Models
{
    public class Kullanici
    {
        
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public byte[] SifreHash { get; set; }
        public byte[] SifreSalt { get; set; }



    }
}
