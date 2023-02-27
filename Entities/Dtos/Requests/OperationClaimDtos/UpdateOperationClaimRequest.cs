using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Requests.OperationClaimDtos
{
    public class UpdateOperationClaimRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
