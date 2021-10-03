using System;
using Accounting.API.Common;
using Accounting.Application;
using Accounting.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Accounting.Application.Domain.Company;
using AutoMapper;

namespace Accounting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public CompanyController(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
        }
        
        [HttpPost]
        [RateLimitDecorator(StrategyType = StrategyTypeEnum.IpAddress)]
        public ActionResult<CompanyDto> CreateCompany(CreateCompanyViewModel createCompanyViewModel)
        {

            var createCompanyDto = _mapper.Map<CreateCompanyDto>(createCompanyViewModel);

            var createdCompany = _companyService.CreateNewCompany(createCompanyDto);
            return Ok(createdCompany);
        }
    }
}