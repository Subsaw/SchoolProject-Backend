using Application.Dtos;
using AutoMapper;
using Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Car, CarDto>().ReverseMap();
        CreateMap<Rental, RentalDto>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src.Car))
            .ReverseMap();
    }
}

