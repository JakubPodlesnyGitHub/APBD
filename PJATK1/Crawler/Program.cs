using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string urlWeb; 
            if(args.Length == 0)
            {
                throw new ArgumentException("Brak Argumentow w Parametrach Programu");
            }
                urlWeb = args[0];
            
            if (!UrlChecker(urlWeb))
            {
                throw new ArgumentException("Invalid URL");
            }

            string content;
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage respnse = await httpClient.GetAsync(urlWeb);
            if (respnse.IsSuccessStatusCode)
            {
                content = await respnse.Content.ReadAsStringAsync();
                //Console.WriteLine(content);
                string pattern = "([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})";
                DisplayUniqueEmails(content,pattern);
            }
            else
            {
               throw new Exception("Bład w czasie pobierania strony");
            }

            httpClient.Dispose();
            
        }
        public static void DisplayUniqueEmails(String text, String pattern)
        {
            MatchCollection matchCollection = Regex.Matches(text,pattern);
            HashSet<string> matchSet = GetUniqueList(matchCollection); 
            Console.WriteLine("MAILS");
            int i = 0;
            if (matchSet.Count > 0)
            {
                foreach (string m in matchSet)
                {
                    Console.WriteLine("Mail: " + i + " : " + m);
                    i++;
                }
            }
            else if (matchCollection.Count == 0)
            {
                Console.WriteLine("Nie znaleziono adresów email");
            }
        }

        public static bool UrlChecker(string url)
        {
            Uri uriResult;
            bool tryCreateResult = Uri.TryCreate(url, UriKind.Absolute, out uriResult);
            if (tryCreateResult)
                return true;
            else
                return false;
        }

        public static HashSet<string> GetUniqueList(MatchCollection m)
        {
            HashSet<string> uMatches = new HashSet<string>();
            foreach (Match element in m)
            {
                    uMatches.Add(element.ToString()); 
            }
            return uMatches;
        }
    }
}
