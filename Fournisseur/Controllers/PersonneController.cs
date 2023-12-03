using Fournisseur.Model;
using Fournisseur.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fournisseur.Controllers
{
    [ApiController]
    [Route(("personne/[controller]"))]
    public class PersonneController : ControllerBase
    {
        private readonly PersonneService _personneService;

        public PersonneController()
        {
            _personneService = new PersonneService();
        }

        [HttpPost("savePersonne")]
        public IActionResult savePersonne([FromBody] Personne personne)
        {
            _personneService.savePersonne(personne);
            return Ok(personne);
        }
    }
}
