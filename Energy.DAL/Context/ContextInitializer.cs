using Energy.DAL.Entities;

namespace Energy.DAL.Context
{
    public class ContextInitializer
    {

        private Organization[]? organizations = null;

        public Organization[] Organizations
        {
            get
            {
                if (organizations == null)
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

        private Subsidiary[]? subsidiaries = null;

        public Subsidiary[] Subsidiaries
        {
            get
            {
                if (subsidiaries == null)
                    subsidiaries = new Subsidiary[]
                    {
                new Subsidiary("Дочерняя организация 1", "Москва", Organizations[0].Id),
                new Subsidiary("Дочерняя организация 2", "Москва", Organizations[0].Id),
                new Subsidiary("Дочерняя организация 3", "Новосибирск", Organizations[1].Id),
                new Subsidiary("Дочерняя организация 4", "Москва", Organizations[2].Id),
                new Subsidiary("Дочерняя организация 5", "Москва", Organizations[2].Id),
                new Subsidiary("Дочерняя организация 6", "Екатеринбург", Organizations[3].Id),
                new Subsidiary("Дочерняя организцая 7", "Москва", Organizations[4].Id),
                new Subsidiary("Дочерняя организация 8", "Москва", Organizations[4].Id),

                    };

                return subsidiaries;
            }
        }

        private ConsumptionObject[]? consumptionObjects = null;

        public ConsumptionObject[] ConsumptionObjects
        {
            get
            {
                if (consumptionObjects == null)
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
                new ConsumptionObject("Объект потребления 12", "Екатеринбург", Subsidiaries[3].Id  ),
                new ConsumptionObject("Объект потребления 13", "Москва", Subsidiaries[4].Id),
                new ConsumptionObject("Объект потребления 14", "Москва", Subsidiaries[4].Id),
                new ConsumptionObject("Объект потребления 15", "Москва", Subsidiaries[4].Id),
                    };

                return consumptionObjects;
            }
        }

        private CounterEnergy[] counterEnergies = null;

        public CounterEnergy[] CounterEnergies
        {
            get
            {
                if (counterEnergies == null)
                    counterEnergies = new CounterEnergy[]
                    {
                new CounterEnergy(645465, RandomDate(), "Тип первый"),
                new CounterEnergy(596565, RandomDate(), "Тип второй"),
                new CounterEnergy(795645, RandomDate(), "Тип первый"),
                new CounterEnergy(865656, DateTime.Now.AddDays(4), "Тип первый"),
                new CounterEnergy(695854, DateTime.Now.AddDays(2), "Тип первый"),
                new CounterEnergy(695845, DateTime.Now.AddDays(3), "Тип второй")
                    };
                return counterEnergies;
            }
        }

        private CurrentTransformer[]? currentTransformers = null;

        public CurrentTransformer[] CurrentTransformers
        {

            get
            {
                if (currentTransformers == null)
                currentTransformers = new CurrentTransformer[]
                {
                new CurrentTransformer(534534, RandomDate(), "Первый тип трансформатора", 1.5),
                new CurrentTransformer(434344, RandomDate(), "Первый тип трансформатора", 1.8),
                new CurrentTransformer(323232, RandomDate(), "Второй тип трансформатора", 1.3),
                new CurrentTransformer(645654, RandomDate(), "Второй тип трансформатора", 1.7),
                new CurrentTransformer(323232, DateTime.Now.AddDays(2), "Второй тип трансформатора", 1.3),
                new CurrentTransformer(123234, DateTime.Now.AddDays(3), "Второй тип трансформатора", 1.7),
                new CurrentTransformer(968845, DateTime.Now.AddDays(4), "Второй тип трансформатора", 1.2)
                };
                return currentTransformers;
            }
        }

        private VoltageTransformer[] voltageTransformers = null;

        public VoltageTransformer[] VoltageTransformers
        {
            get
            {
                if (voltageTransformers == null)
                    voltageTransformers = new VoltageTransformer[]
                     {
                new VoltageTransformer(6575656, RandomDate(), "Второй тип трансформатора", 1.3),
                new VoltageTransformer(4212332, RandomDate(), "Первый тип трансформатора", 1.2),
                new VoltageTransformer(1212133, RandomDate(), "Второй тип трансформатора", 1.4),
                new VoltageTransformer(6544654, DateTime.Now.AddDays(3), "Второй тип трансформатора", 1.1),
                new VoltageTransformer(6968543, DateTime.Now.AddDays(2), "Второй тип трансформатора", 1.9),
                new VoltageTransformer(2139234, DateTime.Now.AddDays(3), "Второй тип трансформатора", 1.7)
                     };
                return voltageTransformers;
            }
        }

        private MeasuringPoint[]? measuringPoints = null;
        public MeasuringPoint[] MeasuringPoints
        {
            get
            {
                if (measuringPoints == null)
                    measuringPoints = new MeasuringPoint[]
                    {
                new MeasuringPoint("Расчетная точка 1", ConsumptionObjects[0].Id, CounterEnergies[0].Id, CurrentTransformers[0].Id, VoltageTransformers[0].Id),
                new MeasuringPoint("Расчетная точка 2", ConsumptionObjects[1].Id, CounterEnergies[1].Id, CurrentTransformers[1].Id, VoltageTransformers[1].Id),
                new MeasuringPoint("Расчетная точка 3", ConsumptionObjects[2].Id, CounterEnergies[2].Id, CurrentTransformers[2].Id, VoltageTransformers[2].Id),
                new MeasuringPoint("Расчетная точка 4", ConsumptionObjects[3].Id, CounterEnergies[3].Id, CurrentTransformers[3].Id, VoltageTransformers[3].Id),
                new MeasuringPoint("Расчетная точка 5", ConsumptionObjects[4].Id, CounterEnergies[4].Id, CurrentTransformers[4].Id, VoltageTransformers[4].Id),
                new MeasuringPoint("Расчетная точка 6", ConsumptionObjects[5].Id, CounterEnergies[5].Id, CurrentTransformers[5].Id, VoltageTransformers[5].Id)
                    };
                return measuringPoints;
            }
        }

        private SupplyPoint[]? supplyPoints = null;

        public SupplyPoint[] SupplyPoints
        {
            get
            {
                if (supplyPoints == null)
                    supplyPoints = new SupplyPoint[]
                    {
                new SupplyPoint("Принимающая точка 1", 500, ConsumptionObjects[0].Id),
                new SupplyPoint("Принимающая точка 2", 300, ConsumptionObjects[1].Id),
                new SupplyPoint("Принимающая точка 3", 700, ConsumptionObjects[2].Id)
                    };
                return supplyPoints;
            }
        }

        private SettlementMeter[]? settlementMeters = null;

        public SettlementMeter[] SettlementMeters
        {
            get
            {
                if (settlementMeters == null)
                    settlementMeters = new SettlementMeter[]
                     {
                new SettlementMeter(SupplyPoints[0].Id, MeasuringPoints[0].Id, new DateTime(2018, 11, 25, 00, 00 ,00), new DateTime(2018, 11, 25, 00, 00 ,00)),
                new SettlementMeter(SupplyPoints[0].Id, MeasuringPoints[1].Id, new DateTime(2018, 11, 29, 00, 00 ,00), new DateTime(2018, 11, 30, 00, 00 ,00)),
                new SettlementMeter(SupplyPoints[0].Id, MeasuringPoints[2].Id, new DateTime(2018, 11, 11, 00, 00 ,00), new DateTime(2018, 11, 13, 00, 00 ,00)),
                new SettlementMeter(SupplyPoints[0].Id, MeasuringPoints[0].Id, new DateTime(2018, 11, 5, 00, 00 ,00), new DateTime(2018, 11, 6, 00, 00 ,00)),
                new SettlementMeter(SupplyPoints[1].Id, MeasuringPoints[0].Id, new DateTime(2018, 11, 20, 00, 00 ,00), new DateTime(2018, 11, 22, 00, 00 ,00)),
                new SettlementMeter(SupplyPoints[2].Id, MeasuringPoints[0].Id, new DateTime(2018, 11, 21, 00, 00 ,00), new DateTime(2018, 11, 21, 00, 00 ,00)),

                     };
                return settlementMeters;
            }
        }

        private Random random = new Random();
        private DateTime RandomDate(DateTime startDate = default)
        {
            if (startDate == default)
                startDate = new DateTime(2010, 1, 1, 00, 00, 00);
            int range = (DateTime.Now - startDate).Minutes;
            return startDate.AddMinutes(random.Next(range));
        }


    }
}
