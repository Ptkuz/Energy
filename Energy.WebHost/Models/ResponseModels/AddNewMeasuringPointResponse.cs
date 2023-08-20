using Energy.DAL.Entities;
using Energy.WebHost.Models.ResponseModels.Base;

namespace Energy.WebHost.Models.ResponseModels
{
    public class AddNewMeasuringPointResponse : BaseResponse
    {
        public MeasuringPoint MeasuringPoint { get; set; } = null!;

        public AddNewMeasuringPointResponse(MeasuringPoint measuringPoint)
            : base()
        {
            MeasuringPoint = measuringPoint;
        }

        public AddNewMeasuringPointResponse(ErrorInfo errorInfo)
            : base(errorInfo)
        {
            
        }
    }
}
