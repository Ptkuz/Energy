namespace Energy.WebHost.Models.RequestModels
{
    /// <summary>
    /// Модель запроса для добавления новой точки измерения
    /// </summary>
    public class AddNewMeasuringPointRequest
    {
        /// <summary>
        /// Название точки измерения электроэнергии
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Номер счетчика энергии
        /// </summary>
        public string CounterEnergyNumber { get; set; } = null!;

        /// <summary>
        /// Номер трансформатора тока
        /// </summary>
        public string CurrentTransformerNumber { get; set; } = null!;

        /// <summary>
        /// Номер трансформатора напряжения
        /// </summary>
        public string VoltageTransformerNumber { get; set; } = null!;
    }
}
