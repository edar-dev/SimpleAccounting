using Accounting.Application.Domain.Account;

namespace Accounting.Application
{
    public interface IAccountService
    {
        AccountDto Create(CreateAccountDto createAccountDto);
    }
}