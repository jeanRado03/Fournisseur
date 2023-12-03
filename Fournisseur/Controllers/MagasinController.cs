
using Fournisseur.Services;
using Microsoft.AspNetCore.Mvc;
using Fournisseur.Model;

namespace Fournisseur.Controllers
{
    [ApiController]
    [Route(("magasin/[controller]"))]
    public class MagasinController : ControllerBase
    {
        private readonly MagasinService _magasinService;

        public MagasinController()
        {
            _magasinService = new MagasinService();
        }

        [HttpPost("saveMagasin")]
        public IActionResult saveMagasin([FromBody] Magasin magasin)
        {
            _magasinService.saveMagasin(magasin);
            return Ok();
        }

        [HttpGet("magasins")]
        public IEnumerable<Magasin> getMagasin()
        {
            return _magasinService.getAllMagasin();
        }

        [HttpGet("magasin/{idmagasin}")]
        public Magasin getMagasin(string idmagasin)
        {
            return _magasinService.getMagasinById(idmagasin)[0];
        }
    }
}
