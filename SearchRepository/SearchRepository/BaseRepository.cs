using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepository
{
    public class BaseRepository
    {
        private const string searchServiceName = "tel";
        private const string apiKey = "YOUR API KEY";
        internal SearchServiceClient serviceClient;
        public BaseRepository()
        {
            serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(apiKey));
        }
        
    }
}
