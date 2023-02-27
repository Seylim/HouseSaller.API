using DataAccess.Abstracts.Repositories;
using DataAccess.Data;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Concretes.EfRepositories
{
    public class EfDistrictRepository : IDistrictRepository
    {
        private readonly HouseSallerDbContext _context;

        public EfDistrictRepository(HouseSallerDbContext context)
        {
            _context = context;
        }

        public District Add(District entity)
        {
            _context.Districts.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<District> AddAsync(District entity)
        {
            await _context.Districts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            var district = _context.Districts.FirstOrDefault(d => d.Id == id);
            _context.Districts.Remove(district);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var district = await _context.Districts.FirstOrDefaultAsync(d => d.Id == id);
            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();
        }

        public ICollection<District> GetAll()
        {
            var districts = _context.Districts.Include(d => d.City).Include(d => d.ParentDistrict).Include(d => d.SubDistricts).Include(d => d.SubDistricts).ToList();
            return districts;
        }

        public async Task<ICollection<District>> GetAllAsync()
        {
            var districts = await _context.Districts.Include(d => d.City).Include(d => d.ParentDistrict).Include(d => d.SubDistricts).Include(d => d.SubDistricts).ToListAsync();
            return districts;
        }

        public District GetById(int id)
        {
            var district = _context.Districts.Include(d => d.City).Include(d => d.ParentDistrict).Include(d => d.SubDistricts).Include(d => d.SubDistricts).FirstOrDefault(d => d.Id == id);
            return district;
        }

        public async Task<District> GetByIdAsync(int? id)
        {
            var district = await _context.Districts.Include(d => d.City).Include(d => d.ParentDistrict).Include(d => d.SubDistricts).Include(d => d.SubDistricts).FirstOrDefaultAsync(d => d.Id == id);
            return district;
        }

        public async Task<IList<District>> GetDistrictByCityIdAsync(int cityId)
        {
            var districts = await _context.Districts.Where(d => d.CityId == cityId).Include(d => d.City).Include(d => d.ParentDistrict).Include(d => d.SubDistricts).Include(d => d.SubDistricts).ToListAsync();
            return districts;
        }

        public async Task<District> GetDistrictByNameAsync(string name)
        {
            var district = await _context.Districts.Where(d => d.Name == name).Include(d => d.City).Include(d => d.ParentDistrict).Include(d => d.SubDistricts).Include(d => d.SubDistricts).FirstOrDefaultAsync();
            return district;
        }

        public async Task<District> GetParentDistrictByDistrictIdAsync(int districtId)
        {
            var district = await _context.Districts.Where(d => d.Id == districtId).Include(d => d.City).Include(d => d.ParentDistrict).Include(d => d.SubDistricts).Include(d => d.SubDistricts).FirstOrDefaultAsync();
            return district.ParentDistrict;
        }

        public async Task<IList<District>> GetSubDistrictsByDistrictIdAsync(int districtId)
        {
            var district = await _context.Districts.Where(d => d.Id == districtId).Include(d => d.City).Include(d => d.ParentDistrict).Include(d => d.SubDistricts).Include(d => d.SubDistricts).FirstOrDefaultAsync();
            return district.SubDistricts;
        }

        public District Update(District entity)
        {
            _context.Districts.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<District> UpdateAsync(District entity)
        {
            _context.Districts.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
