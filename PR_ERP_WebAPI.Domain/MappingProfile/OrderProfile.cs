using AutoMapper;
using PR_ERP_WebAPI.Domain.DTO.Order;
using PR_ERP_WebAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_ERP_WebAPI.Domain.MappingProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        { 
           CreateMap<Order, OrderDTO>().ReverseMap();
           CreateMap<CreateOrderDTO, Order>().ReverseMap();
           CreateMap<UpdateOrderDTO, Order>().ReverseMap();
        }
    }
}
