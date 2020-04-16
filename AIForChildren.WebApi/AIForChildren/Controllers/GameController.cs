using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIForChildren.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIForChildren.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IAppRepository _appRepository;
        public GameController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        //https://localhost:44358/api/game
        public ActionResult OyunListele()
        {
            var oyunListesi = _appRepository.OyunListele();
            return Ok(oyunListesi);

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