
using BlogApplication.Data.Queries;
using BlogApplication.Model.DataModel;
using BlogApplication.Model;

namespace BlogApp.Data.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        public Task CreateArticle(Article article, User user);
        public Task UpdateArticle(Article article, User user, UpdateArticleQuery query);
        public Task DeleteArticle(Article article);
        public Task<Article> GetArticleById(Guid id);
        public Task<Article[]> GetArticles();
    }
}
