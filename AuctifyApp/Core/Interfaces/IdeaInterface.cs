using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IdeaInterface
    {
        // This is the interface class which contains the abstract methods. this class wll be implemented in the repository class.
        Task<IEnumerable<IdeaEntity>> GetIdeas();
        Task<IdeaEntity> CreateIdea(IdeaEntity idea);

        Task<IEnumerable<IdeaEntity>> GetIdeasByCategory(int id);
    }
}
