using System;
using System.Collections.Generic;

namespace hero.transversal.Results
{
    public class ApiResult<T> where T : class
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public ResultState State { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string> { };

        private ApiResult(T data, string message, ResultState state, IEnumerable<string> errors = null)
        {
            this.Data = data;
            this.Message = message;
            this.State = state;
            if(errors != null)
                this.Errors = errors;
        }


        public static ApiResult<T> Ok(T data, string message)
        {
            return new ApiResult<T>(data, message, ResultState.Ok);
        }

        public static ApiResult<T> Fail(string message, ResultState state = ResultState.BusinessValidationError)
        {
            return new ApiResult<T>(null, message, state);
        }

        public static ApiResult<T> Fail(string message, IEnumerable<string> errors, ResultState state = ResultState.BusinessValidationError, T data = null)
        {
            var result = Fail(message, state);
            result.Errors = errors;
            result.Data = data;
            return result;
        }

    }
}
