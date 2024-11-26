using AutoMapper;
using Lab4.DAL.Models;
using Lab4.Abstraction.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Мапінг з Client у ClientViewModel
        CreateMap<Client, ClientViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.client_id)) // Мапінг для ID
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.client_full_name))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.client_phone_number))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.client_gender.HasValue
                ? (src.client_gender.Value ? "Чоловік" : "Жінка")
                : "Невідомо"));

        // Мапінг з ClientViewModel у Client
        CreateMap<ClientViewModel, Client>()
            .ForMember(dest => dest.client_id, opt => opt.MapFrom(src => src.Id)) // Зворотній мапінг для ID
            .ForMember(dest => dest.client_full_name, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.client_phone_number, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.client_gender, opt => opt.MapFrom(src => src.Gender == "Чоловік"));
    }
}
