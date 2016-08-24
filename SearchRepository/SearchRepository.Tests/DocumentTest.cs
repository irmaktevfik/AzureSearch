using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Azure.Search.Models;
using System.Collections.Generic;
using SearchRepository.Tests.Models;
using System.Threading.Tasks;

namespace SearchRepository.Tests
{
    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void Upload()
        {
            var dRepository = new SearchRepository.DocumentRepository();
            var lst = new Telephone[]
            {
                 new Telephone()
                 {
                    FirstName = "Leonel",
                    LastName = "Messi",
                    IsPersonal = true,
                    LocationMargin = 12.2,
                    Tags = new[] { "Football", "Soccer", "Famous" },
                    TelNo = "987754456",
                    TelType = "Home"
                 },
                 new Telephone()
                 {
                    FirstName = "George",
                    LastName = "Something",
                    IsPersonal = true,
                    LocationMargin = 12,
                    Tags = new[] { "Funny", "Made", "Name" },
                    TelNo = "987754452",
                    TelType = "Home"
                 },
                 new Telephone()
                 {
                    FirstName = "Gennaro",
                    LastName = "Contaldo",
                    IsPersonal = false,
                    LocationMargin = 12,
                    Tags = new[] { "Food", "Cook", "Italian" },
                    TelNo = "987754450",
                    TelType = "Work"
                 },
                 new Telephone()
                 {
                    FirstName = "Ronnie",
                    LastName = "Coleman",
                    IsPersonal = false,
                    LocationMargin = 12,
                    Tags = new[] { "Bodybuilding", "Gym", "Olympia" },
                    TelNo = "987754234",
                    TelType = "Work"
                 }
            };

            Task.Run(async () =>
            {
                var result = await dRepository.UploadBatchAsync(lst,"telindex");
                Assert.AreEqual(true, result);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void Search()
        {
            var repo = new SearchRepository.DocumentRepository();
            Task.Run(async () =>
            {
              var results = await repo.SearchDocuments<Telephone>("telindex", "Bodybuilding");
            }).GetAwaiter().GetResult();
        }
    }
}
