
using BlogApplication.Data.Queries;
using BlogApplication.Model.DataModel;
using BlogApplication.Model;

namespace BlogApplication.Data.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        public Task CreateComment(Comment comment, User user, Article article);
        public Task UpdateComment(Comment comment, UpdateCommentQuery query);
        public Task DeleteComment(Comment comment);
        public Task<Comment[]> GetAllComments();
        public Task<Comment> GetCommentById(Guid id);
    }
}
