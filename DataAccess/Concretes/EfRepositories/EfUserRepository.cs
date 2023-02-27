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
    public class EfUserRepository : IUserRepository
    {
        private readonly HouseSallerDbContext _context;

        public EfUserRepository(HouseSallerDbContext context)
        {
            _context = context;
        }

        public User Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<User> AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(usr => usr.Id == id);
            user.IsActive = false;
            Update(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(usr => usr.Id == id);
            user.IsActive = false;
            await UpdateAsync(user);
        }

        public ICollection<User> GetAll()
        {
            var users = _context.Users.Include(usr => usr.UserOperationClaims).ToList();
            return users;
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            var users = await _context.Users.Include(usr => usr.UserOperationClaims).ToListAsync();
            return users;
        }

        public User GetById(int id)
        {
            var user = _context.Users.Where(usr => usr.Id == id).Include(usr => usr.UserOperationClaims).FirstOrDefault();
            return user;
        }

        public async Task<User> GetByIdAsync(int? id)
        {
            var user = await _context.Users.Where(usr => usr.Id == id).Include(usr => usr.UserOperationClaims).FirstOrDefaultAsync();
            return user;
        }

        public async Task<IList<OperationClaim>> GetOperationClaims(User user)
        {
            var operationClaimsResult = from operationClaim in _context.OperationClaims
                                  join userOperationClaim in _context.UserOperationClaims
                                  on operationClaim.Id equals userOperationClaim.Id
                                  where userOperationClaim.UserId == user.Id
                                  select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name, };
            return await operationClaimsResult.ToListAsync();
        }

        public async Task<User> GetUserByMail(string email)
        {
            var user = await _context.Users.Where(usr => usr.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public User Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
