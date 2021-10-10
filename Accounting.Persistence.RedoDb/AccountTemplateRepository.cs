using System;
using System.Collections.Generic;
using System.Linq;
using Accounting.Persistence.Entity;
using BoCode.RedoDB.RedoableData;

namespace Accounting.Persistence.RedoDb
{
    public class AccountTemplateRepository : IAccountTemplateRepository, IDependsOnRedoableGuid
    {
        private readonly ICollection<ChartOfAccountTemplate> _chartOfAccountTemplates = new List<ChartOfAccountTemplate>();
        
        private IRedoableGuid? _redoableGuid;

        public Guid Create(ChartOfAccountTemplate chartOfAccountTemplate)
        {
            chartOfAccountTemplate.Id = _redoableGuid?.New() ?? Guid.NewGuid();
            
            _chartOfAccountTemplates.Add(chartOfAccountTemplate);

            return chartOfAccountTemplate.Id;
        }

        

        public void SetRedoableGuid(IRedoableGuid redoableGuid)
        {
            _redoableGuid = redoableGuid;
        }
    }
}