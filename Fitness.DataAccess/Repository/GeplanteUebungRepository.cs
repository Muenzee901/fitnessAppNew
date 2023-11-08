using Fitness.DataAccess.Data;
using Fitness.DataAccess.Repository.IRepository;
using Fitness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.DataAccess.Repository
{
    public class GeplanteUebungRepository : Repository<GeplanteUebung>, IGeplanteUebungRepository
    {
        private ApplicationDbContext _db;
        public GeplanteUebungRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(GeplanteUebung geplanteUebung)
        {
            _db.GeplanteUebungen.Update(geplanteUebung);
        }

        public List<GeplanteUebung> getGeplanteUebungenWithUebung(Guid? trainingsplanId)
        {
            IQueryable<GeplanteUebung> query = dbSet;
            query = query.Where(u => u.TrainingsplanId == trainingsplanId).Include(u => u.Uebung);
        
            return query.ToList();

        }

        public GeplanteUebung? getGeplanteUebungWithUebung(Guid? geplanteUebungsId)
        {
            IQueryable<GeplanteUebung> query = dbSet;
            query = query.Where(u => u.GeplanteUebungId == geplanteUebungsId).Include(u => u.Uebung);

            return query.FirstOrDefault();

        }
    }
}
