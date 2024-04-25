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
                if (authorQuery != string.Empty) {  query += "+" + authorQuery; } // Query title and author
            }
            if (authorQuery != string.Empty) { query += authorQuery; } // Query only author

            var listRequest = service.Volumes.List(query);
            var listResponse = listRequest.Execute();

            // Handle data
            List<Book> bookList = new List<Book>();
            if (listResponse.Items != null)
            {
                foreach (Volume item in listResponse.Items )
                {
                    Volume.VolumeInfoData data = item.VolumeInfo;
                    string title = data.Title;
                    string author = data.Authors[0];
                    // genre ?
                    string description = data.Description;
                    int pages = (data.PageCount ?? 0);
                    // price ?
                    string publication = data.PublishedDate.Substring(0, 4);
                    string imgUrl = data.ImageLinks.Thumbnail;

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
            }
            return bookList;
        }

    }
}
