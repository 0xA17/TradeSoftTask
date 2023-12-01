# TradeSoftTask

## О проекте

TradeSoftTask - это демонстрационный проект, который имитирует работу со справочником аналогов.

## Возможности

* Создание, изменение и удаление записей

<p align="center">
    <img align="center" src="https://telegra.ph/file/31a147f924dae650b7833.png">
</p>

* Сохранение записей в крутую базу данных PostgreSQL

<p align="center">
    <img align="center" src="https://telegra.ph/file/36c75b874b181919d0ede.png">
</p>

* Быстрый поиск связей по товарам с удобной визуализацией

<p align="center">
    <img align="center" src="https://telegra.ph/file/c94516b6f4cec71b5843a.png">
</p>
<p align="center">
    <img align="center" src="https://telegra.ph/file/2cd9c0aebccfaa295ae5f.png">
</p>
<p align="center">
    <img align="center" src="https://telegra.ph/file/505dc5261e2f2a5f41b4f.png">
</p>

## Начало работы

### 1.	Установка PostgreSQL

Переходим на [официальный сайт PostgreSQL](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads) и скачиваем пакеты, которые подходят для вашей ОС.

### 2.	Настройка подключения к БД

В файле [DbConnectionString.cs](https://github.com/0xA17/TradeSoftTask/blob/master/Configs/DbConnectionString.cs) необходимо проверить данные на корректность, совпадают ли с вашими, которые указывали при загрузке PostgreSQL:

```csharp
static class DbConnectionString
{
    private const String Server = "localhost";

    private const String Port = "5432";

    private const String UserId = "postgres";

    private const String Password = "123";

    private const String Database = "TradeSoftTask";

    public const String ConnectionString = $"Server={Server};Port={Port};User Id={UserId};Password={Password};Database={Database}";
}
```

### 3. Компилируем и запускаем проект

После запуска убеждаемся, что все работает!

<p align="center">
    <img align="center" src="https://telegra.ph/file/4d6c37045fd51646af2f9.png">
</p>