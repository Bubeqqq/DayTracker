namespace DayTracker.Common
{
    internal class OperationResult
    {
        public bool IsSuccess { get; }
        public string? ErrorMsg { get; }

        protected OperationResult(bool isSuccess, string? errorMsg)
        {
            IsSuccess = isSuccess;
            ErrorMsg = errorMsg;
        }

        public static OperationResult Success() => new(true, null);
        public static OperationResult Failure(string errorMsg) => new(false, errorMsg);
    }

    internal class OperationResult<T> : OperationResult
    {
        public T? Data { get; }

        private OperationResult(bool isSuccess, T? data, string? errorMsg) : base(isSuccess, errorMsg)
        {
            Data = data;
        }

        public static OperationResult<T> Success(T data) => new(true, data, null);
        public new static OperationResult<T> Failure(string errorMsg) => new(false, default, errorMsg);
    }
}
