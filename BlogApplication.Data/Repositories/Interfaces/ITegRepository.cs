
using BlogApplication.Data.Queries;
using BlogApplication.Model.DataModel;

namespace BlogApplication.Data.Repositories.Interfaces
{
    public interface ITegRepository
    {
        public Task CreateTeg(Teg teg);
        public Task UpdateTeg(Teg teg, UpdateTegQuery query);
        public Task DeleteTeg(Teg teg);
        public Task<Teg> GetTegById(Guid id);
        public Task<Teg[]> GetTegArray();
    }
}
