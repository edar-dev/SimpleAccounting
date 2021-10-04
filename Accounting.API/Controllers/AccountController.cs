using System;
using Accounting.API.Common;
using Accounting.Application;
using Accounting.Application.Domain.Account;
using Accounting.Application.Domain.Company;
using Accounting.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public AccountController(IMapper mapper, IAccountService accountService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }
        
        [HttpPost]
        [RateLimitDecorator(StrategyType = StrategyTypeEnum.IpAddress)]
        public ActionResult<AccountDto> Create(CreateAccountViewModel createAccountViewModel)
        {

            var createAccountDto = _mapper.Map<CreateAccountDto>(createAccountViewModel);

            var createdAccount = _accountService.Create(createAccountDto);
            return Ok(createdAccount);
        }
    }
}