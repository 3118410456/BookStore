﻿using AutoMapper;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Book,BookModel>().ReverseMap();
        }
    }
}
