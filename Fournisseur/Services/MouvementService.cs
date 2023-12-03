using Fournisseur.DataAccess;
using Fournisseur.Model;

namespace Fournisseur.Services
{
    public class MouvementService
    {
        private ObjectDAO objectDAO;

        public MouvementService()
        {
            objectDAO = new ObjectDAO();
        }

        public void saveMouvement(Mouvement mouvement)
        {
            objectDAO.insertObject(mouvement);
        }

        public Mouvement[] getAllMouvements()
        {
            Mouvement mouvement = new Mouvement(); 
            Object[] objects = objectDAO.getObjects(mouvement);
            Mouvement[] mouvements = objects.Cast<Mouvement>().ToArray();
            return mouvements;
        }

        public Mouvement[] getMouvementById(string id)
        {
            Mouvement mouvement = new Mouvement();
            Object[] objects = objectDAO.getObjectsByID(mouvement, id);
            Mouvement[] mouvements = objects.Cast<Mouvement>().ToArray();
            return mouvements;
        }
    }
}
