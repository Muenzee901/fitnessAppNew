using Fitness.DataAccess.Data;
using Fitness.DataAccess.Repository.IRepository;
using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.DataAccess.Repository
{
    public class UebungRepository : Repository<Uebung>, IUebungRepository
    {
        private ApplicationDbContext _db;
        public UebungRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Uebung uebung)
        {
            _db.Uebungen.Update(uebung);
        }
    }
}
