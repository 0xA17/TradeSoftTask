# TradeSoftTask

## � �������

TradeSoftTask - ��� ���������������� ������, ������� ��������� ������ �� ������������ ��������.

## �����������

* ��������, ��������� � �������� �������

<p align="center">
    <img align="center" src="https://telegra.ph/file/31a147f924dae650b7833.png">
</p>

* ���������� ������� � ������ ���� ������ PostgreSQL

<p align="center">
    <img align="center" src="https://telegra.ph/file/36c75b874b181919d0ede.png">
</p>

* ������� ����� ������ �� ������� � ������� �������������

<p align="center">
    <img align="center" src="https://telegra.ph/file/c94516b6f4cec71b5843a.png">
</p>
<p align="center">
    <img align="center" src="https://telegra.ph/file/2cd9c0aebccfaa295ae5f.png">
</p>
<p align="center">
    <img align="center" src="https://telegra.ph/file/505dc5261e2f2a5f41b4f.png">
</p>

## ������ ������

### 1.	��������� PostgreSQL

��������� �� [����������� ���� PostgreSQL](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads) � ��������� ������, ������� �������� ��� ����� ��.

### 2.	��������� ����������� � ��

� ����� [DbConnectionString.cs](https://github.com/0xA17/TradeSoftTask/blob/master/Configs/DbConnectionString.cs) ���������� ��������� ������ �� ������������, ��������� �� � ������, ������� ��������� ��� �������� PostgreSQL:

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

### 3. ����������� � ��������� ������

����� ������� ����������, ��� ��� ��������!

<p align="center">
    <img align="center" src="https://telegra.ph/file/4d6c37045fd51646af2f9.png">
</p>