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
                new Organization(Guid.NewGuid(), "Организация 1", "Москва"),
                new Organization(Guid.NewGuid(), "Организация 2", "Новосибирск"),
                new Organization(Guid.NewGuid(), "Организация 3", "Москва"),
                new Organization(Guid.NewGuid(), "Организация 4", "Екатеринбург"),
                new Organization(Guid.NewGuid(), "Организация 5", "Москва")
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
                new Subsidiary(Guid.NewGuid(), "Дочерняя организация 1", "Москва", Organizations[0].Id),
                new Subsidiary(Guid.NewGuid(), "Дочерняя организация 2", "Москва", Organizations[0].Id),
                new Subsidiary(Guid.NewGuid(), "Дочерняя организация 3", "Новосибирск", Organizations[1].Id),
                new Subsidiary(Guid.NewGuid(), "Дочерняя организация 4", "Москва", Organizations[2].Id),
                new Subsidiary(Guid.NewGuid(), "Дочерняя организация 5", "Москва", Organizations[2].Id),
                new Subsidiary(Guid.NewGuid(), "Дочерняя организация 6", "Екатеринбург", Organizations[3].Id),
                new Subsidiary(Guid.NewGuid(), "Дочерняя организцая 7", "Москва", Organizations[4].Id),
                new Subsidiary(Guid.NewGuid(), "Дочерняя организация 8", "Москва", Organizations[4].Id),

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
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 1", "Москва", Subsidiaries[0].Id),
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 4", "Новосибирск", Subsidiaries[1].Id),
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 5", "Новосибирск", Subsidiaries[1].Id),
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 6", "Новосибирск", Subsidiaries[1].Id),
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 7", "Москва", Subsidiaries[2].Id),
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 8", "Москва", Subsidiaries[2].Id),
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 9", "Москва", Subsidiaries[2].Id),
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 10", "Екатеринбург", Subsidiaries[3].Id),
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 11", "Екатеринбург", Subsidiaries[3].Id),
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 12", "Екатеринбург", Subsidiaries[3].Id  ),
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 13", "Москва", Subsidiaries[4].Id),
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 14", "Москва", Subsidiaries[4].Id),
                new ConsumptionObject(Guid.NewGuid(), "Объект потребления 15", "Москва", Subsidiaries[4].Id),
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
                new CounterEnergy(795645, RandomDate(), "Тип первый")
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
                new CurrentTransformer(323232, RandomDate(), "Второй тип трансформатора", 1.3)
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
                new VoltageTransformer(1212133, RandomDate(), "Второй тип трансформатора", 1.4)
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
                new MeasuringPoint(Guid.NewGuid(), "Расчетная точка 1", ConsumptionObjects[0].Id, CounterEnergies[0].Id, CurrentTransformers[0].Id, VoltageTransformers[0].Id),
                new MeasuringPoint(Guid.NewGuid(), "Расчетная точка 2", ConsumptionObjects[1].Id, CounterEnergies[1].Id, CurrentTransformers[1].Id, VoltageTransformers[1].Id),
                new MeasuringPoint(Guid.NewGuid(), "Расчетная точка 3", ConsumptionObjects[2].Id, CounterEnergies[2].Id, CurrentTransformers[2].Id, VoltageTransformers[2].Id)
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
                new SupplyPoint(Guid.NewGuid(), "Принимающая точка 1", 500, ConsumptionObjects[0].Id),
                new SupplyPoint(Guid.NewGuid(), "Принимающая точка 2", 300, ConsumptionObjects[1].Id),
                new SupplyPoint(Guid.NewGuid(), "Принимающая точка 3", 700, ConsumptionObjects[2].Id)
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
