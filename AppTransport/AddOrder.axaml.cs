using System;
using System.Collections.Generic;
using System.Linq;
using AppTransport.Models;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.VisualBasic;

namespace AppTransport;

public partial class AddOrder : Window
{
    private Order _order;
    private DB db = new DB();
    private List<Address> _address;
    private List<Clients> _clients;
    private List<Cars> _cars;
    private List<Workers> _workers;
    public AddOrder()
    {
        InitializeComponent();
        _address = db.GetAllAddress();
        _clients = db.GetAllClients();
        _cars = db.GetAllCars();
        _workers = db.GetAllWorkers();
        CbAddress.ItemsSource = _address;
        CbCar.ItemsSource = _cars;
        CbClient.ItemsSource = _clients;
        CbWorker.ItemsSource = _workers;
        
    }

    public AddOrder(Order order):this()
    {
        _order = order;
        CbAddress.SelectedItem = _address.FirstOrDefault(u=>u.Id == _order.AddressLocated.Id);
        CbCar.SelectedItem = _cars.FirstOrDefault(u=>u.Id == _order.Car.Id);;
        CbClient.SelectedItem = _clients.FirstOrDefault(u=>u.Id == _order.ClientId.Id);;
        CbWorker.SelectedItem = _workers.FirstOrDefault(u=>u.Id == _order.Worker.Id);;
        DpDate.SelectedDate = _order.DateArrivals;
        TbPrice.Text = _order.Price.ToString();
    }

    private void Cancel(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    private void InsertAndUpdate(object? sender, RoutedEventArgs e)
    {
        if(_order == null) Insert();
        else
        {
            var order = new Order(_order.Id,
                CbWorker.SelectedItem as Workers,
                CbCar.SelectedItem as Cars,
                CbAddress.SelectedItem as Address,
                DpDate.SelectedDate.Value.DateTime,
                Convert.ToInt32(TbPrice.Text),
                CbClient.SelectedItem as Clients);
            db.UpdateOrderById(order);
            Close();
        }

        
    }

    private void Insert()
    {
        
        _order = new Order(1,
            CbWorker.SelectedItem as Workers,
            CbCar.SelectedItem as Cars,
            CbAddress.SelectedItem as Address,
            DpDate.SelectedDate.Value.DateTime,
            Convert.ToInt32(TbPrice.Text),
            CbClient.SelectedItem as Clients);
        db.InsertOrderById(_order);
        Close();
    }
}