using System;

namespace Accounting.Application.Domain.Exceptions
{
    public enum ApplicationExceptionErrorCode
    {
        AccountPlanItemInvalidParent = 0
    }
    public class AccountingApplicationException : Exception
    {
        public ApplicationExceptionErrorCode ErrorCode { get; }

        public AccountingApplicationException(string message,ApplicationExceptionErrorCode errorCode ) : base(message)
        {
            ErrorCode = errorCode;
        }
        
    }
}