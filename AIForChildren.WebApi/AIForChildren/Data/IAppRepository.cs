using AIForChildren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIForChildren.Data
{
    public interface IAppRepository
    {

        //void OyunDurumGuncelle<T>(T entity) where T : class;
        bool DegisiklikleriKaydet();
        List<OyunIcerik> OyunIcerikGetir(int id);
        List<Oyun> OyunListele();
        //kullanıcı oyun bilgisi ekle
    }
}

