using Entities.Concretes;
using Entities.Dtos.Responses.AdDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Responses.CategoryDtos
{
    public class GetCategoryByIdResponse
    {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsActive { get; set; }

        public GetCategoryByIdResponse ParentCategory { get; set; }
        public IList<GetAllCategoriesResponse> SubCategories { get; set; }
        public List<GetAllAdsResponse> Ads { get; set; }
    }
}
