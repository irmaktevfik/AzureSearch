using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepository
{
    public class DocumentRepository : BaseRepository
    {
        public async Task<bool> UploadBatchAsync<T>(IEnumerable<T> documentList, string indexName)
            where T: class
        {
            try
            {
                var sClient = serviceClient.Indexes.GetClient(indexName);
                var btch = IndexBatch.Upload<T>(documentList);
                await sClient.Documents.IndexAsync(btch);
                return true;
            }
            catch (IndexBatchException ex)
            {
                throw new ApplicationException("Failed to index some documents");
            }
        }

        public async Task<List<T>> SearchDocuments<T>(string indexName, string searchParameters, string filter = null)
            where T : class
        {
            var sClient = serviceClient.Indexes.GetClient(indexName);
            var sp = new SearchParameters();

            if (!string.IsNullOrEmpty(filter))
            {
                sp.Filter = filter;
            }

            var response = await sClient.Documents.SearchAsync<T>(searchParameters, sp);

            if (response.Results != null)
            {
                return response.Results.Select(p => p.Document).ToList();
            }
            else return default(List<T>);
        }
    }
}
