using Core.Security.Jwt;
using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos.Requests.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password);
        Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto);
        Task<IResult> UserExist(string email);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    }
}
