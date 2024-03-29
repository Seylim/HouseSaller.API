﻿using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);
    }
}
