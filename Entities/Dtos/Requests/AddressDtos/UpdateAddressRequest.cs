﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Requests.AddressDtos
{
    public class UpdateAddressRequest
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int SubDistrictId { get; set; }
        public string Details { get; set; }
        public bool IsActive { get; set; }
    }
}
