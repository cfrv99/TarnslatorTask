using GoogleTranslateTask.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;
using GoogleTranslateTask.Models;

namespace GoogleTranslateTask.Controllers
{
    public class TranslateController:Controller
    {
        private readonly DataContext context;

        public TranslateController(DataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var client = TranslationClient.Create();

            List<ProductVM> vMs = new List<ProductVM>();
            //var products = context.Products.Select(i => new ProductVM
            //{
            //    Name = i.Name,
            //    Description = i.Description,
            //    Price = i.Price,
            //    DescriptionENG = client.TranslateText(i.Description, LanguageCodes.Turkish, LanguageCodes.English).TranslatedText
            //}).ToList();
            var products = context.Products.ToList();
            foreach (var item in products)
            {
                ProductVM p = new ProductVM()
                {
                    Description = item.Description,
                    Price = item.Price,
                    Name = item.Name,
                    DescriptionENG = client.TranslateText(item.Description, LanguageCodes.Turkish, LanguageCodes.English).TranslatedText
                };
                vMs.Add(p);
            }
            return View(vMs);
        }
    }
}
