using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercisesOnLinq.Models;


namespace ExercisesOnLinq.Repository.cs
{
    // Repositories/ProductRepository.cs
    public static class ProductRepository
    {
        public static List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 1500, CategoryId = 1 },
        new Product { Id = 2, Name = "Smartphone", Price = 900, CategoryId = 1 },
        new Product { Id = 3, Name = "Headphones", Price = 200, CategoryId = 2 },
        new Product { Id = 4, Name = "Keyboard", Price = 50, CategoryId = 2 },
        new Product { Id = 5, Name = "Monitor", Price = 300, CategoryId = 2 },
        new Product { Id = 6, Name = "Mouse", Price = 25, CategoryId = 2 },
        new Product { Id = 7, Name = "Printer", Price = 150, CategoryId = 2 },
        new Product { Id = 8, Name = "Desk Lamp", Price = 40, CategoryId = 3 },
        new Product { Id = 9, Name = "Chair", Price = 100, CategoryId = 3 },
        new Product { Id = 10, Name = "Tablet", Price = 600, CategoryId = 1 },
        new Product { Id = 11, Name = "Smartwatch", Price = 250, CategoryId = 1 },
        new Product { Id = 12, Name = "External HDD", Price = 120, CategoryId = 2 },
        new Product { Id = 13, Name = "Router", Price = 80, CategoryId = 2 },
        new Product { Id = 14, Name = "Webcam", Price = 70, CategoryId = 2 },
        new Product { Id = 15, Name = "Speakers", Price = 90, CategoryId = 2 },
        new Product { Id = 16, Name = "Desk Organizer", Price = 30, CategoryId = 3 }
    };
    }

    // Repositories/CategoryRepository.cs
    public static class CategoryRepository
    {
        public static List<Category> Categories = new()
    {
        new Category { Id = 1, Name = "Electronics" },
        new Category { Id = 2, Name = "Accessories" },
        new Category { Id = 3, Name = "Office Supplies" },
        new Category { Id = 4, Name = "Home Appliances" },
        new Category { Id = 5, Name = "Furniture" },
        new Category { Id = 6, Name = "Clothing" },
        new Category { Id = 7, Name = "Books" },
        new Category { Id = 8, Name = "Toys" },
        new Category { Id = 9, Name = "Beauty" },
        new Category { Id = 10, Name = "Sports" },
        new Category { Id = 11, Name = "Outdoors" },
        new Category { Id = 12, Name = "Automotive" },
        new Category { Id = 13, Name = "Grocery" },
        new Category { Id = 14, Name = "Health" },
        new Category { Id = 15, Name = "Music" },
        new Category { Id = 16, Name = "Art" }
    };
    }

    // Repositories/CustomerRepository.cs
    public static class CustomerRepository
    {
        public static List<Customer> Customers = new()
    {
        new Customer { Id = 1, FullName = "Alice Smith", Email = "alice@example.com" },
        new Customer { Id = 2, FullName = "Bob Johnson", Email = "bob@example.com" },
        new Customer { Id = 3, FullName = "Charlie Brown", Email = "charlie@example.com" },
        new Customer { Id = 4, FullName = "David Wilson", Email = "david@example.com" },
        new Customer { Id = 5, FullName = "Eve Davis", Email = "eve@example.com" },
        new Customer { Id = 6, FullName = "Frank Moore", Email = "frank@example.com" },
        new Customer { Id = 7, FullName = "Grace Taylor", Email = "grace@example.com" },
        new Customer { Id = 8, FullName = "Hannah Anderson", Email = "hannah@example.com" },
        new Customer { Id = 9, FullName = "Ian Thomas", Email = "ian@example.com" },
        new Customer { Id = 10, FullName = "Jane Martin", Email = "jane@example.com" },
        new Customer { Id = 11, FullName = "Kevin Lee", Email = "kevin@example.com" },
        new Customer { Id = 12, FullName = "Laura White", Email = "laura@example.com" },
        new Customer { Id = 13, FullName = "Mike Harris", Email = "mike@example.com" },
        new Customer { Id = 14, FullName = "Nina Clark", Email = "nina@example.com" },
        new Customer { Id = 15, FullName = "Oscar Lewis", Email = "oscar@example.com" },
        new Customer { Id = 16, FullName = "Paula Walker", Email = "paula@example.com" }
    };
    }

    // Repositories/OrderRepository.cs
    public static class OrderRepository
    {
        public static List<Order> Orders = new()
    {
        new Order { Id = 1, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-10), TotalAmount = 1500 },
        new Order { Id = 2, CustomerId = 2, OrderDate = DateTime.Now.AddDays(-9), TotalAmount = 900 },
        new Order { Id = 3, CustomerId = 3, OrderDate = DateTime.Now.AddDays(-8), TotalAmount = 200 },
        new Order { Id = 4, CustomerId = 4, OrderDate = DateTime.Now.AddDays(-7), TotalAmount = 50 },
        new Order { Id = 5, CustomerId = 5, OrderDate = DateTime.Now.AddDays(-6), TotalAmount = 300 },
        new Order { Id = 6, CustomerId = 6, OrderDate = DateTime.Now.AddDays(-5), TotalAmount = 25 },
        new Order { Id = 7, CustomerId = 7, OrderDate = DateTime.Now.AddDays(-4), TotalAmount = 150 },
        new Order { Id = 8, CustomerId = 8, OrderDate = DateTime.Now.AddDays(-3), TotalAmount = 40 },
        new Order { Id = 9, CustomerId = 9, OrderDate = DateTime.Now.AddDays(-2), TotalAmount = 100 },
        new Order { Id = 10, CustomerId = 10, OrderDate = DateTime.Now.AddDays(-1), TotalAmount = 600 },
        new Order { Id = 11, CustomerId = 11, OrderDate = DateTime.Now, TotalAmount = 250 },
        new Order { Id = 12, CustomerId = 12, OrderDate = DateTime.Now.AddDays(1), TotalAmount = 120 },
        new Order { Id = 13, CustomerId = 13, OrderDate = DateTime.Now.AddDays(2), TotalAmount = 80 },
        new Order { Id = 14, CustomerId = 14, OrderDate = DateTime.Now.AddDays(3), TotalAmount = 70 },
        new Order { Id = 15, CustomerId = 15, OrderDate = DateTime.Now.AddDays(4), TotalAmount = 90 },
        new Order { Id = 16, CustomerId = 16, OrderDate = DateTime.Now.AddDays(5), TotalAmount = 30 }
    };
    }

    // Repositories/OrderItemRepository.cs
    public static class OrderItemRepository
    {
        public static List<OrderItem> OrderItems = new()
    {
        new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
        new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 2 },
        new OrderItem { Id = 3, OrderId = 2, ProductId = 3, Quantity = 1 },
        new OrderItem { Id = 4, OrderId = 2, ProductId = 4, Quantity = 1 },
        new OrderItem { Id = 5, OrderId = 3, ProductId = 5, Quantity = 1 },
        new OrderItem { Id = 6, OrderId = 3, ProductId = 6, Quantity = 1 },
        new OrderItem { Id = 7, OrderId = 4, ProductId = 7, Quantity = 1 },
        new OrderItem { Id = 8, OrderId = 4, ProductId = 8, Quantity = 2 },
        new OrderItem { Id = 9, OrderId = 5, ProductId = 9, Quantity = 1 },
        new OrderItem { Id = 10, OrderId = 5, ProductId = 10, Quantity = 1 },
        new OrderItem { Id = 11, OrderId = 6, ProductId = 11, Quantity = 1 },
        new OrderItem { Id = 12, OrderId = 6, ProductId = 12, Quantity = 1 },
        new OrderItem { Id = 13, OrderId = 7, ProductId = 13, Quantity = 1 },
        new OrderItem { Id = 14, OrderId = 7, ProductId = 14, Quantity = 1 },
        new OrderItem { Id = 15, OrderId = 8, ProductId = 15, Quantity = 2 },
        new OrderItem { Id = 16, OrderId = 8, ProductId = 16, Quantity = 1 },
        new OrderItem { Id = 17, OrderId = 9, ProductId = 1, Quantity = 1 },
        new OrderItem { Id = 18, OrderId = 9, ProductId = 2, Quantity = 1 },
        new OrderItem { Id = 19, OrderId = 10, ProductId = 3, Quantity = 1 },
        new OrderItem { Id = 20, OrderId = 10, ProductId = 4, Quantity = 1 },
        new OrderItem { Id = 21, OrderId = 11, ProductId = 5, Quantity = 1 },
        new OrderItem { Id = 22, OrderId = 11, ProductId = 6, Quantity = 1 },
        new OrderItem { Id = 23, OrderId = 12, ProductId = 7, Quantity = 1 },
        new OrderItem { Id = 24, OrderId = 12, ProductId = 8, Quantity = 1 },
        new OrderItem { Id = 25, OrderId = 13, ProductId = 9, Quantity = 2 },
        new OrderItem { Id = 26, OrderId = 13, ProductId = 10, Quantity = 1 },
        new OrderItem { Id = 27, OrderId = 14, ProductId = 11, Quantity = 1 },
        new OrderItem { Id = 28, OrderId = 14, ProductId = 12, Quantity = 1 },
        new OrderItem { Id = 29, OrderId = 15, ProductId = 13, Quantity = 1 },
        new OrderItem { Id = 30, OrderId = 15, ProductId = 14, Quantity = 1 },
        new OrderItem { Id = 31, OrderId = 16, ProductId = 15, Quantity = 1 },
        new OrderItem { Id = 32, OrderId = 16, ProductId = 16, Quantity = 1 },
        new OrderItem { Id = 33, OrderId = 1, ProductId = 3, Quantity = 1 },
        new OrderItem { Id = 34, OrderId = 2, ProductId = 5, Quantity = 1 },
        new OrderItem { Id = 35, OrderId = 3, ProductId = 7, Quantity = 1 },
        new OrderItem { Id = 36, OrderId = 4, ProductId = 9, Quantity = 1 },
        new OrderItem { Id = 37, OrderId = 5, ProductId = 11, Quantity = 1 },
        new OrderItem { Id = 38, OrderId = 6, ProductId = 13, Quantity = 1 },
        new OrderItem { Id = 39, OrderId = 7, ProductId = 15, Quantity = 1 },
        new OrderItem { Id = 40, OrderId = 8, ProductId = 1, Quantity = 1 }
    };
    }

    // Repositories/PaymentRepository.cs
    public static class PaymentRepository
    {
        public static List<Payment> Payments = new()
    {
        new Payment { Id = 1, OrderId = 1, Amount = 1500, PaymentDate = DateTime.Now.AddDays(-9) },
        new Payment { Id = 2, OrderId = 2, Amount = 900, PaymentDate = DateTime.Now.AddDays(-8) },
        new Payment { Id = 3, OrderId = 3, Amount = 200, PaymentDate = DateTime.Now.AddDays(-7) },
        new Payment { Id = 4, OrderId = 4, Amount = 50, PaymentDate = DateTime.Now.AddDays(-6) },
        new Payment { Id = 5, OrderId = 5, Amount = 300, PaymentDate = DateTime.Now.AddDays(-5) },
        new Payment { Id = 6, OrderId = 6, Amount = 25, PaymentDate = DateTime.Now.AddDays(-4) },
        new Payment { Id = 7, OrderId = 7, Amount = 150, PaymentDate = DateTime.Now.AddDays(-3) },
        new Payment { Id = 8, OrderId = 8, Amount = 40, PaymentDate = DateTime.Now.AddDays(-2) },
        new Payment { Id = 9, OrderId = 9, Amount = 100, PaymentDate = DateTime.Now.AddDays(-1) },
        new Payment { Id = 10, OrderId = 10, Amount = 600, PaymentDate = DateTime.Now },
        new Payment { Id = 11, OrderId = 11, Amount = 250, PaymentDate = DateTime.Now.AddDays(1) },
        new Payment { Id = 12, OrderId = 12, Amount = 120, PaymentDate = DateTime.Now.AddDays(2) },
        new Payment { Id = 13, OrderId = 13, Amount = 80, PaymentDate = DateTime.Now.AddDays(3) },
        new Payment { Id = 14, OrderId = 14, Amount = 70, PaymentDate = DateTime.Now.AddDays(4) },
        new Payment { Id = 15, OrderId = 15, Amount = 90, PaymentDate = DateTime.Now.AddDays(5) },
        new Payment { Id = 16, OrderId = 16, Amount = 30, PaymentDate = DateTime.Now.AddDays(6) }
    };
    }

    // Repositories/ShipmentRepository.cs
    public static class ShipmentRepository
    {
        public static List<Shipment> Shipments = new()
    {
        new Shipment { Id = 1, OrderId = 1, TrackingNumber = "TRK1001", ShippedDate = DateTime.Now.AddDays(-8) },
        new Shipment { Id = 2, OrderId = 2, TrackingNumber = "TRK1002", ShippedDate = DateTime.Now.AddDays(-7) },
        new Shipment { Id = 3, OrderId = 3, TrackingNumber = "TRK1003", ShippedDate = DateTime.Now.AddDays(-6) },
        new Shipment { Id = 4, OrderId = 4, TrackingNumber = "TRK1004", ShippedDate = DateTime.Now.AddDays(-5) },
        new Shipment { Id = 5, OrderId = 5, TrackingNumber = "TRK1005", ShippedDate = DateTime.Now.AddDays(-4) },
        new Shipment { Id = 6, OrderId = 6, TrackingNumber = "TRK1006", ShippedDate = DateTime.Now.AddDays(-3) },
        new Shipment { Id = 7, OrderId = 7, TrackingNumber = "TRK1007", ShippedDate = DateTime.Now.AddDays(-2) },
        new Shipment { Id = 8, OrderId = 8, TrackingNumber = "TRK1008", ShippedDate = DateTime.Now.AddDays(-1) },
        new Shipment { Id = 9, OrderId = 9, TrackingNumber = "TRK1009", ShippedDate = DateTime.Now },
        new Shipment { Id = 10, OrderId = 10, TrackingNumber = "TRK1010", ShippedDate = DateTime.Now.AddDays(1) },
        new Shipment { Id = 11, OrderId = 11, TrackingNumber = "TRK1011", ShippedDate = DateTime.Now.AddDays(2) },
        new Shipment { Id = 12, OrderId = 12, TrackingNumber = "TRK1012", ShippedDate = DateTime.Now.AddDays(3) },
        new Shipment { Id = 13, OrderId = 13, TrackingNumber = "TRK1013", ShippedDate = DateTime.Now.AddDays(4) },
        new Shipment { Id = 14, OrderId = 14, TrackingNumber = "TRK1014", ShippedDate = DateTime.Now.AddDays(5) },
        new Shipment { Id = 15, OrderId = 15, TrackingNumber = "TRK1015", ShippedDate = DateTime.Now.AddDays(6) },
        new Shipment { Id = 16, OrderId = 16, TrackingNumber = "TRK1016", ShippedDate = DateTime.Now.AddDays(7) }
    };
    }

}
