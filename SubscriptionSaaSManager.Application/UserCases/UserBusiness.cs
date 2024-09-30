using SubscriptionSaaSManager.Application.DTOS;
using SubscriptionSaaSManager.Application.Interfaces;
using SubscriptionSaaSManager.Application.Utils;
using SubscriptionSaaSManager.Domain.Entities;
using SubscriptionSaaSManager.InfraData.Interfaces;
using System;

namespace SubscriptionSaaSManager.Application.UserCases
{
    public class UserBusiness(IUserRepository repository) : IUserService
    {
        private readonly IUserRepository _repository = repository;

        public async Task<ApiResponse<int>> Add(object dto)
        {
            ApiResponse<int> response = new();
            var userDTO = (UserDTO)dto;
            User entity = new(
                username: userDTO.Username,
                passwordHash: userDTO.PasswordHash,
                email: userDTO.Email,
                tenantId: userDTO.TenantId.Value,
                uiid: userDTO.UIID,
                createAt: userDTO.CreateAt,
                id: null);
            try
            {
                int id = await _repository.Add(entity);
                if (id > 0)
                    response.Sucess(id, Constants.AddedSuccessfully);
                return response;

            }
            catch (Exception ex)
            {
                response.Failure(0, 400, exception: ex);
                return response;
            }
        }
        public async Task<ApiResponse<bool>> Delete(int id)
        {
            ApiResponse<bool> response = new();
            try
            {
                // Tenta deletar o usuário
                bool result = await _repository.Delete(id);
                if (result)
                {
                    response.Sucess(result, Constants.DeletedSuccessfully);
                }
                else
                {
                    response.Failure(false, 404, "User not found.");
                }
            }
            catch (Exception ex)
            {
                response.Failure(false, 400, exception: ex);
            }
            return response;
        }

        public async Task<ApiResponse<bool>> Delete(Guid guid)
        {
            ApiResponse<bool> response = new();
            try
            {
                // Tenta deletar o usuário pelo GUID
                bool result = await _repository.Delete(guid);
                if (result)
                {
                    response.Sucess(result, Constants.DeletedSuccessfully);
                }
                else
                {
                    response.Failure(false, 404, "User not found.");
                }
            }
            catch (Exception ex)
            {
                response.Failure(false, 400, exception: ex);
            }
            return response;
        }

        public async Task<ApiResponse<User>> Get(int id)
        {
            ApiResponse<User> response = new();
            try
            {
                // Obtém o usuário pelo ID
                User user = await _repository.Get(id);
                if (user != null)
                {
                    response.Sucess(user, Constants.NotFound);
                }
                else
                {
                    response.Failure(null, 404, "User not found.");
                }
            }
            catch (Exception ex)
            {
                response.Failure(null, 400, exception: ex);
            }
            return response;
        }

        public async Task<ApiResponse<User>> Get(Guid guid)
        {
            ApiResponse<User> response = new();
            try
            {
                // Obtém o usuário pelo GUID
                User user = await _repository.Get(guid);
                if (user != null)
                {
                    response.Sucess(user, Constants.NotFound);
                }
                else
                {
                    response.Failure(null, 404, "User not found.");
                }
            }
            catch (Exception ex)
            {
                response.Failure(null, 400, exception: ex);
            }
            return response;
        }

        public async Task<ApiResponse<bool>> Update(object dto)
        {
            ApiResponse<bool> response = new();
            var userDTO = (UserDTO)dto;
            User entity = new(
                username: userDTO.Username,
                passwordHash: userDTO.PasswordHash,
                email: userDTO.Email,
                tenantId: userDTO.TenantId.Value,
                uiid: userDTO.UIID,
                createAt: userDTO.CreateAt,
                id: userDTO.Id);
            try
            {
                // Atualiza o usuário no repositório
                bool result = await _repository.Update(entity);
                if (result)
                {
                    response.Sucess(result, Constants.UpdatedSuccessfully);
                }
                else
                {
                    response.Failure(false, 404, "User not found.");
                }
            }
            catch (Exception ex)
            {
                response.Failure(false, 400, exception: ex);
            }
            return response;
        }

        public async Task<ApiResponse<User>> ValidateUserCredentials(string email, string password)
        {
            ApiResponse<User> response = new();
            try
            {
                // Tenta deletar o usuário pelo GUID
                var result = await _repository.GetByEmail(email);
                if (result is not null && result.PasswordHash.Equals(password))
                {
                    response.Sucess(result, "Login com sucesso");
                }
                else
                {
                    response.Failure(null, 404, "Email ou senha incorreta");
                }
            }
            catch (Exception ex)
            {
                response.Failure(null, 400, exception: ex);
            }
            return response;
        }
    }
}