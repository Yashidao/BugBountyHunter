using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugBountyHunter.Tools.Commands
{
    public class CommandResult
    {
        public static CommandResult Success()
        {
            return new CommandResult(true, null, null);
        }

        public static CommandResult Failure(string errorMessage, Exception? exception = null)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentException("At least the 'errorMessage' must be set on Failure");

            return new CommandResult(false, errorMessage, exception);
        }

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

        private CommandResult(bool isSuccess, string? errorMessage = null, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Exception = exception;
        }
    }
}
