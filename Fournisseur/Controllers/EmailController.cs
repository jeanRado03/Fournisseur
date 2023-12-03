using Fournisseur.Emails;
using Microsoft.AspNetCore.Mvc;

namespace Fournisseur.Controllers
{
    [ApiController]
    [Route(("email/[controller]"))]
    public class EmailController : ControllerBase
    {
        public EmailController() { }

        [HttpGet("sendMail")]
        public IActionResult sendMail()
        {
            Email.NewHeadlessEmail("jrakotonirina69@gmail.com", "ftfihkfjzxjxqeub", "jeanrado03@gmail.com", "Reponsedemande", "Cher monsieur, je vous remercie");
            return Ok();
        }

        [HttpGet("sendMail/{pathfile}")]
        public IActionResult sendMailAttachemnt(string pathfile)
        {
            Email.SendEmailWithAttachment("jrakotonirina69@gmail.com", "ftfihkfjzxjxqeub", "jeanrado03@gmail.com", "Envoie fichier", "Cher monsieur, voila le fichier", pathfile);
            return Ok();
        }
    }
}
