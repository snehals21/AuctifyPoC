using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class IdeaService
    {
        private readonly IdeaInterface _repository;

        // This is the constructor of service class.
        public IdeaService(IdeaInterface repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IdeaEntity>> GetIdeas()
        {
            return await _repository.GetIdeas();
        }

        public async Task<IdeaEntity> CreateIdea(IdeaEntity ideaEntity)
        {
            return await _repository.CreateIdea(ideaEntity);
        }

        public async Task<IEnumerable<IdeaEntity>> GetIdeasByCategory(int id)
        {
            return await _repository.GetIdeasByCategory(id);
        }
    }
}
