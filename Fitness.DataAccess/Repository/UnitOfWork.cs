using Fitness.DataAccess.Data;
using Fitness.DataAccess.Repository.IRepository;
using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.DataAccess.Repository
{
    


    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IUebungRepository Uebungen { get; private set; }
        public ITrainingsplanRepository Trainingsplaene { get; private set; }

        public IGeplanteUebungRepository GeplanteUebungen { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Uebungen = new UebungRepository(_db);
            Trainingsplaene = new TrainingsplanRepository(_db);
            GeplanteUebungen = new GeplanteUebungRepository(_db);

        }
       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
