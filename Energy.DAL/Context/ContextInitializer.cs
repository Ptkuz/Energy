using Energy.DAL.Entities;

namespace Energy.DAL.Context
{
    /// <summary>
    /// Инициализатор базы данных
    /// </summary>
    public static class ContextInitializer
    {

        private static Organization[]? organizations = null;

        private static Random random = new Random();

        /// <summary>
        /// Инициализатор организаций
        /// </summary>
        public static Organization[] Organizations
        {
            get
            {
                if (organizations is null)
                    organizations = new Organization[]
                    {
                new Organization("Организация 1", "Москва"),
                new Organization("Организация 2", "Новосибирск"),
                new Organization("Организация 3", "Москва"),
                new Organization("Организация 4", "Екатеринбург"),
                new Organization("Организация 5", "Москва")
                    };

                return organizations;
            }
        }

        private static Subsidiary[]? subsidiaries = null;

        /// <summary>
        /// Инициализатор дочерних организаций
        /// </summary>
        public static Subsidiary[] Subsidiaries
        {
            get
            {
                if (subsidiaries is null)
                    subsidiaries = new Subsidiary[]
                    {
                new Subsidiary("Дочерняя организация 1", "Москва", Organizations[0].Id),
                new Subsidiary("Дочерняя организация 2", "Москва", Organizations[0].Id),
                new Subsidiary("Дочерняя организация 3", "Новосибирск", Organizations[1].Id),
                new Subsidiary("Дочерняя организация 4", "Москва", Organizations[2].Id),
                new Subsidiary("Дочерняя организация 5", "Москва", Organizations[2].Id),
                new Subsidiary("Дочерняя организация 6", "Екатеринбург", Organizations[3].Id),
                new Subsidiary("Дочерняя организация 7", "Москва", Organizations[4].Id),
                new Subsidiary("Дочерняя организация 8", "Москва", Organizations[4].Id),

                    };

                return subsidiaries;
            }
        }

        private static ConsumptionObject[]? consumptionObjects = null;

        /// <summary>
        /// Инициализатор объектов потребления
        /// </summary>
        public static ConsumptionObject[] ConsumptionObjects
        {
            get
            {
                if (consumptionObjects is null)
                    consumptionObjects = new ConsumptionObject[]
                    {
                new ConsumptionObject("Объект потребления 1", "Москва", Subsidiaries[0].Id),
                new ConsumptionObject("Объект потребления 4", "Новосибирск", Subsidiaries[1].Id),
                new ConsumptionObject("Объект потребления 5", "Новосибирск", Subsidiaries[1].Id),
                new ConsumptionObject("Объект потребления 6", "Новосибирск", Subsidiaries[1].Id),
                new ConsumptionObject("Объект потребления 7", "Москва", Subsidiaries[2].Id),
                new ConsumptionObject("Объект потребления 8", "Москва", Subsidiaries[2].Id),
                new ConsumptionObject("Объект потребления 9", "Москва", Subsidiaries[2].Id),
                new ConsumptionObject("Объект потребления 10", "Екатеринбург", Subsidiaries[3].Id),
                new ConsumptionObject("Объект потребления 11", "Екатеринбург", Subsidiaries[3].Id),
                new ConsumptionObject("Объект потребления 12", "Екатеринбург", Subsidiaries[3].Id),
                new ConsumptionObject("Объект потребления 13", "Москва", Subsidiaries[4].Id),
                new ConsumptionObject("Объект потребления 14", "Москва", Subsidiaries[4].Id),
                new ConsumptionObject("Объект потребления 15", "Москва", Subsidiaries[4].Id),
                    };

                return consumptionObjects;
            }
        }

        private static CounterEnergy[]? counterEnergies = null;

        /// <summary>
        /// Инициализатор счетчиков электрической энергии
        /// </summary>
        public static CounterEnergy[] CounterEnergies
        {
            get
            {
                if (counterEnergies is null)
                    counterEnergies = new CounterEnergy[]
                    {
                new CounterEnergy("45654645654654", "Тип первый", RandomDate()),
                new CounterEnergy("56765764546454", "Тип второй", RandomDate()),
                new CounterEnergy("54654654745674", "Тип первый", RandomDate()),
                new CounterEnergy("45654654654645", "Тип первый", DateTime.Now.AddDays(-4)),
                new CounterEnergy("56788769987987", "Тип первый", DateTime.Now.AddDays(-2)),
                new CounterEnergy("56767565745645", "Тип второй", DateTime.Now.AddDays(-3)),
                new CounterEnergy("56766575676575", "Тип второй", DateTime.Now.AddDays(-8)),
                new CounterEnergy("98798798787687", "Тип второй", DateTime.Now.AddDays(-10)),
                new CounterEnergy("96786876867767", "Тип первый", DateTime.Now.AddDays(-2)),
                new CounterEnergy("1111", "Тип первый", RandomDate())
                    };
                return counterEnergies;
            }
        }

        private static CurrentTransformer[]? currentTransformers = null;

        /// <summary>
        /// Инициализатор трансформаторов тока
        /// </summary>
        public static CurrentTransformer[] CurrentTransformers
        {

            get
            {
                if (currentTransformers is null)
                currentTransformers = new CurrentTransformer[]
                {
                new CurrentTransformer("6754654654645", "Первый тип трансформатора", RandomDate(), 1.5),
                new CurrentTransformer("45676576575675", "Первый тип трансформатора", RandomDate(), 1.8),
                new CurrentTransformer("43543543543576", "Второй тип трансформатора", RandomDate(), 1.3),
                new CurrentTransformer("67867587686754", "Второй тип трансформатора", RandomDate(), 1.7),
                new CurrentTransformer("86787687687676", "Второй тип трансформатора", DateTime.Now.AddDays(-2), 1.3),
                new CurrentTransformer("65765867876867", "Второй тип трансформатора", DateTime.Now.AddDays(-3), 1.7),
                new CurrentTransformer("56867896876546", "Второй тип трансформатора", DateTime.Now.AddDays(-4), 1.9),
                new CurrentTransformer("98797887978656", "Второй тип трансформатора", DateTime.Now.AddDays(-9), 1.3),
                new CurrentTransformer("87987978565676", "Первый тип трансформатора", DateTime.Now.AddDays(-3), 1.3),
                new CurrentTransformer("2222", "Первый тип трансформатора", RandomDate(), 1.3)
                };
                return currentTransformers;
            }
        }

        private static VoltageTransformer[]? voltageTransformers = null;

        /// <summary>
        /// Инициализатор трансформаторов напряжения
        /// </summary>
        public static VoltageTransformer[] VoltageTransformers
        {
            get
            {
                if (voltageTransformers is null)
                    voltageTransformers = new VoltageTransformer[]
                     {
                new VoltageTransformer("45645645645654", "Второй тип трансформатора", RandomDate(), 1.3),
                new VoltageTransformer("45654654654646", "Первый тип трансформатора", RandomDate(), 1.2),
                new VoltageTransformer("97687686796786", "Второй тип трансформатора", RandomDate(), 1.4),
                new VoltageTransformer("56765765765765", "Второй тип трансформатора", DateTime.Now.AddDays(-3), 1.1),
                new VoltageTransformer("67867867867875", "Второй тип трансформатора", DateTime.Now.AddDays(-2), 1.9),
                new VoltageTransformer("56786758767878", "Второй тип трансформатора", DateTime.Now.AddDays(-3), 1.7),
                new VoltageTransformer("56778768765644", "Второй тип трансформатора", DateTime.Now.AddDays(-8), 1.1),
                new VoltageTransformer("87978456546564", "Второй тип трансформатора", DateTime.Now.AddDays(-5), 1.4),
                new VoltageTransformer("97868567657566", "Первый тип трансформатора", DateTime.Now.AddDays(-7), 1.4),
                new VoltageTransformer("3333", "Первый тип трансформатора", RandomDate(), 1.4)
                     };
                return voltageTransformers;
            }
        }

        private static MeasuringPoint[]? measuringPoints = null;

        /// <summary>
        /// Инициализатор точек измерения электроэнергиии
        /// </summary>
        public static MeasuringPoint[] MeasuringPoints
        {
            get
            {
                if (measuringPoints is null)
                    measuringPoints = new MeasuringPoint[]
                    {
                new MeasuringPoint("Расчетная точка 1", ConsumptionObjects[0].Id, CounterEnergies[0].Id, CurrentTransformers[0].Id, VoltageTransformers[0].Id),
                new MeasuringPoint("Расчетная точка 2", ConsumptionObjects[1].Id, CounterEnergies[1].Id, CurrentTransformers[1].Id, VoltageTransformers[1].Id),
                new MeasuringPoint("Расчетная точка 3", ConsumptionObjects[2].Id, CounterEnergies[2].Id, CurrentTransformers[2].Id, VoltageTransformers[2].Id),
                new MeasuringPoint("Расчетная точка 4", ConsumptionObjects[3].Id, CounterEnergies[3].Id, CurrentTransformers[3].Id, VoltageTransformers[3].Id),
                new MeasuringPoint("Расчетная точка 5", ConsumptionObjects[4].Id, CounterEnergies[4].Id, CurrentTransformers[4].Id, VoltageTransformers[4].Id),
                new MeasuringPoint("Расчетная точка 6", ConsumptionObjects[5].Id, CounterEnergies[5].Id, CurrentTransformers[5].Id, VoltageTransformers[5].Id),
                new MeasuringPoint("Расчетная точка 7", ConsumptionObjects[3].Id, CounterEnergies[6].Id, CurrentTransformers[6].Id, VoltageTransformers[6].Id),
                new MeasuringPoint("Расчетная точка 8", ConsumptionObjects[3].Id, CounterEnergies[7].Id, CurrentTransformers[7].Id, VoltageTransformers[7].Id),
                new MeasuringPoint("Расчетная точка 5", ConsumptionObjects[4].Id, CounterEnergies[8].Id, CurrentTransformers[8].Id, VoltageTransformers[8].Id)
                    };
                return measuringPoints;
            }
        }

        private static SupplyPoint[]? supplyPoints = null;

        /// <summary>
        /// Инициализатор точек поставки электроэнергии
        /// </summary>
        public static SupplyPoint[] SupplyPoints
        {
            get
            {
                if (supplyPoints is null)
                    supplyPoints = new SupplyPoint[]
                    {
                new SupplyPoint("Принимающая точка 1", 500, ConsumptionObjects[0].Id),
                new SupplyPoint("Принимающая точка 2", 300, ConsumptionObjects[1].Id),
                new SupplyPoint("Принимающая точка 3", 700, ConsumptionObjects[2].Id)
                    };
                return supplyPoints;
            }
        }

        private static SettlementMeter[]? settlementMeters = null;

        /// <summary>
        /// Инициализатор расчетных точек учета
        /// </summary>
        public static SettlementMeter[] SettlementMeters
        {
            get
            {
                if (settlementMeters is null)
                    settlementMeters = new SettlementMeter[]
                     {
                new SettlementMeter(new DateTime(2018, 11, 25, 00, 00 ,00), new DateTime(2018, 11, 25, 00, 00 ,00), SupplyPoints[0].Id, MeasuringPoints[0].Id),
                new SettlementMeter(new DateTime(2018, 11, 29, 00, 00 ,00), new DateTime(2018, 11, 30, 00, 00 ,00), SupplyPoints[0].Id, MeasuringPoints[1].Id),
                new SettlementMeter(new DateTime(2018, 11, 11, 00, 00, 00), new DateTime(2018, 11, 13, 00, 00, 00), SupplyPoints[0].Id, MeasuringPoints[2].Id),
                new SettlementMeter(new DateTime(2018, 11, 5, 00, 00, 00), new DateTime(2018, 11, 6, 00, 00, 00), SupplyPoints[0].Id, MeasuringPoints[0].Id),
                new SettlementMeter(new DateTime(2018, 11, 20, 00, 00, 00), new DateTime(2018, 11, 22, 00, 00, 00), SupplyPoints[1].Id, MeasuringPoints[0].Id),
                new SettlementMeter(new DateTime(2018, 11, 21, 00, 00, 00), new DateTime(2018, 11, 21, 00, 00, 00), SupplyPoints[2].Id, MeasuringPoints[0].Id),
                new SettlementMeter(new DateTime(2023, 11, 21, 00, 00, 00), new DateTime(2023, 11, 21, 00, 00, 00), SupplyPoints[2].Id, MeasuringPoints[0].Id),
                     };
                return settlementMeters;
            }
        }

        private static DateTime RandomDate(DateTime startDate = default)
        {
            if (startDate == default)
                startDate = new DateTime(2019, 1, 1, 00, 00, 00);
            int range = (DateTime.Now - startDate).Days;
            return startDate.AddMinutes(random.Next(range));
        }


    }
}
