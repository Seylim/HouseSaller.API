using DataAccess.Abstracts.Repositories;
using DataAccess.Data;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EfRepositories
{
    public class EfUserOperationClaimRepository : IUserOperationClaimRepository
    {
        private readonly HouseSallerDbContext _context;

        public EfUserOperationClaimRepository(HouseSallerDbContext context)
        {
            _context = context;
        }

        public UserOperationClaim Add(UserOperationClaim entity)
        {
            _context.UserOperationClaims.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<UserOperationClaim> AddAsync(UserOperationClaim entity)
        {
            await _context.UserOperationClaims.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            var userOperationClaim = _context.UserOperationClaims.FirstOrDefault(c => c.Id == id);
            _context.UserOperationClaims.Remove(userOperationClaim);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var userOperationClaim = await _context.UserOperationClaims.FirstOrDefaultAsync(c => c.Id == id);
            _context.UserOperationClaims.Remove(userOperationClaim);
            await _context.SaveChangesAsync();
        }

        public ICollection<UserOperationClaim> GetAll()
        {
            var userOperationClaims = _context.UserOperationClaims.Include(uoc => uoc.User).Include(uoc => uoc.OperationClaim).ToList();
            return userOperationClaims;
        }

        public async Task<ICollection<UserOperationClaim>> GetAllAsync()
        {
            var userOperationClaims = await _context.UserOperationClaims.Include(uoc => uoc.User).Include(uoc => uoc.OperationClaim).ToListAsync();
            return userOperationClaims;
        }

        public UserOperationClaim GetById(int id)
        {
            var userOperationClaim = _context.UserOperationClaims.Where(uoc => uoc.Id == id).Include(uoc => uoc.User).Include(uoc => uoc.OperationClaim).FirstOrDefault();
            return userOperationClaim;
        }

        public async Task<UserOperationClaim> GetByIdAsync(int? id)
        {
            var userOperationClaim = await _context.UserOperationClaims.Where(uoc => uoc.Id == id).Include(uoc => uoc.User).Include(uoc => uoc.OperationClaim).FirstOrDefaultAsync();
            return userOperationClaim;
        }

        public UserOperationClaim Update(UserOperationClaim entity)
        {
            _context.UserOperationClaims.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<UserOperationClaim> UpdateAsync(UserOperationClaim entity)
        {
            _context.UserOperationClaims.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
