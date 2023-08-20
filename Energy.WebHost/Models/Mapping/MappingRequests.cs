using AutoMapper;
using Energy.Services.Models;
using Energy.WebHost.Models.RequestModels;

namespace Energy.WebHost.Models.Mapping
{

    /// <summary>
    /// Маппинг Request моделей c моделями сервисов 
    /// </summary>
    public static class MappingRequests
    {

        /// <summary>
        /// Маппинг <see cref="AddNewMeasuringPointRequest"/> с <see cref="AddNewPointDto"/>
        /// </summary>
        /// <param name="addNewMeasuringPointRequest">Requst модель</param>
        /// <returns></returns>
        public static AddNewPointDto MapAddNewMeasuringPointRequestAndAddNewPointDto(AddNewMeasuringPointRequest addNewMeasuringPointRequest)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddNewMeasuringPointRequest, AddNewPointDto>());
            var mapper = new Mapper(config);
            AddNewPointDto addNewPointDto = mapper.Map<AddNewMeasuringPointRequest, AddNewPointDto>(addNewMeasuringPointRequest);
            return addNewPointDto;
        }
    }
}
