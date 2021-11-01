using System;
using Accounting.API.Common;
using Accounting.API.ViewModels;
using Accounting.Application;
using Accounting.Application.Domain.Account;
using Accounting.Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.API.Controllers
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
    }
}