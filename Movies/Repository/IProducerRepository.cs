using System.Collections.Generic;
using Movies.Models;

namespace Movies.Repository
{
    public interface IProducerRepository
    {
        IEnumerable<Producer> Get();
        Producer Get(int id);
        void Create(Producer producer);
    }
}
