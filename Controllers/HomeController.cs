﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormsApp.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {
    }

    public IActionResult Index(string searchString, string category)
    {
        var products = Repository.Products;
        if(!String.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            products = products.Where(p => p.Name!.ToLower().Contains(searchString)).ToList();
        }


        if(!String.IsNullOrEmpty(category) && category !="0")
        {
            products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
        }

        // ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");


        var model = new ProductViewModel{
            Products = products,
            Categories = Repository.Categories,
            SelectedCategory = category
        };

        return View(model);
    }

    public IActionResult Create()
    {
        ViewBag.Categories =new SelectList(Repository.Categories, "CategoryId", "Name");
        return View();
    }



    [HttpPost]
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)
    {
        //creating path name for upload file
        var allowedExtensions = new[] {".jpg", ".png", ".jpeg"};
        var extension = Path.GetExtension(imageFile.FileName);
        var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);


        if(imageFile != null)
        {
            if(!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("", "Uygun resm fayli secin!");
            }
        }


        //Validation
        if(ModelState.IsValid && imageFile !=null){

        using(var stream = new FileStream(path, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

        model.Image = randomFileName;
        model.ProductId = Repository.Products.Count + 1;
        Repository.CreateProduct(model);
        return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }



    public IActionResult Edit(int? id)
    {
        
        if(id == null)
        {
            return NotFound();
        }

        var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);
        if(entity == null){
            return NotFound();
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(entity);
    }


}
