using SonicUniverse.Entities;
using SonicUniverse.Entities.Repositories;
using System;

namespace SonicUniverse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var charactersRepository = new CharactersRepositories();
            charactersRepository.Add(new Characters { FirstName = "Sonic" });
            charactersRepository.Add(new Characters { FirstName = "Tails" });
            charactersRepository.Add(new Characters { FirstName = "Knuckles" });
            charactersRepository.Save();

            Console.ReadLine();
        }
    }
}