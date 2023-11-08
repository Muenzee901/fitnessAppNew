using Fitness.Models;
using System.Linq.Expressions;

namespace Fitness.DataAccess.Repository.IRepository
{
    public interface ITrainingsplanRepository : IRepository<Trainingsplan>
    {
        void Update(Trainingsplan trainingsplan);

        //public Trainingsplan GetWithUebungen(Expression<Func<Trainingsplan, bool>> filter);
    }
}