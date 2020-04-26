﻿namespace Petrolheads.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Petrolheads.Data.Models;

    internal class CarMakesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Makes.Any())
            {
                return;
            }

            var makes = new List<string>()
            {
                "AC", "Abarth", "Acura", "Aixam", "Alfa Romeo", "Alpina", "Aro", "Asia", "Aston martin", "Audi", "Austin", "BMW", "Bentley", "Berliner", "Bertone", "Borgward", "Brilliance", "Bugatti", "Buick", "Cadillac", "Chevrolet", "Chrysler", "Citroen", "Corvette", "Cupra", "DS", "Dacia", "Daewoo", "Daihatsu", "Daimler", "Datsun", "Dkw", "Dodge", "Dr", "Eagle", "FSO", "Ferrari", "Fiat", "Ford", "GOUPIL", "Gaz", "Geo", "Gmc", "Great Wall", "Haval", "Heinkel", "Hillman", "Honda", "Hummer", "Hyundai", "Ifa", "Infiniti", "Innocenti", "Isuzu", "Iveco", "JAS", "Jaguar", "Jeep", "Jpx", "Kia", "Lada", "Laforza", "Lamborghini", "Lancia", "Land Rover", "Landwind", "Lexus", "Lifan", "Lincoln", "Lotus", "MG", "Mahindra", "Maserati", "Matra", "Maybach", "Mazda", "McLaren", "Mercedes-Benz", "Mercury", "Mg", "Microcar", "Mini", "Mitsubishi", "Morgan", "Moskvich", "Nissan", "Oldsmobile", "Opel", "Perodua", "Peugeot", "Pgo", "Plymouth", "Polonez", "Pontiac", "Porsche", "Proton", "Renault", "Rolls-Royce", "Rover", "SECMA", "SH auto", "Saab", "Samand", "Santana", "Saturn", "Scion", "Seat", "Shatenet", "Shuanghuan", "Simca", "Skoda", "Smart", "Ssang yong", "SsangYong", "Subaru", "Suzuki", "Talbot", "Tata", "Tavria", "Tazzari", "Tempo", "Terberg", "Tesla", "Tofas", "Toyota", "Trabant", "Triumph", "Uaz", "VROMOS", "VW", "Volga", "Volvo", "Warszawa", "Wartburg", "Wiesmann", "Xinkai", "Xinshun", "Zastava", "Zaz"
            };

            foreach (var make in makes)
            {
                await dbContext.Makes.AddAsync(new Make
                {
                    Name = make,
                });
            }
        }
    }
}
