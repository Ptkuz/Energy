using Energy.DAL.Entities;
using Energy.WebHost.Models.ResponseModels.Base;

namespace Energy.WebHost.Models.ResponseModels
{

    /// <summary>
    /// Ответ конечной точки добавления новой точки измерения
    /// </summary>
    public class AddNewMeasuringPointResponse : BaseResponse
    {

        /// <summary>
        /// Точка измерения электроэнергии
        /// </summary>
        public MeasuringPoint MeasuringPoint { get; set; } = null!;

        /// <summary>
        /// Конструктор успешного результата
        /// </summary>
        /// <param name="measuringPoint"></param>
        public AddNewMeasuringPointResponse(MeasuringPoint measuringPoint)
            : base()
        {
            MeasuringPoint = measuringPoint;
        }

        /// <summary>
        /// Конструктор ответа с ошибкой
        /// </summary>
        /// <param name="errorInfo"></param>
        public AddNewMeasuringPointResponse(ErrorInfo errorInfo)
            : base(errorInfo)
        {
            
        }
    }
}
