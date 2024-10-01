using SubscriptionSaaSManager.Application.DTOS;
using SubscriptionSaaSManager.Application.Interfaces;
using SubscriptionSaaSManager.Application.Utils;
using SubscriptionSaaSManager.Domain.Entities;
using SubscriptionSaaSManager.InfraData.Interfaces;

namespace SubscriptionSaaSManager.Application.UserCases
{
    public class TenantBusiness(ITenantyRepository repository) : ITenantService
    {
        private readonly ITenantyRepository _repository = repository;

        public async Task<ApiResponse<int>> Add(object dto)
        {
            ApiResponse<int> response = new();
            var tenantDTO = (TenantDTO)dto;
            try
            {
                Tenant entity = new(
                name: tenantDTO.Name,
                uiid: tenantDTO.UIID,
                createAt: tenantDTO.CreateAt,
                id: null);


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
                bool deleted = await _repository.Delete(id);
                response.Sucess(deleted, deleted ? Constants.DeletedSuccessfully : Constants.DeletedSuccessfully);
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
                bool deleted = await _repository.Delete(guid);
                response.Sucess(deleted, deleted ? Constants.DeletedSuccessfully : Constants.FailedToDelete);
            }
            catch (Exception ex)
            {
                response.Failure(false, 400, exception: ex);
            }
            return response;
        }

        public async Task<ApiResponse<Tenant>> Get(int id)
        {
            ApiResponse<Tenant> response = new();
            try
            {
                Tenant tenant = await _repository.Get(id);
                response.Sucess(tenant, tenant != null ? Constants.Found : Constants.NotFound);
            }
            catch (Exception ex)
            {
                response.Failure(null, 400, exception: ex);
            }
            return response;
        }

        public async Task<ApiResponse<Tenant>> Get(Guid guid)
        {
            ApiResponse<Tenant> response = new();
            try
            {
                Tenant tenant = await _repository.Get(guid);
                response.Sucess(tenant, tenant != null ? Constants.Found : Constants.NotFound);
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
            var tenantDTO = (TenantDTO)dto;
            try
            {
                Tenant entity = new(
                name: tenantDTO.Name,
                uiid: tenantDTO.UIID,
                createAt: tenantDTO.CreateAt,
                id: tenantDTO.Id);

                bool updated = await _repository.Update(entity);
                response.Sucess(updated, updated ? Constants.UpdatedSuccessfully : Constants.FailedToUpdate);
            }
            catch (Exception ex)
            {
                response.Failure(false, 400, exception: ex);
            }
            return response;
        }
    }
}