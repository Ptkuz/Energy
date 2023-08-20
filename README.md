# Energy
Тестовое задание для трудоустройства в ТрансНефтьЭнерго

Разработан проект WEB Service на базе шаблона ASP.NET Core Web Application на платформе .NET 7. Веб сервис запускается на порту 8050 по HTTPS под Kestrel

Задание 1:
Использовался подход Code First и Entity Framework Core 7 для создания структуры базы данных. 
Все сущности вынесены в отдельный проект, Energy.DAL.
![image](https://github.com/Ptkuz/Energy/assets/43362172/ea2443c7-4902-49cf-8fc6-ef370fd8ec30)

В результате получилась ER-диаграмма:
![image](https://github.com/Ptkuz/Energy/assets/43362172/fb818826-9c10-4cf4-8fd4-8165345e7e5d)

Создан специальный класс, ContextInitializer. В нем инициализируются начальные даннные для БД. Затем эти данных вставляются в БД во время конфигурироваиня.

Задание 2:
Доступ к контексту БД и сущностям осуществляется через отдельный сервис, DataBaseService. Сервис определен в отдельном проекте, Energy.Services. Здесь должны
содержатся все сервисы, внедренные через DI. Контроллер не имеет прямого доступа контексту БД. Вся работа с базой происходит через сервис.

Части задания 2 разбиты по конечным точкам. В комментариях к каждой точке описано, какие тестовые данных необходимо ставить для получения результата.

2.1 AddNewMeasuringPoint -
Добавить новую точку измерения с указанием счетчика, трансформатора тока и трансформатора напряжения.
2.2 GetSettlementMeters -
Выбрать все расчетные приборы учета в 2018 году.
2.3 GetCounterEnergies -
По указанному объекту потребления выбрать все счетчики с закончившимся сроком поверке.
2.4 GetCurrentTransformers -
По указанному объекту потребления выбрать все трансформаторы напряжения с закончившимся сроком поверке.
2.5 GetVoltageTransformers -
По указанному объекту потребления выбрать все трансформаторы тока с закончившимся сроком поверке.


