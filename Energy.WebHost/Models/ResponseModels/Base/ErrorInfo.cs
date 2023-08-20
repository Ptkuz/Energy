using System.Runtime.Serialization;

namespace Energy.WebHost.Models.ResponseModels.Base
{

    /// <summary>
    /// Информация об ошибках
    /// </summary>
    [DataContract]
    public class ErrorInfo
    {

        /// <summary>
        /// Сообщение
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; } = null!;

        /// <summary>
        /// Стек вызова
        /// </summary>

        [DataMember(Name = "stackTrace")]
        public string? StackTrce { get; set; } = null!;

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="stackTrace">Стек вызова</param>
        public ErrorInfo(string message, string? stackTrace) 
        {
            Message = message;
            StackTrce = stackTrace ?? String.Empty; 
        }  
    }
}
