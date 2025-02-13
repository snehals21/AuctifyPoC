using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class IdeaRepository(AppDbContext dbContext) : IdeaInterface
    {
        // This is the repository class where we have implemented the interface in this class.
        public async Task<IEnumerable<IdeaEntity>> GetIdeas()
        {
            return await dbContext.Ideas.ToListAsync();
        }

        public async Task<IdeaEntity> CreateIdea(IdeaEntity idea)
        {
            dbContext.Ideas.Add(idea);
            await dbContext.SaveChangesAsync();
            return idea;
        }

        public async Task<IEnumerable<IdeaEntity>> GetIdeasByCategory(int id)
        {
            var ideas = await dbContext.Ideas
                        .Where(i => i.CategoryId == id)
                        .ToListAsync();

            return ideas;
        }
    }
}
