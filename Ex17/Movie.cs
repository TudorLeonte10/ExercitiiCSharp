namespace Ex17
{
    internal class Movie
    {
        public string Title { get; }
        public ScreenType ScreenType { get; }
        public double BaseTicketPrice { get; }

        public Movie(string title, ScreenType type, double basePrice)
        {
            Title = title;
            ScreenType = type;
            BaseTicketPrice = basePrice;
        }

        public double GetScreenMultiplier()
        {
            return ScreenType switch
            {
                ScreenType.TwoD => 1.0,
                ScreenType.ThreeD => 1.25,
                ScreenType.FourD => 1.6,
                _ => 1.0
            };
        }
    }
}
