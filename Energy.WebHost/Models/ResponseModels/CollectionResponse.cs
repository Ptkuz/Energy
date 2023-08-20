using Energy.DAL.Entities.Base;
using Energy.WebHost.Models.ResponseModels.Base;

namespace Energy.WebHost.Models.ResponseModels
{

    /// <summary>
    /// Ответ с коллекцией <see cref="T"/>
    /// </summary>
    /// <typeparam name="T">Объект, унаследованный от <see cref="Entity"/></typeparam>
    public class CollectionResponse<T> : BaseResponse
        where T : Entity, new()
    {

        /// <summary>
        /// Коллекция <see cref="T"/>
        /// </summary>
        public IEnumerable<T> CounterEnergies { get; set; } = null!;

        /// <summary>
        /// Конструктор успешного ответа
        /// </summary>
        /// <param name="counterEnergies">Коллекция <see cref="T"/></param>
        public CollectionResponse(IEnumerable<T> counterEnergies)
            : base()
        {
            CounterEnergies = counterEnergies;
        }

        /// <summary>
        /// Конструктор ответа с ошибкой
        /// </summary>
        /// <param name="errorInfo"></param>
        public CollectionResponse(ErrorInfo errorInfo)
            : base(errorInfo)
        {

        }
    }
}
