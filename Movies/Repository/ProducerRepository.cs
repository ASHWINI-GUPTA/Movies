using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;

namespace Movies.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly DBContext _context;

        public ProducerRepository(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<Producer> Get()
        {
            return _context.Producers.AsNoTracking();
        }

        public Producer Get(int id)
        {
            return _context.Producers.AsNoTracking()
                .SingleOrDefault(m => m.Id == id);
        }

        public void Create(Producer producer)
        {
            _context.Add(producer);
            _context.SaveChanges();
        }
    }
}
