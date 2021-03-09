using AutoMapper;
using Quotex.DomainModels;
using Quotex.Entities;
using QuoteX.Web.Models.QuoteCreateAndResponseModels;
using QuoteX.Web.Models.RegisterAndLoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace QuoteX.Web.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<RegisterModel, UserModel>();

            CreateMap<Quote, QuoteModel>();
            CreateMap<QuoteModel, Quote>();
            CreateMap<QuoteModel, QuoteResponseModel>();
        }
    }
}
