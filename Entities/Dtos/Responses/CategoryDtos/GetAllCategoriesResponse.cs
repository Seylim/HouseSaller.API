using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Responses.CategoryDtos
{
    public class GetAllCategoriesResponse
    {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
