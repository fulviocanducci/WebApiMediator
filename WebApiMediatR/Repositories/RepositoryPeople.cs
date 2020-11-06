using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApiMediatR.Commands;
using WebApiMediatR.Data;
using WebApiMediatR.Models;

namespace WebApiMediatR.Repositories
{
    public class RepositoryPeople : IRepositoryPeople
    {
        private readonly BasemediatorContext Context;
        private readonly DbSet<People> Command;
        public RepositoryPeople(BasemediatorContext context)
        {
            Context = context;
            Command = context.Set<People>();
        }


        public async Task<People> AddAsync(People model)
        {
            Command.Add(model);
            await Context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteAsync(params object[] keys)
        {
            People people = await FindAsync(keys);
            if (people != null)
            {
                Command.Remove(people);
                return await Context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<People> FindAsync(params object[] keys)
        {
            return await Command.FindAsync(keys);
        }

        public async Task<TResult> FindAsync<TResult>(Expression<Func<People, bool>> where, Expression<Func<People, TResult>> select)
        {
            return await Command.Where(where).Select(select).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<People>> GetAsync()
        {
            return await Command.ToListAsync();
        }

        public async Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<People, TResult>> select)
        {
            return await Command.Select(select).ToListAsync();
        }

        public async Task<bool> UpdateAsync(People model)
        {
            Command.Update(model);
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
