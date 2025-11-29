using CentralAPI;
using CentralAPI.Implementations;
using CentralAPI.Interfaces;
using Moq;
using System.Net.Http;

namespace APITests
{
    public class Tests
    {
        private Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private HttpClient _httpClient;
        IListings _listingsHandle;
        [SetUp]
        public void Setup()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://localhost:5001")
            };


            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(f => f.CreateClient(It.IsAny<string>()))
                .Returns(_httpClient);
            _listingsHandle = new ListingImpl(mockFactory.Object); 
        }

        [Test]
        public async Task GetNotByHospitalAsync()
        {
            var res = await _listingsHandle.GetOtherListings(1);
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            _httpClient?.Dispose();
        }
    }
}
