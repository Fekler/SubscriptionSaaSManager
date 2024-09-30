using SubscriptionSaaSManager.Application.DTOS;
using SubscriptionSaaSManager.Application.Interfaces;
using SubscriptionSaaSManager.Application.Utils;
using SubscriptionSaaSManager.Domain.Entities;
using SubscriptionSaaSManager.InfraData.Interfaces;
using System.Runtime.InteropServices;
using System.Web.Http;

namespace SubscriptionSaaSManager.Application.UserCases
{
    public class PermissionBusiness(IPermissionRepository repository) : IPermissionService
    {
        private readonly IPermissionRepository _repository = repository;

        public async Task<ApiResponse<int>> Add(object dto)
        {
            ApiResponse<int> response = new();
            var permissionDTO = (PermissionDTO)dto;
            Permission entity = new(
                name: permissionDTO.Name,
                userId: permissionDTO.UserId.Value,
                uiid: permissionDTO.UIID,
                createAt: permissionDTO.CreateAt,
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
                bool result = await _repository.Delete(id);
                if (result)
                {
                    response.Sucess(result, Constants.DeletedSuccessfully);
                }
                else
                {
                    response.Failure(false, 404, "Permission not found.");
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
                bool result = await _repository.Delete(guid);
                if (result)
                {
                    response.Sucess(result, Constants.DeletedSuccessfully);
                }
                else
                {
                    response.Failure(false, 404, "Permission not found.");
                }
            }
            catch (Exception ex)
            {
                response.Failure(false, 400, exception: ex);
            }
            return response;
        }

        public async Task<ApiResponse<Permission>> Get(int id)
        {
            ApiResponse<Permission> response = new();
            try
            {
                Permission permission = await _repository.Get(id);
                if (permission != null)
                {
                    response.Sucess(permission, Constants.Found);
                }
                else
                {
                    response.Failure(null, 404, "Permission not found.");
                }
            }
            catch (Exception ex)
            {
                response.Failure(null, 400, exception: ex);
            }
            return response;
        }

        public async Task<ApiResponse<Permission>> Get(Guid guid)
        {
            ApiResponse<Permission> response = new();
            try
            {
                Permission permission = await _repository.Get(guid);
                if (permission != null)
                {
                    response.Sucess(permission, Constants.Found);
                }
                else
                {
                    response.Failure(null, 404, "Permission not found.");
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
            var permissionDTO = (PermissionDTO)dto;
            Permission entity = new(
                name: permissionDTO.Name,
                userId: permissionDTO.UserId.Value,
                uiid: permissionDTO.UIID,
                createAt: permissionDTO.CreateAt,
                id: permissionDTO.Id);

            try
            {
                bool result = await _repository.Update(entity);
                if (result)
                {
                    response.Sucess(result, Constants.UpdatedSuccessfully);
                }
                else
                {
                    response.Failure(false, 404, "Permission not found.");
                }
            }
            catch (Exception ex)
            {
                response.Failure(false, 400, exception: ex);
            }
            return response;
        }
    }
}


