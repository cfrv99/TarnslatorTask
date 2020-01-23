using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslateTask.Services
{
    static public class TranslatorService
    {
        private static HttpClient Client = new HttpClient();
        static public string AzToEng(string text)
        {
            string translated = "";
            text = text.Replace(" ", "%20");

            StringBuilder sb = new StringBuilder();
            sb.Append("https://translate.yandex.net/api/v1.5/tr.json/translate?key=")
              .Append("trnsl.1.1.20200122T153040Z.618a570b2469a961.db3f7ac62dc38c96c7f92f59da53508bde6ceaf3")
              .Append("&text=")
              .Append(text)
              .Append("&lang=az-en");

            dynamic JsonFile = JsonConvert.DeserializeObject(Client.GetAsync(sb.ToString()).Result.Content.ReadAsStringAsync().Result);
            translated = JsonFile["text"].ToString();
            translated = translated.Replace("[", "");
            translated = translated.Replace("]", "");
            translated = translated.Replace("\"", "");


            return translated.ToString();
        }

    }
}
