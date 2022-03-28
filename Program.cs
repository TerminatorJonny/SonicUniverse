using SonicUniverse.Data;
using SonicUniverse.Entities;
using SonicUniverse.Entities.Repositories;
using SonicUniverse.Repositories;

namespace SonicUniverse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var charactersRepository = new SqlRepository<Characters>(new StorageAppDbContext());
            charactersRepository.ItemAdded += CharactersRepository_ItemAdded;

            AddCharacters(charactersRepository);
            AddManagers(charactersRepository);
            GetCharactersById(charactersRepository);
            WriteAllToConsole(charactersRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAllToConsole(organizationRepository);

            Console.ReadLine();
        }

        private static void CharactersRepository_ItemAdded(object? sender, Characters e)
        {
            Console.WriteLine($"Character added => {e.FirstName}");
        }

        private static void AddManagers(IWriteRepository<Manager> ManagerRepository)
        {
            var saraManager = new Manager { FirstName = "Sara" };
            var saraManagerCopy = saraManager.Copy();
            ManagerRepository.Add(saraManager);

            if (saraManagerCopy is not null)
            {
                saraManagerCopy.FirstName += "_Copy";
                ManagerRepository.Add(saraManagerCopy);
            }

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
            var characters = new[]
            {
            new Characters { FirstName = "Sonic" },
            new Characters { FirstName = "Tails" },
            new Characters { FirstName = "Knuckles" }
            };
            charactersRepository.AddBatch(characters);
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization { Name = "Pluralsight" },
                new Organization { Name = "Globomantics" }
            };
            organizationRepository.AddBatch(organizations);
        }
    }
}