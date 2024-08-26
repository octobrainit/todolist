using Microsoft.Extensions.Logging;

namespace TaskList.Business.Abstractions.Handler
{
    public abstract class BaseHandler<TInput, TOutput>
        where TInput : class
        where TOutput : class
    {
        protected ILogger<TInput> _logger;
        protected BaseResponse<TOutput> Response = new();

        public BaseHandler(
            ILogger<TInput> logger)
        {
            _logger = logger;
        }

        public abstract Task ExecuteBusiness(TInput input, CancellationToken cancellation);

        public async Task<BaseResponse<TOutput>> ExecuteAsync(TInput input, CancellationToken cancellationToken)
        {
            try
            {
                _logger.BeginScope("");
                _logger.LogInformation("starting execution of business");

                await ExecuteBusiness(input, cancellationToken);

                _logger.LogInformation("End of execution with sucess");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Some error ocurred: {ex.Message}");
                Response.SetMessage("Some unexpected error ocurred, try again later");
                throw;
            }

            return Response;
        }
    }
}
