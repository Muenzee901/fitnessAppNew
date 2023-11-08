
namespace Fitness.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUebungRepository Uebungen { get; }

        ITrainingsplanRepository Trainingsplaene { get; }

        IGeplanteUebungRepository GeplanteUebungen { get; }

        void Save();
    }
}
