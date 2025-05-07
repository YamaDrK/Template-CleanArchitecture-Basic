using Application.Commons;
using Application.Commons.Exceptions;
using Application.DTOs.Users;
using Application.Interfaces.Base;
using Application.Interfaces.Services;
using Application.Utils;
using AutoMapper;
using Domain.Enums;
using Domain.Models;

namespace Infrastructure.Implements.Services
{
    public class AuthService(IUnitOfWork _unitOfWork, IMapper _mapper, AppConfiguration configuration) : IAuthService
    {
        public async Task<string> LoginAsync(LoginUserDTO loginUserDTO)
        {
            var loginUser = _mapper.Map<User>(loginUserDTO);
            loginUser.TryValidate();

            bool isEmailExist = await _unitOfWork.UserRepository.IsEmailExistAsync(loginUser.Email);
            if (!isEmailExist) {
                throw new InvalidDataException("Email or password is incorrect");
            }

            var user = await _unitOfWork.UserRepository.GetByEmailAsync(loginUser.Email);
            if (user == null || !CryptoUtil.IsPasswordCorrect(loginUser.Password, user.Password))
            {
                throw new InvalidDataException("Email or password is incorrect");
            }

            return user!.GenerateJWT(configuration.JwtConfig);
        }

        public async Task RegisterAsync(RegisterUserDTO registerUserDTO)
        {
            var user = _mapper.Map<User>(registerUserDTO);
            user.TryValidate();

            if (await _unitOfWork.UserRepository.IsEmailExistAsync(user.Email))
            {
                throw new DataConflictException(typeof(User), nameof(User.Email));
            }

            user.Password = CryptoUtil.EncryptPassword(user.Password);
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
