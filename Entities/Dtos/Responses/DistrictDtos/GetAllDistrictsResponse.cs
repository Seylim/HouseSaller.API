﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Responses.DistrictDtos
{
    public class GetAllDistrictsResponse
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int? ParendDistrictId { get; set; }
        public string Name { get; set; }
    }
}
