using Core.Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class HouseSallerDbContext : DbContext
    {
        public HouseSallerDbContext(DbContextOptions<HouseSallerDbContext> options) : base(options)
        {

        }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>(entity =>
            {
                entity.HasOne<Category>(ad => ad.Category).WithMany(c => c.Ads).HasForeignKey(ad => ad.CategoryId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<Address>(ad => ad.Address).WithMany(a => a.Ads).HasForeignKey(ad => ad.AddressId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<User>(ad => ad.User).WithMany(u => u.Ads).HasForeignKey(ad => ad.UserId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne<City>(a => a.City).WithMany(cty => cty.Addresses).HasForeignKey(a => a.CityId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<District>(a => a.SubDistrict).WithMany(d => d.Addresses).HasForeignKey(a => a.SubDistrictId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property<int?>(c => c.ParentCategoryId).IsRequired(false);
                entity.HasOne<Category>(c => c.ParentCategory).WithMany(c => c.SubCategories).HasForeignKey(c => c.ParentCategoryId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasOne<District>(d => d.ParentDistrict).WithMany(d => d.SubDistricts).HasForeignKey(d => d.ParendDistrictId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<City>(d => d.City).WithMany(cty => cty.Districts).HasForeignKey(d => d.CityId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<UserOperationClaim>(entity =>
            {
                entity.HasOne<User>(uoc => uoc.User).WithMany(u => u.UserOperationClaims).HasForeignKey(uoc => uoc.UserId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<OperationClaim>(uoc => uoc.OperationClaim).WithMany(oc => oc.UserOperationClaims).HasForeignKey(uoc => uoc.OperationClaimId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasOne<Ad>(p => p.Ad).WithMany(ad => ad.Photos).HasForeignKey(p => p.AdId).OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
