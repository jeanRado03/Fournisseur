using Fournisseur.DataAccess;
using Fournisseur.Model;

namespace Fournisseur.Services
{
    public class PersonneService
    {
        private ObjectDAO objectDAO;

        public PersonneService() 
        {
            objectDAO = new ObjectDAO();
        }

        public void savePersonne(Personne personne)
        {
            objectDAO.insertObject(personne);
        }

        public Personne[] getAllPersonnes()
        {
            Personne personne = new Personne();
            Object[] objects = objectDAO.getObjects(personne);
            Personne[] personnes = objects.Cast<Personne>().ToArray();
            return personnes;
        }

        public Personne[] getAllPersonneById(string id)
        {
            Personne personne = new Personne();
            Object[] objects = objectDAO.getObjectsByID(personne, id);
            Personne[] personnes = objects.Cast<Personne>().ToArray();
            return personnes;
        }
    }
}
