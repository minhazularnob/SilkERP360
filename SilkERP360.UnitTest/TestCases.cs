using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SilkERP360.UnitTest
{
    [TestClass]
    public class TestCases
    {
        [TestMethod]
        public async Task Call_GetAllDesignation_API()
        {
            string url = TestCaseConfiguation.url + "DesignationService.asmx/GetAllDesignation";

            ulong companyCode = 110000000001;

            using (var client = new HttpClient())
            {
                var content = new StringContent(
                    "{ \"IP_ui64_companyCode\": " + companyCode + " }",
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();

                Assert.IsTrue(response.IsSuccessStatusCode, "API call failed!");
                Assert.IsFalse(string.IsNullOrWhiteSpace(result), "Empty response!");
            }
        }
    }
}
