using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Requests.Photo
{
    public class PhotoForCreationRequest
    {
        public IFormFile File { get; set; }
        public string Description { get; set; }
    }
}
