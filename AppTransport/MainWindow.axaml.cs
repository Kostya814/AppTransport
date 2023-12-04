using System;
using System.Linq;
using System.Threading;
using AppTransport.Models;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace AppTransport;

public partial class MainWindow : Window
{
    DB db= new DB();
    public MainWindow()
    {
        var list = db.GetAllOrders();
        int i = list.Where(u => u.Price > 2000).Count();
        InitializeComponent();
        TbPrice.Text += " " + i;
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(3);
        timer.Tick += Update;
        timer.Start();
    }

    private void Update(object? sender, EventArgs e)
    {
        Update();
    }

    void Update()
    {
        DgOrders.ItemsSource = db.GetAllOrders();
    }

    private async void DeleteOrder(object? sender, RoutedEventArgs e)
    {
        var box = MessageBoxManager
            .GetMessageBoxStandard("Вы уверены", "Вы уверены что хотите удалить запись?",
                ButtonEnum.YesNo);
        var result =  await box.ShowAsync();
        if (result == ButtonResult.No) return;
        db.DeleteOrderById((DgOrders.SelectedItem as Order).Id);
    }
    private void ChangeOrder(object? sender, RoutedEventArgs e)
    {
        var item = DgOrders.SelectedItem as Order;
        new AddOrder(item).Show();
    }
        
}