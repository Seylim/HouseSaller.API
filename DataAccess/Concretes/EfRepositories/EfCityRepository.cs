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
    public class EfCityRepository : ICityRepository
    {
        private readonly HouseSallerDbContext _context;

        public EfCityRepository(HouseSallerDbContext context)
        {
            _context = context;
        }

        public City Add(City entity)
        {
            _context.Cities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<City> AddAsync(City entity)
        {
            await _context.Cities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Id == id);
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public ICollection<City> GetAll()
        {
            var cities = _context.Cities.Include(cty => cty.Addresses).Include(cty => cty.Districts).ToList();
            return cities;
        }

        public async Task<ICollection<City>> GetAllAsync()
        {
            var cities = await _context.Cities.Include(cty => cty.Addresses).Include(cty => cty.Districts).ToListAsync();
            return cities;
        }

        public City GetById(int id)
        {
            var city = _context.Cities.Include(cty => cty.Addresses).Include(cty => cty.Districts).FirstOrDefault(cty => cty.Id == id);
            return city;
        }

        public async Task<City> GetByIdAsync(int? id)
        {
            var city = await _context.Cities.Include(cty => cty.Addresses).Include(cty => cty.Districts).FirstOrDefaultAsync(cty => cty.Id == id);
            return city;
        }

        public async Task<City> GetCityByNameAsync(string name)
        {
            var city = await _context.Cities.Where(cty => cty.Name == name).Include(cty => cty.Addresses).Include(cty => cty.Districts).FirstOrDefaultAsync();
            return city;
        }

        public City Update(City entity)
        {
            _context.Cities.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<City> UpdateAsync(City entity)
        {
            _context.Cities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
