namespace Fournisseur.Model
{
    public class Personne
    {
        public string idPersonne {  get; set; }
        public string nom {  get; set; }
        public string prenom {  get; set; }
        public DateOnly dateNaissance { get; set; }
        public string genre { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
    }
}
