using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wedding.Models;

namespace wedding.Repositories
{
    public class MockRSVPRepository : IRepository<RSVP>
    {
        private IDictionary<int, RSVP> _items = new Dictionary<int, RSVP>();
        private int _idSequence = 0;

        public Task AddAsync(RSVP item)
        {
            _idSequence++;
            item.Id = _idSequence;

            _items.Add(item.Id, item);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            _items.Remove(id);
            return Task.CompletedTask;
        }

        public Task<RSVP> GetAsync(int id)
        {
            return Task.FromResult(_items[id]);
        }

        public Task UpdateAsync(RSVP item)
        {
            _items[item.Id] = item;
            return Task.CompletedTask;
        }
    }
}
