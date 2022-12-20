using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (catalogContext.Database.IsSqlServer())
                {
                    catalogContext.Database.Migrate();
                }

                if (!await catalogContext.CatalogBrands.AnyAsync())
                {
                    await catalogContext.CatalogBrands.AddRangeAsync(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogTypes.AnyAsync())
                {
                    await catalogContext.CatalogTypes.AddRangeAsync(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogItems.AnyAsync())
                {
                    await catalogContext.CatalogItems.AddRangeAsync(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;
                var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                log.LogError(ex.Message);
                await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                throw;
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>
            {
                //Updated with new brands for catalog
                new("Juegoal"),
                new("Maverick"),
                new("Chessex"),
                new("Wizards of the Coast"),
                new("Other")
            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>
            {
                //Updated with new types of products
                new("Dice"),
                new("Cards"),
                new("Card Games"),
                new("Board Games"),
                new("Magic the Gathering")
                
            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>
            {
                // Added my new products for my shop
                // 10 points for the assignment
                new(4,1, "Juegoal Wooden Chess & Checkers Set with Storage Drawer, 12 Inch Classic 2 in 1 Board Games for Kids and Adults, Travel Portable Chess Game Sets, 2 Extra Queen, Extra 24 Wooden Checkers Pieces",
                    "Juegoal Wooden Chess & Checkers Set with Storage Drawer", 39.99M,  "https://m.media-amazon.com/images/I/71+tUMbRZFL._AC_SL1500_.jpg", "Classic"),
                new(3,5, "Five Crowns -- The Game Isn't Over Until the Kings Go Wild! -- 5 Suited Rummy-Style Card Game -- 8+",
                    "Five Crowns", 12.99M, "https://m.media-amazon.com/images/I/617lPmDJnvL._AC_SL1000_.jpg", "Group/Multiplayer"),
                new(1,3, "12mm Six Sided Die (36) Block of Dice",
                    "Chessex Dice d6 Sets: Marble Ivory with Black", 13.98M,
                    "https://m.media-amazon.com/images/I/71ZgZfikW2L._AC_SL1400_.jpg", "Accessory"),
                new(1,5, "Haxtec DND Dice Set Sharp Edge Resin Dice Iridecent Inclusion with Dice Case Purple D&D Dice for RPG Role Playing Games Dungeons and Dragons Gift Galaxy Series",
                    "Haxtec DND Dice Set Sharp Edge Resin Dice", 26.99M,
                    "https://m.media-amazon.com/images/I/81HgVMHrTkL._AC_SL1500_.jpg", "Accessory"),
                new(1,5, "D&D 7/Set of Polyhedral Resin TRPG Dice Set MTG Dungeons and Dragons Pathfinder Role-Playing Board Game Collection and Gifts (with Exquisite Metal Box)-Red and Blue",
                    "D&D 7/Set of Polyhedral Resin TRPG Dice Set", 29.99M,
                    "https://m.media-amazon.com/images/I/81zEf57uOoL._AC_SL1500_.jpg", "Accessory"),
                new(3,1, "Juegoal Upgrade Wood Cribbage Board Game Set, Solid Wooden Continuous 3 Track Board with Larger Storage Area, 9 Metal Pegs and 2 Decks of Playing Cards, Travel Portable Cribbage Game Sets",
                    "Juegoal Upgrade Wood Cribbage Board Game Set", 27.99M,
                    "https://m.media-amazon.com/images/I/813ov1Ig+oL._AC_SL1500_.jpg", "Classic"),
                new(2,2, "Maverick Playing Cards, Jumbo Index, 12 Pack",
                    "Maverick Playing Cards, Jumbo Index, 12 Pack", 19.99M,
                    "https://m.media-amazon.com/images/I/81rdNJUN2EL._AC_SL1500_.jpg", "Bulk"),
                new(5,4, "Magic: The Gathering The Brothers’ War Retro-Frame Commander Deck - Urza's Iron Alliance (White-Blue-Black) + Collector Booster Sample Pack",
                    "Commander Deck - Urza's Iron Alliance", 45.00M,
                    "https://m.media-amazon.com/images/I/81ldSIYzGoL._AC_SL1500_.jpg", "Trading Card Game"),
                new(5,4, "Magic: The Gathering The Brothers’ War Retro-Frame Commander Deck - Mishra’s Burnished Banner (Blue-Black-Red) + Collector Booster Sample Pack",
                    "Commander Deck - Mishra’s Burnished Banner", 45.00M,
                    "https://m.media-amazon.com/images/I/81N2ZwuYoLL._AC_SL1500_.jpg", "Trading Card Game"),
                new(5,4, "Magic The Gathering Strixhaven Commander Deck – Lorehold Legacies (Red-White)",
                    "Magic The Gathering Strixhaven Commander Deck", 34.64M,
                    "https://m.media-amazon.com/images/I/71RO9uuSBGL._AC_SL1500_.jpg", "Trading Card Game"),
                new(5,4, "Magic The Gathering Strixhaven Commander Deck – Quantum Quandrix (Blue-Green)",
                    "Magic The Gathering Strixhaven Commander Deck", 36.14M,
                    "https://m.media-amazon.com/images/I/71HwjdK3nfL._AC_SL1500_.jpg", "Trading Card Game"),
                new(1,3, "Chessex Dice d6 Sets: Nebula Black with White - 12mm Six Sided Die (36) Block of Dice",
                    "Chessex Dice d6 Sets: Nebula Black with White", 13.98M,
                    "https://m.media-amazon.com/images/I/51sGN0Ah8NL._AC_.jpg", "Accessory"),
                new(1,3, "Chessex Green with White Spots Translucent 12Mm 6 Sided Dice 36 by Alliance Games",
                    "Chessex Green with White Spots Translucent", 9.98M,
                    "https://m.media-amazon.com/images/I/51Acy0hXr9L._AC_.jpg", "Accessory"),
                new(1,3, "Chessex Dice D6 Sets: Teal with White Translucent - 12Mm Six Sided Die (36) Block of Dice",
                    "Chessex Dice D6 Sets: Teal with White Translucent", 8.99M,
                    "https://m.media-amazon.com/images/I/51Acy0hXr9L._AC_.jpg", "Accessory"),
                new(1,3, "Chessex CHX27402 Dice-Marble Ivory/Black Set",
                    "Chessex CHX27402 Dice-Marble Ivory/Black Set", 9.64M,
                    "https://m.media-amazon.com/images/I/61OwtZTJakL._AC_SL1200_.jpg", "Accessory")
            };
        }
    }
}
