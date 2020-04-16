using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AIForChildren.Models
{
    public class OyunIcerik
   {
        [Key]
        public int IcerikId { get; set; }
        public string Icerik { get; set; }
        public string IcerikTag { get; set; }

        public Oyun Oyun { get; set; }

        //        IcerikId INT IDENTITY(1,1) PRIMARY KEY,
        //        Icerik NVARCHAR(100),
        //IcerikTag NVARCHAR(50),
        //OyunId INT FOREIGN KEY REFERENCES Oyun(OyunId)
    }
}
