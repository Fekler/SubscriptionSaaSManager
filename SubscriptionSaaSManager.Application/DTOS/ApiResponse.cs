namespace SubscriptionSaaSManager.Application.DTOS
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }

        public string? Message { get; set; }

        public T? Data { get; set; }

        public int? ErrorCode { get; set; }


        public ApiResponse<T> Sucess(T data, string? message = null)
        {

            this.Success = true;
            this.Data = data;
            this.Message = message;
            return this;
        }

        public ApiResponse<T> Failure(T? data, int? errorCode = null, string? message = null,Exception? exception = null)
        {
            if (exception is not null)
            {
                message = exception.StackTrace;
            }
            this.Success = false;
            this.ErrorCode = errorCode;
            this.Message = message;
            this.Data = data;
            return this;
        }

    }

}
