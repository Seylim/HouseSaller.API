﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Requests.CategoryDtos
{
    public class AddCategoryRequest
    {
        public int? ParentCategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
