using System;
using Accounting.Persistence.Entity;

namespace Accounting.Persistence
{
    public interface IAccountRepository
    {
        Account Create(Account account);
        
        Account Get(Guid accountId);
    }
}