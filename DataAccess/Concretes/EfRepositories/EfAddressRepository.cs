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
    public class EfAddressRepository : IAddressRepository
    {
        private readonly HouseSallerDbContext _context;

        public EfAddressRepository(HouseSallerDbContext context)
        {
            _context = context;
        }

        public Address Add(Address entity)
        {
            _context.Addresses.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<Address> AddAsync(Address entity)
        {
            await _context.Addresses.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            var address = _context.Addresses.FirstOrDefault(a => a.Id == id);
            address.IsActive = false;
            Update(address);
        }

        public async Task DeleteAsync(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
            address.IsActive = false;
            await UpdateAsync(address);
        }

        public async Task<IList<Address>> GetAddressesByIsActiveAsync()
        {
            var addresses = await _context.Addresses.Where(a => a.IsActive == true).Include(a => a.City).Include(a => a.SubDistrict).Include(a => a.Ads).ToListAsync();
            return addresses;
        }

        public ICollection<Address> GetAll()
        {
            var addresses = _context.Addresses.Include(a => a.City).Include(a => a.SubDistrict).Include(a => a.Ads).ToList();
            return addresses;
        }

        public async Task<ICollection<Address>> GetAllAsync()
        {
            var addresses = await _context.Addresses.Include(a => a.City).Include(a => a.SubDistrict).Include(a => a.Ads).ToListAsync();
            return addresses;
        }

        public Address GetById(int id)
        {
            var address = _context.Addresses.Include(a => a.City).Include(a => a.SubDistrict).Include(a => a.Ads).FirstOrDefault(a => a.Id == id);
            return address;
        }

        public async Task<Address> GetByIdAsync(int? id)
        {
            var address = await _context.Addresses.Include(a => a.City).Include(a => a.SubDistrict).Include(a => a.Ads).FirstOrDefaultAsync(a => a.Id == id);
            return address;
        }

        public Address Update(Address entity)
        {
            _context.Addresses.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<Address> UpdateAsync(Address entity)
        {
            _context.Addresses.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
