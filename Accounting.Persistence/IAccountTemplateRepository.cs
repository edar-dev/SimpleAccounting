using System;
using Accounting.Persistence.Entity;

namespace Accounting.Persistence
{
    public interface IAccountTemplateRepository
    {
        Guid Create(ChartOfAccountTemplate chartOfAccountTemplate);
        
        /// <summary>
        /// Retrieve the chart of account template with the given id
        /// </summary>
        /// <param name="chartOfAccountTemplateId">The Id of the COA tempate that we want to retrieve</param>
        /// <returns>The COA template</returns>
        /// <exception cref="InvalidOperationException">A COA template with the given Id is not found</exception>
        ChartOfAccountTemplate Get(Guid chartOfAccountTemplateId);
    }
}