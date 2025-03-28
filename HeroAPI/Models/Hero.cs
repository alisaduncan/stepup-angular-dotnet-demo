using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.SignalR;

namespace HeroAPI.Models 
{

    public class Hero 
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public string? License { get; set; }

        public string? Country { get; set; }
    }

    public class HeroData 
    {
        private static readonly string[] Countries = new[]
        {
            "Brazil", "Belgium", "Canada", "Mozambique", "Mongolia", "Poland", "Costa Rica", "Bermuda", "Pakistan", "Australia"
        };

        private static List<Hero> AllHeroes = new List<Hero>
        {
            new Hero { Id = 12, Name = "Dr. Nice", License = "37FP8", Country = Countries[Random.Shared.Next(Countries.Length)] },
            new Hero { Id = 13, Name = "Bombasto", License = "8694726", Country = Countries[Random.Shared.Next(Countries.Length)] },
            new Hero { Id = 14, Name = "Celeritas", License = "762-86-112", Country = Countries[Random.Shared.Next(Countries.Length)] },
            new Hero { Id = 15, Name = "Magneta", License = "EQMS8", Country = Countries[Random.Shared.Next(Countries.Length)] },
            new Hero { Id = 16, Name = "RubberMan", License = "20b8a34b-4650-4732-a550-2b7edb1fe473", Country = Countries[Random.Shared.Next(Countries.Length)] },
            new Hero { Id = 17, Name = "Dynama", License = "REG 98U7W6", Country = Countries[Random.Shared.Next(Countries.Length)] },
            new Hero { Id = 18, Name = "Dr. IQ", License = "0000751", Country = Countries[Random.Shared.Next(Countries.Length)] },
            new Hero { Id = 19, Name = "Magma", License = "24681368", Country = Countries[Random.Shared.Next(Countries.Length)] },
            new Hero { Id = 20, Name = "Tornado", License = "0b0ae1d6-b42e-4d6c-aad6-ad93b7d0721b", Country = Countries[Random.Shared.Next(Countries.Length)] },
            new Hero { Id = 21, Name = "Web Sprite", License = "#5dade2", Country = Countries[Random.Shared.Next(Countries.Length)] },
            new Hero { Id = 22, Name = "Binary Banshee", License = "101010", Country = Countries[Random.Shared.Next(Countries.Length)] },
            new Hero { Id = 23, Name = "Cyber Charmer", License = "L33T", Country = Countries[Random.Shared.Next(Countries.Length)] },
        };

        public IEnumerable<Hero> FullHeroes { get; } = AllHeroes;
        public List<Hero> Heroes { get; } = [.. AllHeroes.Select(hero => new Hero() { Id = hero.Id, Name = hero.Name })];
        public List<Hero> FeaturedHeroes { get; } = [.. AllHeroes[..3].Select(hero => new Hero() { Name = hero.Name })];
    }
}