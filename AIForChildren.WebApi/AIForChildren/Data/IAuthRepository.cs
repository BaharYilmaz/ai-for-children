using AIForChildren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIForChildren.Data
{
    public interface IAuthRepository
    {
        //asenkron
        Task<Kullanici> GirisYap(string kullaniciAd, string sifre);
        Task<Kullanici> Register(Kullanici kullanici, string sifre);

        Task<bool> KullaniciKontrol(string kullaniciAd);

    }
}
