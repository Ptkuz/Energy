using System.Runtime.Serialization;

namespace Energy.WebHost.Models.ResponseModels.Base
{

    [DataContract, Serializable]
    public class BaseResponse
    {
        /// <summary>
        /// Статус ответа
        /// </summary>
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "errorInfo")]
        public ErrorInfo ErrorInfo { get; set; } = null!;

        public BaseResponse() 
        {
            Success = true;
        }

        public BaseResponse(ErrorInfo errorInfo) 
        {
            Success = false;
            ErrorInfo = errorInfo;
        }
    }
}
