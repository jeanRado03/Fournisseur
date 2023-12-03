using Fournisseur.DataAccess;
using Fournisseur.Model;

namespace Fournisseur.Services
{
    public class ArticleService
    {
        private ObjectDAO objectDAO;

        public ArticleService()
        {
            objectDAO = new ObjectDAO();
        }

        public void saveArticle(Article article)
        {
            objectDAO.insertObject(article);
        }

        public Article[] getAllArticles()
        {
            Article article = new Article();
            Object[] objects = objectDAO.getObjects(article);
            Article[] articles = objects.Cast<Article>().ToArray();
            return articles;
        }

        public Article[] getAllArticleById(string id)
        {
            Article article = new Article();
            Object[] objects = objectDAO.getObjectsByID(article,id);
            Article[] articles = objects.Cast<Article>().ToArray();
            return articles;
        }
    }
}
