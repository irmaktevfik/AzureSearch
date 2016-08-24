using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Microsoft.Azure.Search.Models;
using SearchRepository.Tests.Models;

namespace SearchRepository.Tests
{
    [TestClass]
    public class IndexTest
    {
        [TestMethod]
        public void Create()
        {
            Index index;
            var iRepository = new SearchRepository.IndexRepository();
            var indexAdd = new Index()
            {
                Name = "telindex", //please be aware index name should contain only lowercase letters
                Fields = new[]
                     {
                    new Field("telNo", DataType.String) { IsKey = true }, // Id (IsKey = true) field should be edm.string !!
                    new Field("firstName", DataType.String) { IsSearchable = true, IsFilterable = true },
                    new Field("lastName", DataType.String) { IsSearchable = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new Field("telType", DataType.String) { IsSearchable = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new Field("tags", DataType.Collection(DataType.String)) { IsSearchable = true, IsFilterable = true, IsFacetable = true },
                    new Field("locationMargin", DataType.Double) { IsSortable = true, IsFilterable = true },
                    new Field("isPersonal", DataType.Boolean) { IsFilterable = true, IsFacetable = true }
                }

            };

            Task.Run(async () =>
            {
                index = await iRepository.CreateAsync(indexAdd);
                Assert.IsNotNull(index);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void GetAll()
        {
            var iRepository = new SearchRepository.IndexRepository();
            Task.Run(async () =>
            {
                var list = await iRepository.GetAsync();
                Assert.IsNotNull(list);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void Delete()
        {
            var iRepository = new SearchRepository.IndexRepository();
            Task.Run(async () =>
            {
                bool isSuccess = false;
                //get first if exists
                var firstIndex = await iRepository.GetAsync();
                if (firstIndex.Count > 0)
                {
                    isSuccess = await iRepository.DeleteAsync(firstIndex[0]);
                }
                Assert.AreEqual(true, isSuccess);
            }).GetAwaiter().GetResult();
        }
    }
}
