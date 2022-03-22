using SonicUniverse.Data;
using SonicUniverse.Entities;
using SonicUniverse.Entities.Repositories;
using System;

namespace SonicUniverse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var charactersRepository = new SqlRepository<Characters>(new StorageAppDbContext());
            AddCharacters(charactersRepository);
            AddManagers(charactersRepository);
            GetCharactersById(charactersRepository);
            WriteAllToConsole(charactersRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAllToConsole(organizationRepository);

            Console.ReadLine();
        }

        private static void AddManagers(IWriteRepository<Manager> ManagerRepository)
        {
            ManagerRepository.Add(new Manager { FirstName = "Sara" });
            ManagerRepository.Add(new Manager { FirstName = "Henry" });
            ManagerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetCharactersById(IRepository<Characters> charactersRepository)
        {
            var character = charactersRepository.GetById(2);
            Console.WriteLine($"Character with Id 2: {character.FirstName}");
        }

        private static void AddCharacters(IRepository<Characters> charactersRepository)
        {
            charactersRepository.Add(new Characters { FirstName = "Sonic" });
            charactersRepository.Add(new Characters { FirstName = "Tails" });
            charactersRepository.Add(new Characters { FirstName = "Knuckles" });
            charactersRepository.Save();
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            organizationRepository.Add(new Organization { Name = "Globomantics" });
            organizationRepository.Save();
        }
    }
}