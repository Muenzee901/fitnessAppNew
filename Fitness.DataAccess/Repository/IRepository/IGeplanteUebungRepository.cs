

using Fitness.DataAccess.Repository.IRepository;
using Fitness.Models;

namespace Fitness.DataAccess.Repository.IRepository
{
    public interface IGeplanteUebungRepository : IRepository<GeplanteUebung>
    {
        void Update(GeplanteUebung geplanteUebung);
        public List<GeplanteUebung> getGeplanteUebungenWithUebung(Guid? trainingsplanId);
        
        public GeplanteUebung? getGeplanteUebungWithUebung(Guid? geplanteUebungsId);
    }
}
