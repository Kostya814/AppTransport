using System;

namespace AppTransport.Models;

public class Order
{
    private int _id;
    private Workers _worker;
    private Cars _car;
    private Address _addressLocated;
    private DateTime _dateArrivals;
    private double _price;
    private Clients _clientID;

    public Order()
    {
        
    }
    

    public Order(int id, Workers worker, Cars car, Address addressLocated, DateTime dateArrivals, double price, Clients clientId)
    {
        _id = id;
        _worker = worker;
        _car = car;
        _addressLocated = addressLocated;
        _dateArrivals = dateArrivals;
        _price = price;
        _clientID = clientId;
    }

    public int Id => _id;

    public Workers Worker => _worker;

    public Cars Car => _car;

    public Address AddressLocated => _addressLocated;

    public DateTime DateArrivals => _dateArrivals;

    public double Price => _price;

    public Clients ClientId => _clientID;
}