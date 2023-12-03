using Fournisseur.Model;
using Fournisseur.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fournisseur.Controllers
{
    [ApiController]
    [Route(("mouvement/[controller]"))]
    public class MouvementController : ControllerBase
    {
        private readonly MouvementService _service;

        public MouvementController()
        {
            _service = new MouvementService();
        }

        [HttpPost("saveMouvement")]
        public IActionResult saveMouvement([FromBody] Mouvement mouvement) 
        {
            _service.saveMouvement(mouvement);
            return Ok(mouvement);
        }
    }
}
