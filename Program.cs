using SonicUniverse.Entities;
using SonicUniverse.Entities.Repositories;
using System;

namespace SonicUniverse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var charactersRepository = new GenericRepositoryWithRemove<Characters,int>();
            charactersRepository.Add(new Characters { FirstName = "Sonic" });
            charactersRepository.Add(new Characters { FirstName = "Tails" });
            charactersRepository.Add(new Characters { FirstName = "Knuckles" });
            charactersRepository.Save();

            var organizationRepository = new GenericRepository<Organization,Guid>();
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            organizationRepository.Add(new Organization { Name = "Globomantics" });
            organizationRepository.Save();

            Console.ReadLine();
        }
    }
}