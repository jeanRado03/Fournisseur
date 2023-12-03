namespace Fournisseur.Model
{
    public class Mouvement
    {
        public string idMouvement {  get; set; }
        public DateOnly dateMouvement { get; set; }
        public string idArticle { get; set; }
        public double quantite { get; set; }
        public string unite { get; set; }
        public double montantUnitaire { get; set; }
        public double tva {  get; set; }
        public string idMagasin { get; set; }
        public string type { get; set; }
    }
}
