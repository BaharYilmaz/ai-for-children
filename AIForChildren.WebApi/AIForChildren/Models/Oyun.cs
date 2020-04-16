using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIForChildren.Models
{
    public class Oyun
    {
        //public Oyun()
        //{
        //    Icerikler = new List<OyunIcerik>();
        //}
        [Key]
        public int OyunId { get; set; }
        public string OyunAdi { get; set; }
        public int OyunDurum { get; set; }
      
       // public List<OyunIcerik> Icerikler { get; set; }
       // public List<Kullanici> Kullanicilar { get; set; }

        //        OyunId INT IDENTITY(1,1) PRIMARY KEY,
        //OyunAdi NVARCHAR(50),
        //OyunDurum int,
    }
}
