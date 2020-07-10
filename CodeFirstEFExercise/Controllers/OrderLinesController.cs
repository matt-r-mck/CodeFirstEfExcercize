using CodeFirstEFExercise.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CodeFirstEFExercise.Controllers {
    public class OrderLinesController {

        private readonly AppDbContext _context = null;

        //private async Task CalculateOrderTotal(int orderId) {
        //    var order = await _context.Orders.FindAsync(orderId);
        //    if (order == null) throw new Exception("Order not found for calc.");
        //    var orderLines = await _context.OrderLines.Where(ol => ol.OrderId == orderId).ToListAsync();
        //    var total = 0m;
        //    foreach(var line in orderLines) {
        //        total += line.Quantity * line.Product.Price;
        //    }
        //    order.Total = total;
        //    await _context.SaveChangesAsync();
        //}

        private async Task CalculateOrderTotal(int orderId) {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) throw new Exception("Order not found for calc.");
            order.Total = (from l in order.OrderLines 
                           select new {
                               Subtotal = l.Quantity * l.Product.Price
                           }).Sum(x => x.Subtotal);
            await _context.SaveChangesAsync();
        }

            //public async Task<IEnumerable<OrderLine>> GetAll() {
            //    return await _context.OrderLines.ToListAsync();
            //}

            public async Task<OrderLine> Get(int id) {
            return await _context.OrderLines.FindAsync(id);
        }

        public async Task<OrderLine> Create(OrderLine orderLine) {
            CheckNull(orderLine);
            await _context.OrderLines.AddAsync(orderLine);
            await _context.SaveChangesAsync();
            await CalculateOrderTotal(orderLine.OrderId);
            return orderLine;
        }

        public async Task Change(int id, OrderLine orderLine) {
            CheckNull(orderLine);
            if (id != orderLine.Id) throw new Exception("OrderLine Id does not match");
            _context.Entry(orderLine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(OrderLine orderLine) {
            CheckNull(orderLine);
            _context.OrderLines.Remove(orderLine);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id) {
            var ordL = Get(id);
            if (ordL == null) throw new Exception("OrderLine Id does not exist");
            await Remove(ordL.Result);
        }

        private static void CheckNull(OrderLine orderLine) {
            if (orderLine == null) throw new Exception("OrderLine cannot be null");
        }

        public OrderLinesController() {
            _context = new AppDbContext();
        }
    }
}
