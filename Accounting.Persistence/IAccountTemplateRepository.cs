using System;
using Accounting.Persistence.Entity;

namespace Accounting.Persistence
{
    public interface IAccountTemplateRepository
    {
        Guid Create(ChartOfAccountTemplate chartOfAccountTemplate);
    }
}