using Energy.Validations.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Energy.Validations
{

    /// <summary>
    /// Методы расширения для валидаций
    /// </summary>
    public static class ValidationsExtentions
    {

        /// <summary>
        /// Проверяет объект на null
        /// </summary>
        /// <param name="source">Провермяемый объект</param>
        /// <param name="argumentName">Имя аргумента</param>
        /// <exception cref="ArgumentNullException">Передается пустой объект</exception>
        public static void CheckArgumentNull([NotNull]this object? source, string argumentName) 
        {
            if (source is null) 
            {
                throw new ArgumentNullException(argumentName ?? String.Empty, "Объект не может быть пустым!");    
            }
        }

        /// <summary>
        /// Проверяет коллекцию на null и пустоту
        /// </summary>
        /// <typeparam name="T">Тип коллекции</typeparam>
        /// <param name="source">Проверяемая коллекция</param>
        /// <param name="argumentName">Имя аргумента</param>
        /// <exception cref="ArgumentNullOrEmptyException">Передается пустая коллекция</exception>
        public static void CheckEnumerableNullOrEmpty<T>([NotNull]this IEnumerable<T>? source, string argumentName)
        {
            if (source is null || !source.Any()) 
            {
                throw new ArgumentNullOrEmptyException(argumentName ?? string.Empty, "Коллекция не может быть пустой!");
            }
        }

        /// <summary>
        /// Проверяет строку на null и пустоту
        /// </summary>
        /// <param name="source">Проверяемая строка</param>
        /// <param name="argumentName">Имя аргумента</param>
        /// <exception cref="ArgumentNullOrEmptyException">Передается пустая строка</exception>
        public static void CheckArgumentNullOrWhiteSpace([NotNull]this string? source, string argumentName) 
        {
            if (String.IsNullOrWhiteSpace(source)) 
            {
                throw new ArgumentNullOrEmptyException(argumentName ?? string.Empty, "Строка не может быть пустой!");
            }
        }
    }
}
