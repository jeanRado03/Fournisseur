using Fournisseur.DataAccess;
using Fournisseur.Model;

namespace Fournisseur.Services
{
    public class FournisseurService
    {
        private ObjectDAO objectDAO;

        public FournisseurService()
        {
            objectDAO = new ObjectDAO();
        }

        public void saveFournisseur(Fournisseurs fournisseur)
        {
            objectDAO.insertObject(fournisseur);
        }

        public Fournisseurs[] getAllFournisseurs() 
        {
            Fournisseurs fournisseurs = new Fournisseurs();
            Object[] objects = objectDAO.getObjects(fournisseurs);
            Fournisseurs[] fournisseurslist = objects.Cast<Fournisseurs>().ToArray();
            return fournisseurslist;
        }

        public Fournisseurs[] getFournisseurById(string id)
        {
            Fournisseurs fournisseurs = new Fournisseurs();
            Object[] objects = objectDAO.getObjectsByID(fournisseurs, id);
            Fournisseurs[] fournisseurslist = objects.Cast<Fournisseurs>().ToArray();
            return fournisseurslist;
        }
    }
}
