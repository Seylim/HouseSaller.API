using Business.Abstracts;
using Core.Security.Hashing;
using Core.Security.Jwt;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos.Requests.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _service;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService service, ITokenHelper tokenHelper)
        {
            _service = service;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            var claims = await _service.GetOperationClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);

            return new SuccessDataResult<AccessToken>(Messages.CreatedAccessToken, accessToken);
        }

        public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _service.GetUserByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound, null);
            }

            if (!HashingHelper.VerifyPasswordhash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError, null);
            }

            return new SuccessDataResult<User>(userToCheck);
        }

        public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = true
            };
            var addeduser = await _service.AddUser(user);
            return new SuccessDataResult<User>(Messages.UserRegistered, user);
        }

        public async Task<IResult> UserExist(string email)
        {
            if (await _service.GetUserByMail(email) != null)
            {
                return new ErrorResult(Messages.UserNotAvailable);
            }
            return new SuccessResult(Messages.UserAvailable);
        }
    }
}
