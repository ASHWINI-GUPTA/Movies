using System.Collections.Generic;
using System.Linq;
using Movies.Models;
using Movies.Repository;

namespace Movies.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public IEnumerable<Producer> Get()
        {
            return _producerRepository.Get().ToList();
;        }

        public Producer Get(int id)
        {
            return _producerRepository.Get(id);
        }

        public void Create(Producer producer)
        {
            _producerRepository.Create(producer);
        }
    }
}
