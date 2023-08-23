namespace Energy.Validations.Exceptions
{

    /// <summary>
    /// Исключение, возникающее при передаче пустого объекта
    /// </summary>
    [Serializable]
    public class ArgumentNullOrEmptyException : Exception
    {
        /// <summary>
        /// Название аргумента
        /// </summary>
        public string ArgumentName { get; }

        /// <summary>
        /// Конструктор инициализатор
        /// </summary>
        /// <param name="argumentName">Название аргумента</param>
        /// <param name="message">Сообщение</param>
        public ArgumentNullOrEmptyException(string argumentName, string message)
            : base(message)
        {
            ArgumentName = argumentName;
        }
    }
}
