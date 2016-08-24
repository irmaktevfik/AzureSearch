using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepository
{
    public class IndexRepository : BaseRepository
    {
        public async Task<bool> DeleteAsync(string indexName)
        {
            if (await serviceClient.Indexes.ExistsAsync(indexName))
            {
                await serviceClient.Indexes.DeleteAsync(indexName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Index> CreateAsync(Index index)
        {
            return await serviceClient.Indexes.CreateAsync(index);
        }

        public async Task<IList<string>> GetAsync()
        {
            return (await serviceClient.Indexes.ListNamesAsync());
        }
    }
}
