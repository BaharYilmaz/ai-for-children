using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AIForChildren.Data;
using AIForChildren.Dtos;
using AIForChildren.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace MusteriPaneli.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository;
        private IConfiguration _configuration; //token için

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            if (await _authRepository.KullaniciKontrol(userForRegisterDto.KullaniciAdi))
            {
                ModelState.AddModelError("UserName", "User Name already exist");

            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userToCreate = new Kullanici
            {
                KullaniciAdi = userForRegisterDto.KullaniciAdi
            };

            var createdUset = await _authRepository.Register(userToCreate, userForRegisterDto.Sifre);
            return StatusCode(201);
        }


        [HttpPost("login")]
        public async Task<ActionResult> GirisYap([FromBody] UserForLoginDto userForLoginDto)
        {
            var user = await _authRepository.GirisYap(userForLoginDto.KullaniciAdi, userForLoginDto.Sifre);
            if (user==null)
            {
                return Unauthorized();
            }
            //token temsilcisi
            var tokenHandler = new JwtSecurityTokenHandler();

            //appsettings deki token değerini alıyoruz
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            //token aıklamaları
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //gerekli kullanıcı bilgilerini
                    new Claim (ClaimTypes.NameIdentifier,user.KullaniciId.ToString()),
                    new Claim (ClaimTypes.Name, user.KullaniciAdi)
                }),
                Expires = DateTime.Now.AddDays(1),//token geçerlilik süresi

                //kullanılan algoritma ve key içeriği
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            //token oluşturuldu
            var token = tokenHandler.CreateToken(tokenDescription);

            //token stringi elde edildi
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(tokenString);

        }
    }
}