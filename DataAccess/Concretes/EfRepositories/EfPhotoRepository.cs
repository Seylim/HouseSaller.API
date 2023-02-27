using Core.Entities.Concrete;
using DataAccess.Abstracts.Repositories;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Concretes.EfRepositories
{
    public class EfPhotoRepository : IPhotoRepository
    {
        private readonly HouseSallerDbContext _context;

        public EfPhotoRepository(HouseSallerDbContext context)
        {
            _context = context;
        }

        public Photo Add(Photo entity)
        {
            _context.Photos.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<Photo> AddAsync(Photo entity)
        {
            await _context.Photos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
                _context.SaveChanges();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
                await _context.SaveChangesAsync();
            }
        }

        public ICollection<Photo> GetAll()
        {
            var photos = _context.Photos.Include(p => p.Ad).ToList();
            return photos;
        }

        public async Task<ICollection<Photo>> GetAllAsync()
        {
            var photos = await _context.Photos.Include(p => p.Ad).ToListAsync();
            return photos;
        }

        public Photo GetById(int id)
        {
            var photo = _context.Photos.Include(p => p.Ad).FirstOrDefault(p => p.Id == id);
            return photo;
        }

        public async Task<Photo> GetByIdAsync(int? id)
        {
            var photo = await _context.Photos.Include(p => p.Ad).FirstOrDefaultAsync(p => p.Id == id);
            return photo;
        }

        public async Task<IList<Photo>> GetPhotosByAdId(int adId)
        {
            var photos = await _context.Photos.Where(p => p.AdId == adId).Include(p => p.Ad).ToListAsync();
            return photos;
        }

        public Photo Update(Photo entity)
        {
            _context.Photos.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<Photo> UpdateAsync(Photo entity)
        {
            _context.Photos.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
