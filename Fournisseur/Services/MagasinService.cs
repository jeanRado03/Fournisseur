using Fournisseur.DataAccess;
using Fournisseur.Model;

namespace Fournisseur.Services
{
    public class MagasinService
    {
        private ObjectDAO objectDAO;

        public MagasinService()
        {
            objectDAO = new ObjectDAO();
        }

        public void saveMagasin(Magasin magasin) 
        {
            objectDAO.insertObject(magasin);
        }

        public Magasin[] getAllMagasin()
        {
            Magasin magasin = new Magasin();
            Object[] objects = objectDAO.getObjects(magasin);
            Magasin[] magasins = objects.Cast<Magasin>().ToArray();
            return magasins;
        }

        public Magasin[] getMagasinById(string id)
        {
            Magasin magasin = new Magasin();
            Object[] objects = objectDAO.getObjectsByID(magasin,id);
            Magasin[] magasins = objects.Cast<Magasin>().ToArray();
            return magasins;
        }
    }
}
