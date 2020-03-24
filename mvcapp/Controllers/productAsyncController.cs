using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcapp.Repository;
using mvcapp.Models;

namespace mvcapp.Controllers
{
    public class productAsyncController : Controller
    {
        private readonly ProductRepository _productRepository;
        public async Task<IActionResult> Index()
        {
            return View(await _productRepository.GetAll());
        }

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