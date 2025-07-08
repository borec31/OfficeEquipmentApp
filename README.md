# OfficeEquipmentApp

Приложение для учета офисного оборудования с CRUD-операциями.

## Описание
- **Платформа**: .NET 8.0
- **Интерфейс**: WPF
- **Архитектура**: MVVM
- **База данных**: SQLite
- **Функционал**:
  - Добавление, обновление, удаление оборудования.
  - Поля: Наименование, Тип (Printer, Scanner, Monitor), Статус (InUse, InStock, InRepair).
  - Данные инициализируются при запуске.

## Установка
1. Клонируйте репозиторий: `git clone https://github.com/твой_логин/OfficeEquipmentApp.git`
2. Откройте `OfficeEquipmentApp.sln` в Visual Studio.
3. Восстановите NuGet-пакеты: **Сборка** → **Восстановить пакеты NuGet**.
4. Соберите и запустите: **F5**.

## Структура проекта
- `Model/Equipment.cs`: Модель оборудования.
- `DataAccess/EquipmentContext.cs`: Контекст базы данных SQLite.
- `ViewModel/MainViewModel.cs`: ViewModel для управления данными и командами.
- `MainWindow.xaml`: Интерфейс с таблицей и кнопками.
