using System.Runtime.Serialization;

namespace Energy.WebHost.Models.ResponseModels.Base
{
    [DataContract]
    public class ErrorInfo
    {

        [DataMember(Name = "message")]
        public string Message { get; set; } = null!;

        [DataMember(Name = "stackTrace")]
        public string StackTrce { get; set; } = null!;

        public ErrorInfo(string message, string stackTrace) 
        {
            Message = message;
            StackTrce = stackTrace; 
        }  
    }
}
