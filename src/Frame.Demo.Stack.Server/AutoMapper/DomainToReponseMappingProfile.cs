namespace Frame.Demo.Stack.Server.AutoMapper
{
    using AutoMapper;
    using Frame.Demo.Stack.DBContext.Classes;
    using Frame.Demo.Stack.Server.ViewModels;
    using global::AutoMapper;

    public class DomainToReponseMappingProfile: Profile
    {
        public DomainToReponseMappingProfile()
        {
            CreateMap<TemperatureSample, TemperatureSampleDTOv1>()
                .ForMember(x => x.TemperatureC, opt => opt.MapFrom(x => x.Temperature))
                .ForMember(x => x.Time, opt => opt.MapFrom(x => ((DateTimeOffset)x.Time).ToUnixTimeMilliseconds()));
        }
    }
}
