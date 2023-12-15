using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Tokens;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserDal _userDal;
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager( IUserDal userDal, ITokenHelper tokenHelper, IUserService userService)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
            _userService = userService;

        }
        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            var claims = _userDal.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token Üretildi");
        }

        public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _userDal.Get(u=>u.Email == userForLoginDto.Email && u.Status);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                UserName = userForRegisterDto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                BirthDate = userForRegisterDto.BirthDate,
                Phone = userForRegisterDto.Phone,
                Status = true,
                RegistrationDate = DateTime.UtcNow


            };
            var result =_userService.Add(user);
            if(result.Success)
            {
                return new SuccessDataResult<User>(user, Messages.UserRegistered);
            }
            else
            {
                return new ErrorDataResult<User>(user,Messages.UserRegisterError);
            }
            

        }

       

        public async Task<IResult> UserExist(string email)
        {
            if (await _userDal.Get(u => u.Email == email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        
    }
}       

