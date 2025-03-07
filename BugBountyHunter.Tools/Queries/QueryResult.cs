using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugBountyHunter.Tools.Queries
{
    public class QueryResult<TResult>
    {
        public static QueryResult<TResult> Success(TResult? result)
        {
            return new QueryResult<TResult>(true, result);
        }

        public static QueryResult<TResult> Failure(string errorMessage, Exception? exception = null)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentException("At least the 'errorMessage' must be set on Failure");

            return new QueryResult<TResult>(false, default, errorMessage, exception);
        }

        private readonly TResult? _result;

        public bool IsSuccess
        {
            get; init;
        }

        public bool IsFailure
        {
            get
            {
                return !IsSuccess;
            }
        }

        public string? ErrorMessage
        {
            get; init;
        }

        public Exception? Exception
        {
            get; init;
        }

        public TResult? Result
        {
            get
            {
                if (IsFailure)
                    throw new InvalidOperationException();

                return _result;
            }
        }

        internal QueryResult(bool isSuccess, TResult? result, string? errorMessage = null, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            _result = result;
            ErrorMessage = errorMessage;
            Exception = exception;
        }
    }
}
