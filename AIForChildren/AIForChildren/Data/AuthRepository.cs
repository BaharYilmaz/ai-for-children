using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIForChildren.Models;
using Microsoft.EntityFrameworkCore;

namespace AIForChildren.Data
{
    public class AuthRepository : IAuthRepository
    {
       
        private  DataContext _context;
        public AuthRepository(DataContext Context)
        {
            _context = Context;
        }

        public async Task<Kullanici> Register(Kullanici kullanici, string sifre)
        {
            byte[] sifreHash, sifreSalt;
            CreatePasswordHash(sifre, out sifreHash, out sifreSalt);

            kullanici.SifreHash = sifreHash;
            kullanici.SifreSalt = sifreSalt;

            await _context.Kullanici.AddAsync(kullanici);
            await _context.SaveChangesAsync();

            return kullanici;

             
        }

        private void CreatePasswordHash(string sifre, out byte[] sifreHash, out byte[] sifreSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                sifreSalt = hmac.Key;
                sifreHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(sifre));

            }
        }

        public async Task<bool> KullaniciKontrol(string kullaniciAd)
        {
            if (await _context.Kullanici.AnyAsync(x=>x.KullaniciAdi==kullaniciAd))
            {
                return true;
            }
            return false;

        }

        public async Task<Kullanici> GirisYap(string kullaniciAd, string sifre)
        {
            var user = await _context.Kullanici.FirstOrDefaultAsync(x => x.KullaniciAdi == kullaniciAd);
            if (user==null)
            {
                return null;
            }
            if (!VerifyPasswordHash(sifre,user.SifreHash,user.SifreSalt))
            {
                return null;
            }
            return user;//veritabanındaki kullanıcı döndürülür

        }

        private bool VerifyPasswordHash(string _sifre, byte[] _sifreHash, byte[] _sifreSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(_sifreSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(_sifre));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i]!=_sifreHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
