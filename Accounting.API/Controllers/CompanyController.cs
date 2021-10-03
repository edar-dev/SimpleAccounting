using System;
using Accounting.API.Common;
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

        public CompanyController(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        [HttpPost]
        [RateLimitDecorator(StrategyType = StrategyTypeEnum.IpAddress)]
        public ActionResult<CompanyDto> CreateCompany(CreateCompanyViewModel createCompanyViewModel)
        {

            var createCompanyDto = _mapper.Map<CreateCompanyDto>(createCompanyViewModel);
            return BadRequest();
        }
    }
}