<H1 align="center"> README </H1>
<H2>Тестовое задание - сервис заказов.</H2>
Сервис реализует функционал:
<ol>
<li>Создание заказа</li>
<li>Изменение / Редактирование заказа </li>
<li>Удаление заказа</li>
<li>Получение информации о заказе по идентификатору</li>
</ol>

<h2> Инструкция </h2>

1. Добавить необходимые библиотеки в случае если они отсутсвуют:
    * Microsoft.AspNetCore.OpenApi (Ver 7.0.5)
    * Swashbuckle.AspNetCore (Ver 6.4.0)
    * FluentResults (Ver 3.15.2)
    * Microsoft.EntityFrameworkCore (Ver 7.0.5)
    * Microsoft.EntityFrameworkCore.Design (Ver 7.0.5)
    * Npgsql (Ver 7.0.4)
    * Npgsql.EntityFrameworkCore.PostgreSQL (Ver 7.0.4)

2. В файле 'ApplicationDbContext.cs' в строке 17 изменить поля *username* и *password* на свои данные из postgresql
<img src="/sources/connectionString.png" alt="Строка подключения">
3. Запустить приложение


