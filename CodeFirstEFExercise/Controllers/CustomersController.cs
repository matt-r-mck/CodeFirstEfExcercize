using CodeFirstEFExercise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFExercise.Controllers {

    public class CustomersController {


        private readonly AppDbContext _context = null;

        public async Task<IEnumerable<Customer>> GetAllAsync() {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> Get(int id) {
            return await _context.Customers.FindAsync(id);
        }

        private static void CheckNull(Customer customer) {
            if (customer == null) throw new Exception("Customer cannot be null");
        }

        public async Task<Customer> CreateAsync(Customer customer) {
            CheckNull(customer);
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task Change(int id, Customer customer) {
            CheckNull(customer);
            if (id != customer.Id) throw new Exception("Customer Id does not match");
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Customer customer) {
            CheckNull(customer);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id) {
            var cust = Get(id);
            if (cust == null) throw new Exception("Customer does not exist");
            await Remove(cust.Result);
        }

        public CustomersController() {
            _context = new AppDbContext();
        }

    }
}
