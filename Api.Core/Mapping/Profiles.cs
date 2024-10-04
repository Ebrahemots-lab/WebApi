using Api.Core.DTOS;
using Api.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Mapping
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(B => B.BrandName,options=> options.MapFrom(D => D.Brand.Name))
                .ForMember(B => B.TypeName,options=> options.MapFrom(D => D.Type.Name));

            CreateMap<Brand, BrandTypeDto>();
            CreateMap<Type, BrandTypeDto>();
        }
    }
}
