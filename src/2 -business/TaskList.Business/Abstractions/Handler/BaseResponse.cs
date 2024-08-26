namespace TaskList.Business.Abstractions.Handler
{
    public class BaseResponse<TOutput> where TOutput : class
    {
        public TOutput? Data { get; private set; }
        public IList<string>? ErrorMessages { get; private set; } = new List<string>();
        public bool Error { get { return ErrorMessages.Any(); } }

        public void SetData(TOutput output) => Data = output;
        public void SetMessage(string message)
        {
            ErrorMessages ??= [];
            ErrorMessages.Add(message);
        }
    }
}
