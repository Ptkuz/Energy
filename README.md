# Energy
Тестовое задание для трудоустройства в ТрансНефтьЭнерго

Разработан проект WEB Service на базе шаблона ASP.NET Core Web Application на платформе .NET 7. Веб сервис запускается на порту 8050 по HTTPS под Kestrel

Задание 1:

Использовался подход Code First и Entity Framework Core 7 для создания структуры базы данных. 
Все сущности вынесены в отдельный проект, Energy.DAL.

![image](https://github.com/Ptkuz/Energy/assets/43362172/e9683765-1bbc-4ca6-9ce7-dc3ffaa8ede2)



В результате получилась ER-диаграмма:

![image](https://github.com/Ptkuz/Energy/assets/43362172/9dc9aef6-93ec-47a2-a925-4e0fa61c8b1b)


Создан специальный класс, ContextInitializer. В нем инициализируются начальные данные. Затем эти данных вставляются в БД во время конфигурирования.

Задание 2:

Доступ к контексту БД и сущностям осуществляется через отдельный сервис, DataBaseService. Сервис определен в отдельном проекте, Energy.Services. Здесь должны
содержатся все сервисы, внедренные через DI. Контроллер не имеет прямого доступа контексту БД. Вся работа с базой происходит через сервис.

Части задания 2 разбиты по конечным точкам. В комментариях к каждой точке описано, какие тестовые данные необходимо установить для получения результата.

2.1 AddNewMeasuringPoint - Тестовые данные ({Любое название}, "1111", "2222", "3333")

Добавить новую точку измерения с указанием счетчика, трансформатора тока и трансформатора напряжения.

2.2 GetSettlementMeters - Тестовые данные не требуются

Выбрать все расчетные приборы учета в 2018 году.

2.3 GetCounterEnergies - Тестовые данные ("Объект потребления 6")

По указанному объекту потребления выбрать все счетчики с закончившимся сроком поверке.

2.4 GetCurrentTransformers - Тестовые данные ("Объект потребления 7")

По указанному объекту потребления выбрать все трансформаторы напряжения с закончившимся сроком поверке.

2.5 GetVoltageTransformers - Тестовые данные ("Объект потребления 6")

По указанному объекту потребления выбрать все трансформаторы тока с закончившимся сроком поверке.

Для теста использовался Swagger: 

![image](https://github.com/Ptkuz/Energy/assets/43362172/53b1c9f3-352d-4a24-a3dc-47120899c423)





