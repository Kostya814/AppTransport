using Avalonia.Controls;

namespace AppTransport;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        DB db= new DB();
        InitializeComponent();
        DgOrders.ItemsSource = db.GetAllOrders();
    }
}