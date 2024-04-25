using Google.Apis.Services;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Books.v1;
using Newtonsoft.Json;
using Google.Apis.Books.v1.Data;


namespace BookStoreSystem.Controller
{
    public class APIController
    {
        const string API_KEY = "AIzaSyAoLppNNs8vtYB-v45zZRWhPh-KsNb_VLE";
        public static List<Book> GoogleSearch(string titleQuery, string authorQuery)
        {
            // Create the service.
            var service = new BooksService(new BaseClientService.Initializer
            {
                ApplicationName = "BookStoreSystem",
                ApiKey = API_KEY,
            });

            // Run the request.
            string query = "";
            if (titleQuery != string.Empty) 
            { 
                query += titleQuery; // Query only title
                if (authorQuery != string.Empty) {  query += "+inauthor:" + authorQuery; } // Query title and author
            }
            if (authorQuery != string.Empty) { query += "inauthor:" + authorQuery; } // Query only author

            var listRequest = service.Volumes.List(query);
            var listResponse = listRequest.Execute();

            // Handle data
            List<Book> bookList = new List<Book>();
            if (listResponse.Items != null)
            {
                foreach (Volume item in listResponse.Items )
                {
                    try
                    {
                        Volume.VolumeInfoData data = item.VolumeInfo;
                        if (data == null) { continue; }
                        string title = data.Title ?? string.Empty;
                        string author = string.Empty;
                        if (data.Authors != null) { author = data.Authors[0]; }
                        // genre ?
                        string description = data.Description ?? string.Empty;
                        int pages = data.PageCount ?? 0;
                        // price ?
                        string publication = string.Empty;
                        if (data.PublishedDate != null) { publication = data.PublishedDate.Substring(0, 4); }
                        string imgUrl = string.Empty;
                        if (data.ImageLinks != null) { imgUrl = data.ImageLinks.Thumbnail; }

                        bookList.Add(new Book()
                        {
                            Title = title,
                            Author = author,
                            // genre ?
                            Description = description,
                            Pages = pages,
                            // price ?
                            Publication = publication,
                            CoverUrl = imgUrl,
                        });
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                }
            }
            return bookList;
        }

    }
}
