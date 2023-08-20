using Energy.DAL.Entities;
using Energy.DAL.Entities.Base;
using Energy.WebHost.Models.ResponseModels.Base;

namespace Energy.WebHost.Models.ResponseModels
{
    public class CollectionResponse<T> : BaseResponse 
        where T : Entity, new()
    {
        public IEnumerable<T> CounterEnergies { get; set; } = null!;

        public CollectionResponse(IEnumerable<T> counterEnergies)
            : base()
        {
            CounterEnergies = counterEnergies;
        }

        public CollectionResponse(ErrorInfo errorInfo)
            : base(errorInfo)
        {

        }
    }
}
