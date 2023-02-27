using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Responses.AdDtos
{
    public class GetAllAdsResponse
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AddressId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
