using System;
using System.Collections.Generic;


namespace SonicUniverse.Entities.Repositories
{
    public class GenericRepository<T, TKey>
    {
        public TKey? Key { get; set; }

        protected readonly List<T> _items = new();
        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class GenericRepositoryWithRemove<T, Tkey> : GenericRepository<T, Tkey>
    {
        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }
}