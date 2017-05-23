using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Cubic_ERP.Areas.Finance.Dtos;
using Cubic_ERP.Areas.Finance.Models;

namespace Cubic_ERP.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<BankAccount, BankAccountDto>();
            Mapper.CreateMap<BankAccountDto, BankAccount>().ForMember(m=>m.Id, opt=>opt.Ignore());
            Mapper.CreateMap<Account, AccountDto>();
            Mapper.CreateMap<AccountDto, Account>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Currencies, CurrenciesDto>();
            Mapper.CreateMap<CurrenciesDto, Currencies>().ForMember(m=>m.Id, opt=>opt.Ignore());
            Mapper.CreateMap<CashFlowHeadingDto, CashFlowHeading>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<CashFlowHeading, CashFlowHeadingDto>();

            Mapper.CreateMap<AccountMasterDto, AccountMaster>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<AccountMaster, AccountMasterDto>();

        }
    }
}