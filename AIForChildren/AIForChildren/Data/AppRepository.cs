using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIForChildren.Data
{
    public class AppRepository : IAppRepository
    {
        private DataContext _context;
        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public AppRepository()
        {
        }

       
        //oyun listele

        //public List<Musteri> MusteriListele()
        //{
        //    var musteriListesi= _context.Musteri.ToList();
        //    return musteriListesi;


        //}

       

        public bool DegisiklikleriKaydet()
        {
            return _context.SaveChanges() > 0;
        }

       

        
        //oyun son durumu getir

        //public List<Musteri> MusteriGetir(int id)
        //{
        //    List<Musteri> m = new List<Musteri>();
        //     m = _context.Musteri.Where(s => s.MusteriId == id).ToList();
            
        //    return m;


        //}

       
    }
}
 