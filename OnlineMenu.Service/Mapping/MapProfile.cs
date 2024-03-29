﻿using AutoMapper;
using OnlineMenu.Core.Dtos;
using OnlineMenu.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap< CategoryAddDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<ProductAddDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

        }
    }
}
