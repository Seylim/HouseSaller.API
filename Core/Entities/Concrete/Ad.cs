using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstracts;
using Core.Entities.Concrete;

namespace Entities.Concretes
{
    public class Ad : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsActive { get; set; }


        public virtual Category Category { get; set; }
        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual IList<Photo> Photos { get; set; }
    }
}
