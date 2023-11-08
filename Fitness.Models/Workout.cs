namespace Fitness.Models
{
    public class Workout
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime ausfuehrungsDatum { get; set; }

        public AusgefuehrteUebung[]? ausgefuehrteUebungen { get; set; }
        
    }
}
