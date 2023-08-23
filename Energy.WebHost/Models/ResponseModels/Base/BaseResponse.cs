using System.Runtime.Serialization;

namespace Energy.WebHost.Models.ResponseModels.Base
{

    /// <summary>
    /// Базовая модель Response
    /// </summary>
    [DataContract, Serializable]
    public class BaseResponse
    {
        /// <summary>
        /// Статус ответа
        /// </summary>
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        /// <summary>
        /// Информация об ошибках
        /// </summary>
        [DataMember(Name = "errorInfo")]
        public ErrorInfo ErrorInfo { get; set; } = null!;

        /// <summary>
        /// Конструктор успешного ответа
        /// </summary>
        public BaseResponse() 
        {
            Success = true;
        }

        /// <summary>
        /// Конструктор ответа с ошибкой
        /// </summary>
        /// <param name="errorInfo">Информация об ошибках</param>
        public BaseResponse(ErrorInfo errorInfo) 
        {
            Success = false;
            ErrorInfo = errorInfo;
        }
    }
}
