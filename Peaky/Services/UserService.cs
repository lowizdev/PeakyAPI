using Peaky.Models;
using Peaky.Models.DTOs;
using Peaky.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Services
{
    public class UserService: IUserService
    {

        private IHashing _hasher = null;
        private IUserRepository _repository = null;

        public UserService(IHashing hasher, IUserRepository repository)
        {
            this._hasher = hasher;
            this._repository = repository;
        }

        public async Task<User> Create(CreateUserDTO dto) { //TODO: PASS AS DTO?

            if (dto.name != "") {

                User user = new User();
                
                user.name = dto.name;
                user.email = dto.email;

                user.password = this._hasher.Hash(dto.password);

                await this._repository.InsertOne(user);

                //TODO: GET ONE AFTER INSERT

                user.password = "[REDACTED]";

                return user;

            }

            return null;

        }

        public async Task<AuthDTO> Login(LoginDTO dto) {

            var user = await this._repository.GetOneByEmail(dto.email);

            if (user != null) {

                bool authenticated = this._hasher.Verify(dto.password, user.password);

                if (authenticated) {

                    var jwt = TokenService.GenerateTokenAsString(user); //TODO: INJECT AS DEPENDENCY

                    AuthDTO result = new AuthDTO();

                    result.jwt = jwt;

                    return result;
                
                }

            }

            return null;
        
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> ReadById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
