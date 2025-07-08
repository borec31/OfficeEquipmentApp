using System.Windows;

namespace OfficeEquipmentApp;

// Код-бехайнд для главного окна приложения
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // Список возможных типов оборудования
    public static string[] EquipmentTypes { get; } = ["Printer", "Scanner", "Monitor"];

    // Список возможных статусов оборудования
    public static string[] EquipmentStatuses { get; } = ["InUse", "InStock", "InRepair"];
}