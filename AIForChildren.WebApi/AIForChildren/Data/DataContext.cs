using Microsoft.EntityFrameworkCore;
using AIForChildren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIForChildren.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        //Model klasöründeki tabloları veritabanı ile eşleştirme
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Oyun> Oyun { get; set; }
        public DbSet<OyunIcerik> OyunIcerik { get; set; }
        public DbSet<KullaniciOyun> KullaniciOyun { get; set; }



    }
}
