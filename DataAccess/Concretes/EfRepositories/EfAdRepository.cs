using DataAccess.Abstracts.BaseRepositories;
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
    public class EfAdRepository : IAdRepository
    {
        private readonly HouseSallerDbContext _context;

        public EfAdRepository(HouseSallerDbContext context)
        {
            _context = context;
        }

        public Ad Add(Ad entity)
        {
            _context.Ads.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<Ad> AddAsync(Ad entity)
        {
            await _context.Ads.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            var ad = _context.Ads.FirstOrDefault(a => a.Id == id);
            ad.IsActive = false;
            _context.Ads.Update(ad);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var ad = await _context.Ads.FirstOrDefaultAsync(a => a.Id == id);
            ad.IsActive = false;
            _context.Ads.Update(ad);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Ad>> GetAdsByCategoryIdAsync(int categoryId)
        {
            var ads = await _context.Ads.Where(a => a.CategoryId == categoryId).Include(ad => ad.Category).Include(ad => ad.Address).Include(ad => ad.Photos).ToListAsync();
            return ads;
        }

        public async Task<IList<Ad>> GetAdsByIsActiveAsync()
        {
            var ads = await _context.Ads.Where(a => a.IsActive == true).Include(ad => ad.Category).Include(ad => ad.Address).Include(ad => ad.Photos).ToListAsync();
            return ads;
        }

        public async Task<IList<Ad>> GetAdsByPriceAsync(int minPrice, int maxPrice)
        {
            var ads = await _context.Ads.Where(a => a.Price >= minPrice && a.Price <= maxPrice).Include(a => a.Category).Include(a => a.Address).Include(ad => ad.Photos).ToListAsync();
            return ads;
        }

        public ICollection<Ad> GetAll()
        {
            var ads = _context.Ads.Include(ad => ad.Category).Include(ad => ad.Address).Include(ad => ad.Photos).ToList();
            return ads;
        }

        public async Task<ICollection<Ad>> GetAllAsync()
        {
            var ads = await _context.Ads.Include(ad => ad.Category).Include(ad => ad.Address).Include(ad => ad.Photos).ToListAsync();
            return ads;
        }

        public Ad GetById(int id)
        {
            var ad = _context.Ads.Include(ad => ad.Category).Include(ad => ad.Address).Include(ad => ad.Photos).FirstOrDefault(ad => ad.Id == id);
            return ad;
        }

        public async Task<Ad> GetByIdAsync(int? id)
        {
            var ad = await _context.Ads.Include(ad => ad.Category).Include(ad => ad.Address).Include(ad => ad.Photos).FirstOrDefaultAsync(ad => ad.Id == id);
            return ad;
        }

        public Ad Update(Ad entity)
        {
            _context.Ads.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<Ad> UpdateAsync(Ad entity)
        {
            _context.Ads.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
