using AutoMapper;
using Energy.Services.Models;

namespace Energy.WebHost.RequestModels.Mapping
{
    public static class MappingRequests
    {
        public static AddNewPointDto MapAddNewMeasuringPointRequestAndAddNewPointDto(AddNewMeasuringPointRequest addNewMeasuringPointRequest) 
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddNewMeasuringPointRequest, AddNewPointDto>());
            var mapper = new Mapper(config);
            AddNewPointDto addNewPointDto = mapper.Map<AddNewMeasuringPointRequest, AddNewPointDto>(addNewMeasuringPointRequest);
            return addNewPointDto;
        }
    }
}
