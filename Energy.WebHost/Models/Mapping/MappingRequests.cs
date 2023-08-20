using AutoMapper;
using Energy.Services.Models;
using Energy.WebHost.Models.RequestModels;

namespace Energy.WebHost.Models.Mapping
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
