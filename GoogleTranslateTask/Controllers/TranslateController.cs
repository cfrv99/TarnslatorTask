using GoogleTranslateTask.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;
using GoogleTranslateTask.Models;
using GoogleTranslateTask.Services;

namespace GoogleTranslateTask.Controllers
{
    public class TranslateController : Controller
    {
        private readonly DataContext context;

        public TranslateController(DataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {


            #region with google api
            //var client = TranslationClient.Create();
            //List<ProductVM> vMs = new List<ProductVM>();
            //var products = context.Products.ToList();
            //foreach (var item in products)
            //{
            //    ProductVM p = new ProductVM()
            //    {
            //        Description = item.Description,
            //        Price = item.Price,
            //        Name = item.Name,
            //        DescriptionENG = client.TranslateText(item.Description, LanguageCodes.Turkish, LanguageCodes.English).TranslatedText
            //    };
            //    vMs.Add(p);
            //}
            #endregion with yandex api


            //var client = TranslationClient.Create();
            List<ProductVM> vMs = new List<ProductVM>();
            var products = context.Products.ToList();
            foreach (var item in products)
            {
                ProductVM p = new ProductVM()
                {
                    Description = item.Description,
                    Price = item.Price,
                    Name = item.Name,
                    DescriptionENG = TranslatorService.AzToEng(item.Description)
                };
                vMs.Add(p);
            }



            return View(vMs);
        }

        public IActionResult Create()
        {

            return View(new Product());
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    context.Products.Add(model);
                    context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
