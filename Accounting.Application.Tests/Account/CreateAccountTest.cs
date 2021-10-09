using System;
using Accounting.Application.Domain.Account;
using Accounting.Application.MappingProfileApplication;
using Accounting.Persistence;
using Accounting.Persistence.RedoDb;
using AutoMapper;
using BoCode.RedoDB.Builder;
using FluentAssertions;
using Xunit;

namespace Accounting.Application.Tests.Account
{
    public class CreateAccountTest
    {
        private readonly IAccountService _accountService;

        public CreateAccountTest()
        {
            RedoDBEngineBuilder<AccountRepository, IAccountRepository> accountRepositoryBuilder = new();
            accountRepositoryBuilder.WithNoPersistence();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<AccountProfileApplication>());
            IMapper mapper = new Mapper(mapperConfig);
            _accountService = new AccountService(accountRepositoryBuilder.Build(), mapper);
        }

        [Fact]
        public void CreateRootAccount()
        {
            //SETUP
            CreateAccountDto createAccountDto = new("rootAccount", 1, AccountType.Debit, null);

            //ACT
            var accountDto = _accountService.Create(createAccountDto);

            //ASSERT
            accountDto.Name.Should().Be(createAccountDto.Name);
            accountDto.Id.Should().NotBe(Guid.Empty);
            accountDto.Number.Should().Be(createAccountDto.Number);
            accountDto.FullNumber.Should().Be("1");
            accountDto.Type.Should().Be(AccountType.Debit);
            accountDto.ParentAccountId.Should().BeNull();
            accountDto.ParentAccount.Should().BeNull();
        }
        
        [Fact]
        public void CreateChildAccount()
        {
            //SETUP
            CreateAccountDto createRootAccountDto = new("rootAccount", 1, AccountType.Debit, null);

            //ACT
            var rootaccountDto = _accountService.Create(createRootAccountDto);
            CreateAccountDto createChildAccountDto = new("childAccount", 0, AccountType.Debit, rootaccountDto.Id);
            var childaccountDto = _accountService.Create(createChildAccountDto);


            //ASSERT
            childaccountDto.Name.Should().Be(createChildAccountDto.Name);
            childaccountDto.Id.Should().NotBe(Guid.Empty);
            childaccountDto.Number.Should().Be(createChildAccountDto.Number);
            childaccountDto.FullNumber.Should().Be("1.0");
            childaccountDto.Type.Should().Be(AccountType.Debit);
            childaccountDto.ParentAccountId.Should().Be(rootaccountDto.Id);
            childaccountDto.ParentAccount.Should().NotBeNull();
            childaccountDto.ParentAccount?.Id.Should().Be(rootaccountDto.Id);
        }
    }
}