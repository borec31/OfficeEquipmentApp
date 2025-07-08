using System.ComponentModel.DataAnnotations;

namespace OfficeEquipmentApp.Model;

// Модель для представления офисного оборудования
public class Equipment
{
    [Key]
    public int Id { get; set; } // Уникальный идентификатор оборудования

    [Required]
    public string Name { get; set; } = string.Empty; // Наименование оборудования

    [Required]
    public string Type { get; set; } = string.Empty; // Тип оборудования (Printer, Scanner, Monitor)

    [Required]
    public string Status { get; set; } = string.Empty; // Статус оборудования (InUse, InStock, InRepair)
}
