using SubscriptionSaaSManager.Application.DTOS;
using SubscriptionSaaSManager.Application.Interfaces;
using SubscriptionSaaSManager.Application.Utils;
using SubscriptionSaaSManager.Domain.Entities;
using SubscriptionSaaSManager.InfraData.Interfaces;
using static SubscriptionSaaSManager.Domain.Utils.Enums;

namespace SubscriptionSaaSManager.Application.UserCases
{
    public class SubscriptionBusiness(ISubscriptionRepository repository) : ISubscriptionService
    {
        private readonly ISubscriptionRepository _repository = repository;

        public async Task<ApiResponse<int>> Add(object dto)
        {
            ApiResponse<int> response = new();
            var subscriptionDTO = (SubscriptionDTO)dto;
            try
            {
                Subscription entity = new(
                name: subscriptionDTO.Name,
                price: subscriptionDTO.Price.Value,
                startDate: subscriptionDTO.StartDate.Value,
                endDate: subscriptionDTO.EndDate.Value,
                userId: subscriptionDTO.UserId.Value,
                frequency: (BillingFrequency)subscriptionDTO.Frequency.Value,
                uiid: subscriptionDTO.UIID,
                createAt: subscriptionDTO.CreateAt,
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
                bool result = await _repository.Delete(id);
                if (result)
                {
                    response.Sucess(result, Constants.DeletedSuccessfully);
                }
                else
                {
                    response.Failure(false, 404, "Subscription not found.");
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
                    response.Failure(false, 404, "Subscription not found.");
                }
            }
            catch (Exception ex)
            {
                response.Failure(false, 400, exception: ex);
            }
            return response;
        }

        public async Task<ApiResponse<Subscription>> Get(int id)
        {
            ApiResponse<Subscription> response = new();
            try
            {
                Subscription subscription = await _repository.Get(id);
                if (subscription != null)
                {
                    response.Sucess(subscription, Constants.Found);
                }
                else
                {
                    response.Failure(null, 404, "Subscription not found.");
                }
            }
            catch (Exception ex)
            {
                response.Failure(null, 400, exception: ex);
            }
            return response;
        }

        public async Task<ApiResponse<Subscription>> Get(Guid guid)
        {
            ApiResponse<Subscription> response = new();
            try
            {
                Subscription subscription = await _repository.Get(guid);
                if (subscription != null)
                {
                    response.Sucess(subscription, Constants.Found);
                }
                else
                {
                    response.Failure(null, 404, "Subscription not found.");
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
            var subscriptionDTO = (SubscriptionDTO)dto;
            try
            {
                Subscription entity = new(
                name: subscriptionDTO.Name,
                price: subscriptionDTO.Price.Value,
                startDate: subscriptionDTO.StartDate.Value,
                endDate: subscriptionDTO.EndDate.Value,
                userId: subscriptionDTO.UserId.Value,
                frequency: (BillingFrequency)subscriptionDTO.Frequency.Value,
                uiid: subscriptionDTO.UIID,
                createAt: subscriptionDTO.CreateAt,
                id: subscriptionDTO.Id.Value);


                bool result = await _repository.Update(entity);
                if (result)
                {
                    response.Sucess(result, Constants.UpdatedSuccessfully);
                }
                else
                {
                    response.Failure(false, 404, "Subscription not found.");
                }
            }
            catch (Exception ex)
            {
                response.Failure(false, 400, message: ex.Message, exception: ex);
            }
            return response;
        }
    }
}