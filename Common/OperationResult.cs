namespace DayTracker.Common
{
    internal class OperationResult<T>
    {
        public bool IsSuccess { get; }
        public T? Data { get; }
        public string? ErrorMsg { get; }

        private OperationResult(bool isSuccess, T? data, string? errorMsg)
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorMsg = errorMsg;
        }

        public static OperationResult<T> Success(T data) => new(true, data, null);
        public static OperationResult<T> Failure(string errorMsg) => new(false, default, errorMsg);
    }
}
