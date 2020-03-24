using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcapp.Models;
using mvcapp.Repository;

namespace mvcapp.Controllers
{
    public class productController : Controller
    {  
        private readonly CrudDbContext _context;
        private readonly ProductRepository _productRepository;

        public productController(CrudDbContext context) {
            _context = context;
            _productRepository = new ProductRepository(_context);
        }

        public async Task<IActionResult> Index() {
            return View(await _context.product.ToListAsync());
        }
        /*
        [HttpGet]
        public IActionResult Create()
        {
            return View(new product());
        }


        [HttpPost]
        public IActionResult Create(product prod)
        {
            if (ModelState.IsValid)
            {
                _context.product.Add(prod);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.product.Where(a => a.idproduct == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Edit(product prod)
        {
            _context.product.Update(prod);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_context.product.Where(a => a.idproduct == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Delete(product prod)
        {
            var productfound = _context.product.Where(a => a.idproduct == prod.idproduct).FirstOrDefault();
            _context.product.Remove(productfound);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }*/

       [HttpGet]
        public IActionResult Create()
        {
            return View(new product());
        }


        [HttpPost]
        public async Task<IActionResult> Create(product prod)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.Add(prod);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View( await _productRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(product prod)
        {
            await _productRepository.Update(prod);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _productRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(product prod)
        {
            await _productRepository.Delete(prod.idproduct);
            return RedirectToAction("Index");
        }

    }
}