using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIForChildren.Base;
using AIForChildren.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIForChildren.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ApiController
    {
        private IAppRepository _appRepository;
        public GameController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        
        
        //https://localhost:44358/api/game
        [HttpGet("oyunListele")]
        public async Task<IActionResult> OyunListele()
        {
            // var oyunListesi = _appRepository.OyunListele();
            return Success("Merhaba, Ben bilgisayar senden öğreneceğim çok şey var lütfen beni eğit.",code:200);

        }

        //https://localhost:44358/api/game/oyunGetir/2
        [HttpGet("oyunGetir/{oyunId}")]
        public ActionResult OyunIcerikGetir(int oyunId)
        {
            var oyun = _appRepository.OyunIcerikGetir(oyunId);
            return Ok(oyun);
        }


    }
}