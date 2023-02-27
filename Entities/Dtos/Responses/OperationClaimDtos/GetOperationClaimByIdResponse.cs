using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Responses.OperationClaimDtos
{
    public class GetOperationClaimByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
