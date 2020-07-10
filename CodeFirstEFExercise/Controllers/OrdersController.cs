using CodeFirstEFExercise.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFExercise.Controllers {
    public class OrdersController {

        private readonly AppDbContext _context = null;

        public async Task<IEnumerable<Order>> GetAll() {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> Get(int id) {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> Create(Order order) {
            CheckNull(order);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task Change(int id, Order order) {
            CheckNull(order);
            if (id != order.Id) throw new Exception("Order Id does not match");
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        private static void CheckNull(Order order) {
            if (order == null) throw new Exception("Order cannot be null");
        }

        public async Task Remove(Order order) {
            CheckNull(order);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task Remove (int id) {
            var ord = Get(id);
            if (ord == null) throw new Exception("Order id does not exist.");
            await Remove(ord.Result);
        }



        public OrdersController() {
            _context = new AppDbContext();
        }

    }
}
