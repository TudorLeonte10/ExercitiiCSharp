namespace Ex17
{
    internal class Ticket
    {
        public string Zone { get; }
        public double FinalPrice { get; }
        public Movie Movie { get; }

        public Ticket(Movie movie, string zone)
        {
            Movie = movie;
            Zone = zone.ToLower();
            FinalPrice = CalculatePrice();
        }

        private double GetZoneMultiplier()
        {
            return Zone switch
            {
                "fata" => 0.9,
                "mijloc" => 1.0,
                "spate" => 1.2,
                _ => 1.0
            };
        }

        private double CalculatePrice()
        {
            return Movie.BaseTicketPrice *
                   Movie.GetScreenMultiplier() *
                   GetZoneMultiplier();
        }

        public override string ToString()
        {
            return $"Zona: {Zone,-6} | Pret: {FinalPrice} lei";
        }
    }
}
