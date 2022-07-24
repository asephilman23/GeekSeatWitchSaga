namespace GeekSeatWitchSaga.Models
{
    public class Villager
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public int AgeOfDeath { get; set; }
        public int YearOfDeath { get; set; }
        public int YearKilled { get; set; }
        public int NumberKilled { get; set; }
    }
}
