using Fitness.Models;

namespace Fitness.DataAccess.Repository.IRepository
{
    public interface IUebungRepository : IRepository<Uebung>
    {
        void Update(Uebung uebung);
    }
}
