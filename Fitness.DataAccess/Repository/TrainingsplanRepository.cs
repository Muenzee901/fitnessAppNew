using Fitness.DataAccess.Data;
using Fitness.DataAccess.Repository.IRepository;
using Fitness.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Fitness.DataAccess.Repository
{
    internal class TrainingsplanRepository : Repository<Trainingsplan>, ITrainingsplanRepository
    {

        private ApplicationDbContext _db;
        public TrainingsplanRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Trainingsplan trainingsplan)
        {
            _db.Trainingsplaene.Update(trainingsplan);
        }

        /*public Trainingsplan GetWithUebungen(Expression<Func<Trainingsplan, bool>> filter)
        {
            IQueryable<Trainingsplan> query = dbSet;
            query = query.Where(filter).Include( tp => tp.geplanteUebungen).ThenInclude(gu => gu.Uebung);

            return query.FirstOrDefault();
        }*/
    }
}
