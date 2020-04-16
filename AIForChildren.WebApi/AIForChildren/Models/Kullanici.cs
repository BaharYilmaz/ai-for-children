using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIForChildren.Models
{
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public byte[] SifreHash { get; set; }
        public byte[] SifreSalt { get; set; }

        //public List<Oyun> Oyunlar { get; set; }



    }
}
