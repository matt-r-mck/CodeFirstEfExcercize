using CodeFirstEFExercise.Controllers;
using CodeFirstEFExercise.Models;
using System;
using System.Threading.Tasks;

namespace CodeFirstEFExercise {
    class Program {
        static async Task Main(string[] args) {

            await TestOrderLine();

        }

        static async Task TestOrderLine() {
            var lineCtrl = new OrderLinesController();
            var orderLine = new OrderLine() {
                Id = 0, OrderId = 1, ProductId = 2, Quantity = 2
            };
            await lineCtrl.Create(orderLine);
        }

        static async Task TestOrder() {
            var ordCtrl = new OrdersController();

        }

        static async Task TestCustomer() {
            
            var custCtrl = new CustomersController();

            var cust = new Customer() {
                Id = 0, Name = "Great America", State = "OH", IsNationalAccount = true, TotalSales = 7000
            };
            cust = await custCtrl.CreateAsync(cust);

            var customers = await custCtrl.GetAllAsync();

            var cust2 = await custCtrl.Get(1);

            await custCtrl.Remove(2);
        }

        static async Task TestProduct() {
            var prodCtrl = new ProductsController();
            var prod1 = new Product() {
                Id = 0, Code = "Monitor", Name = "Monitor", Price = 9.99m, InStock = true
            };
            prod1 = await prodCtrl.CreateAsync(prod1);
        }

    }
}
