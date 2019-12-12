using System.Collections.Generic;
using Movies.Models;

namespace Movies.Services
{
    public interface IProducerService
    {
        IEnumerable<Producer> Get();
        Producer Get(int id);
        void Create(Producer producer);
    }
}
