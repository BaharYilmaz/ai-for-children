using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIForChildren.Models
{
    public class KullaniciOyun
    {
        [Key]
        public int KullaniciOyunId { get; set; }
        public Kullanici Kullanici { get; set; }
        public Oyun Oyun { get; set; }

        //        OyunId INT FOREIGN KEY REFERENCES Oyun(OyunId),
        //        KullaniciId INT FOREIGN KEY REFERENCES Kullanici(KullaniciId)
    }
}
