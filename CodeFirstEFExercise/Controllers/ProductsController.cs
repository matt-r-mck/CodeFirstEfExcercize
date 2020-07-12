using CodeFirstEFExercise.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFExercise.Controllers {
    public class ProductsController {

        //Does not inngerit any tables from the DbContext
        private readonly AppDbContext _context = null;

        public async Task<IEnumerable<Product>> GetAll() {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Get(int id) {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateAsync(Product product) {
            CheckNull(product);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        private static void CheckNull(Product product) {
            if (product == null) throw new Exception("Product cannot be null");
        }

        public async Task Change(int id, Product product) {
            CheckNull(product);
            if (id != product.Id) throw new Exception("Product Id does not match");
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove (Product product) {
            CheckNull(product);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id) {
            var product = Get(id);
            if (product == null) throw new Exception ("Product does not exist");
            await Remove(product.Result);
        }

        public ProductsController() {
            _context = new AppDbContext();
        }

    }
}
