using System;
using System.Collections.Generic;
using System.Linq;
using Accounting.Persistence.Entity;
using BoCode.RedoDB.RedoableData;

namespace Accounting.Persistence.RedoDb
{
    public class AccountTemplateRepository : IAccountTemplateRepository, IDependsOnRedoableGuid
    {
        private readonly ICollection<ChartOfAccountTemplate> _chartOfAccountTemplates =
            new List<ChartOfAccountTemplate>();

        private IRedoableGuid? _redoableGuid;

        public Guid Create(ChartOfAccountTemplate chartOfAccountTemplate)
        {
            chartOfAccountTemplate.Id = _redoableGuid?.New() ?? Guid.NewGuid();

            AssignId(chartOfAccountTemplate.Accounts);

            _chartOfAccountTemplates.Add(chartOfAccountTemplate);

            return chartOfAccountTemplate.Id;
        }

        private void AssignId(IEnumerable<AccountTemplate> accounts)
        {
            foreach (var accountTemplate in accounts)
            {
                accountTemplate.Id = _redoableGuid?.New() ?? Guid.NewGuid();

                AssignId(accountTemplate.ChildrenAccount);
            }
        }

        public ChartOfAccountTemplate Get(Guid chartOfAccountTemplateId)
        {
            return _chartOfAccountTemplates.Single(e => e.Id == chartOfAccountTemplateId);
        }


        public void SetRedoableGuid(IRedoableGuid redoableGuid)
        {
            _redoableGuid = redoableGuid;
        }
    }
}