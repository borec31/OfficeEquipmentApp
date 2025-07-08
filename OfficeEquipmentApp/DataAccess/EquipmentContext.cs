using Microsoft.EntityFrameworkCore;
using OfficeEquipmentApp.Model;

namespace OfficeEquipmentApp.DataAccess;

// Контекст базы данных для работы с SQLite
public class EquipmentContext : DbContext
{
    public DbSet<Equipment> Equipments { get; set; } = null!; // Таблица оборудования

    // Настройка подключения к SQLite
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=equipment.db");
    }

    // Инициализация базы данных начальными данными
    public void InitializeDatabase()
    {
        Database.EnsureCreated(); // Создает базу данных, если она не существует

        // Проверяем, есть ли данные в таблице
        if (!Equipments.Any())
        {
            // Добавляем начальные данные
            Equipments.AddRange(
                new Equipment { Name = "HP LaserJet", Type = "Printer", Status = "InUse" },
                new Equipment { Name = "Samsung Monitor", Type = "Monitor", Status = "InStock" },
                new Equipment { Name = "Canon Scanner", Type = "Scanner", Status = "InRepair" }
            );
            SaveChanges();
        }
    }
}