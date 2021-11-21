using Glossaries.Application.Contracts.Persistence;
using Glossaries.Domain.Entities;
using Glossaries.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glossaries.Infrastructure.Repositories
{
    public class GlossaryRepository : IGlossaryRepository
    {
        private readonly DataContext _context;

        public GlossaryRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Glossary>> GetAllAsync()
        {
            return await _context.Glossaries.ToListAsync();
        }

        public async Task<Glossary> GetByIdAsync(int id)
        {
            return await _context.Glossaries.FindAsync(id);
        }

        public async Task<Glossary> CreateAsync(Glossary entity)
        {
            _context.Glossaries.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Glossary entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Glossary = await _context.Glossaries.FindAsync(id);
            _context.Glossaries.Remove(Glossary);
            await _context.SaveChangesAsync();
        }

        public bool IsExist(int id)
        {
            return _context.Glossaries.Any(e => e.Id == id);
        }
    }
}
