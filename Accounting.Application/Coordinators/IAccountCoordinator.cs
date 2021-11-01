using System;

namespace Accounting.Application.Coordinators
{
    public interface IAccountCoordinator
    {
        /// <summary>
        /// Create a chart of account from the given template
        /// </summary>
        /// <param name="templateId">The Id of the chart of account template</param>
        /// <param name="referenceId">An optional reference to a company or eventually some other internal/external entity</param>
        /// <returns>The Id of the newly created chart of account</returns>
        ///  <exception cref="InvalidOperationException">The given template Id is not found</exception>
        public Guid CreateChartOfAccountsFromTemplate(Guid templateId, DateTime openingDate, DateTime closingDate, Guid? referenceId);
    }
}