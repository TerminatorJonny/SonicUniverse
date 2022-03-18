using SonicUniverse.Entities;
using SonicUniverse.Entities.Repositories;
using System;

namespace SonicUniverse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var charactersRepository = new GenericRepository<Characters>();
            AddCharacters(charactersRepository);
            GetCharactersById(charactersRepository);

            var organizationRepository = new GenericRepository<Organization>();
            AddOrganizations(organizationRepository);

            Console.ReadLine();
        }

        private static void GetCharactersById(GenericRepository<Characters> charactersRepository)
        {
            var character = charactersRepository.GetById(2);
            Console.WriteLine($"Character with Id 2: {character.FirstName}");
        }

        private static void AddCharacters(GenericRepository<Characters> charactersRepository)
        {
            charactersRepository.Add(new Characters { FirstName = "Sonic" });
            charactersRepository.Add(new Characters { FirstName = "Tails" });
            charactersRepository.Add(new Characters { FirstName = "Knuckles" });
            charactersRepository.Save();
        }

        private static void AddOrganizations(GenericRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            organizationRepository.Add(new Organization { Name = "Globomantics" });
            organizationRepository.Save();
        }
    }
}