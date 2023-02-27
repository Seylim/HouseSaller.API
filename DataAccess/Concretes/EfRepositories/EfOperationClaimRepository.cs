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
    public class EfOperationClaimRepository : IOperationClaimRepository
    {
        private readonly HouseSallerDbContext _context;

        public EfOperationClaimRepository(HouseSallerDbContext context)
        {
            _context = context;
        }

        public OperationClaim Add(OperationClaim entity)
        {
            _context.OperationClaims.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<OperationClaim> AddAsync(OperationClaim entity)
        {
            await _context.OperationClaims.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            var operationClaim = _context.OperationClaims.FirstOrDefault(oc => oc.Id == id);
            _context.OperationClaims.Remove(operationClaim);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var operationClaim = await _context.OperationClaims.FirstOrDefaultAsync(oc => oc.Id == id);
            _context.OperationClaims.Remove(operationClaim);
            await _context.SaveChangesAsync();
        }

        public ICollection<OperationClaim> GetAll()
        {
            var operationClaims = _context.OperationClaims.Include(oc => oc.UserOperationClaims).ToList();
            return operationClaims;
        }

        public async Task<ICollection<OperationClaim>> GetAllAsync()
        {
            var operationClaims = await _context.OperationClaims.Include(oc => oc.UserOperationClaims).ToListAsync();
            return operationClaims;
        }

        public OperationClaim GetById(int id)
        {
            var operationClaim = _context.OperationClaims.Where(oc => oc.Id == id).Include(oc => oc.UserOperationClaims).FirstOrDefault();
            return operationClaim;
        }

        public async Task<OperationClaim> GetByIdAsync(int? id)
        {
            var operationClaim = await _context.OperationClaims.Where(oc => oc.Id == id).Include(oc => oc.UserOperationClaims).FirstOrDefaultAsync();
            return operationClaim;
        }

        public OperationClaim Update(OperationClaim entity)
        {
            _context.OperationClaims.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<OperationClaim> UpdateAsync(OperationClaim entity)
        {
            _context.OperationClaims.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
