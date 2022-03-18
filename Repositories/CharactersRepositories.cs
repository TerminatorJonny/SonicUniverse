namespace SonicUniverse.Entities.Repositories
{
    public class CharactersRepositories
    {
        private readonly List<Characters> _characters = new();
        public void Add(Characters characters)
        {
            _characters.Add(characters);
        }

        public void Save()
        {
            foreach (Characters characters in _characters)
            {
                Console.WriteLine(characters);
            }
        }
    }
}