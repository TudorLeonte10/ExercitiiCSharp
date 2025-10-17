using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex17.Models
{
    public class Ticket
    {
        public string MovieName { get; set; } = string.Empty;
        public ScreenType Type { get; set; }
        public string SeatCategory { get; set; } = string.Empty; // Front, Middle, Back
        public decimal BasePrice { get; set; }
        public int Quantity { get; set; }

        public decimal CalculateTotal()
        {
            decimal seatMultiplier = SeatCategory.ToLower() switch
            {
                "front" => 0.9m,   // 10% cheaper
                "middle" => 1.0m,  // normal
                "back" => 1.2m,    // 20% more expensive
                _ => 1.0m
            };

            decimal typeMultiplier = Type switch
            {
                ScreenType.TwoD => 1.0m,
                ScreenType.ThreeD => 1.3m,
                ScreenType.FourD => 1.6m,
                _ => 1.0m
            };

            return BasePrice * Quantity * seatMultiplier * typeMultiplier;
        }
    }
}
