using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIForChildren.Models;

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


        

        public bool DegisiklikleriKaydet()
        {
            return _context.SaveChanges() > 0;
        }

        public List<Oyun> OyunGetir(int id)
        {
            throw new NotImplementedException();
        }

        public List<Oyun> OyunListele()
        {
            var oyunListesi = _context.Oyun.ToList();
            return oyunListesi;
        }

        public List<OyunIcerik> OyunIcerikGetir(int id)
        {

            List<OyunIcerik> oyunIcerik = new List<OyunIcerik>();
            oyunIcerik = _context.OyunIcerik.Where(s => s.Oyun.OyunId == id).ToList();

            return oyunIcerik;


        }


    }
}
