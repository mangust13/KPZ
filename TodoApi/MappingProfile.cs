using AutoMapper;
using TodoApi.Models;
using TodoApi.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Мапінг з Client у ClientViewModel
        CreateMap<Client, ClientViewModel>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.client_gender.HasValue
                ? (src.client_gender.Value ? "Чоловік" : "Жінка")
                : "Невідомо"));

        // Мапінг з ClientViewModel у Client (зворотній мапінг)
        CreateMap<ClientViewModel, Client>()
            .ForMember(dest => dest.client_gender, opt => opt.MapFrom(src => src.Gender == "Чоловік"));
    }
}
