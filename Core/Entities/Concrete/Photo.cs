using Entities.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Photo : IEntity
    {
        public int Id { get; set; }
        public int AdId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime AddedTime { get; set; }
        public string PublicId { get; set; }

        public virtual Ad Ad { get; set; }

    }
}
