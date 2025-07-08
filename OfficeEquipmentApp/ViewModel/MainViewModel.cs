using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OfficeEquipmentApp.DataAccess;
using OfficeEquipmentApp.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace OfficeEquipmentApp.ViewModel;

// ViewModel для главного окна приложения
public partial class MainViewModel : ObservableObject
{
    private readonly EquipmentContext _dbContext; // Контекст базы данных
    [ObservableProperty]
    private Equipment? _selectedEquipment; // Выбранное оборудование в таблице

    public ObservableCollection<Equipment> Equipments { get; } // Коллекция оборудования для отображения
    public RelayCommand AddCommand { get; } // Команда для добавления оборудования
    public RelayCommand UpdateCommand { get; } // Команда для обновления оборудования
    public RelayCommand DeleteCommand { get; } // Команда для удаления оборудования

    // Конструктор
    public MainViewModel()
    {
        _dbContext = new EquipmentContext();
        _dbContext.InitializeDatabase(); // Инициализация базы данных

        // Загружаем данные из базы в коллекцию
        Equipments = new ObservableCollection<Equipment>(_dbContext.Equipments.ToList());

        // Инициализация команд
        AddCommand = new RelayCommand(AddEquipment);
        UpdateCommand = new RelayCommand(UpdateEquipment, CanExecuteUpdateDelete);
        DeleteCommand = new RelayCommand(DeleteEquipment, CanExecuteUpdateDelete);
    }

    // Метод для добавления нового оборудования
    private void AddEquipment()
    {
        var newEquipment = new Equipment { Name = "New Equipment", Type = "Printer", Status = "InStock" };
        _dbContext.Equipments.Add(newEquipment);
        _dbContext.SaveChanges();
        Equipments.Add(newEquipment);
        SelectedEquipment = newEquipment; // Устанавливаем новое оборудование как выбранное
    }

    // Метод для обновления выбранного оборудования
    private void UpdateEquipment()
    {
        if (SelectedEquipment != null)
        {
            _dbContext.Equipments.Update(SelectedEquipment);
            _dbContext.SaveChanges();
        }
    }

    // Метод для удаления выбранного оборудования
    private void DeleteEquipment()
    {
        if (SelectedEquipment != null)
        {
            _dbContext.Equipments.Remove(SelectedEquipment);
            _dbContext.SaveChanges();
            Equipments.Remove(SelectedEquipment);
            SelectedEquipment = null; // Сбрасываем выбор после удаления
        }
    }

    // Условие активации команд Обновить и Удалить
    private bool CanExecuteUpdateDelete()
    {
        return SelectedEquipment != null; // Активировать, если выбрана запись
    }

    // Обновление состояния команд при изменении SelectedEquipment
    partial void OnSelectedEquipmentChanged(Equipment? oldValue, Equipment? newValue)
    {
        UpdateCommand.NotifyCanExecuteChanged(); // Уведомляем о возможных изменениях
        DeleteCommand.NotifyCanExecuteChanged(); // Уведомляем о возможных изменениях
    }
}