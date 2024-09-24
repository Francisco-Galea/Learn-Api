using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models.DTOs.Request;
using TestApi.Models.DTOs.Response;
using TestApi.Models.Entities;
using TestApi.Repositories.IRepository;

namespace TestApi.Services
{
    public class UserService
    {

        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task CreateUser(UserRequest userRequest)
        {
            var user = mapper.Map<User>(userRequest);
            user.IsUserActive = true;
            await userRepository.Insert(user);
        }

        public async Task UpdateUser(int id, UserRequest userRequest)
        {
            var userExist = await userRepository.GetById(id);
            if (userExist == null)
            {
                throw new KeyNotFoundException("Usuario no encontrado");
            }
            else
            {
                mapper.Map(userRequest, userExist);
                await userRepository.Update(userExist);
            }
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            var user = await userRepository.GetById(id);
            if (user == null)
            {
                throw new KeyNotFoundException("Usuario no encontrado");
            }
            else
            {
                return mapper.Map<UserResponse>(user);
            }
        }

        public async Task<List<UserResponse>> GetAllUsers()
        {
            var users = await userRepository.GetAll();
            return mapper.Map<List<UserResponse>>(users);
        }

        public async Task DeactivateUser(int id)
        {
            var user = await userRepository.GetById(id);
            if (user == null)
            {
                throw new KeyNotFoundException("Usuario no encontrado");
            }
            else
            {
                user.IsUserActive = false;
                await userRepository.Update(user);
            }
        }

    }
}
