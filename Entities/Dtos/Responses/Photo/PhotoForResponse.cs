using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Responses.Photo
{
    public class PhotoForResponse
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime AddedTime { get; set; }
        public string PublicId { get; set; }
    }
}
