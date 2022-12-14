using System.Collections.Generic;

namespace KaspiTask.Core
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public IList<string> Errors { get; set; }
        public static Result<T> Success(T value) => new Result<T> {IsSuccess = true, Value = value};
        public static Result<T> Failure(IList<string> errors) => new Result<T> {IsSuccess = false, Errors = errors};
    }
}