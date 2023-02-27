using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Requests.UserOperationClaimDtos
{
    public class AddUserOperationClaimRequest
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
