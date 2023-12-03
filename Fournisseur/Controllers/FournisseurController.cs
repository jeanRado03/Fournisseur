using Fournisseur.Model;
using Fournisseur.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fournisseur.Controllers
{
    [ApiController]
    [Route(("controller/[controller]"))]
    public class FournisseurController : ControllerBase
    {
        private readonly FournisseurService _fournisseurService;    

        public FournisseurController()
        {
            _fournisseurService = new FournisseurService();
        }

        [HttpPost("saveFournisseur")]
        public IActionResult saveFournisser([FromBody] Fournisseurs fournisseurs)
        {
            _fournisseurService.saveFournisseur(fournisseurs);
            return Ok(fournisseurs);
        }
    }
}
