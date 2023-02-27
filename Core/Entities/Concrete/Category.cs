using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Category : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsActive { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual IList<Category> SubCategories { get; set; }
        public virtual List<Ad> Ads { get; set; }
    }
}
