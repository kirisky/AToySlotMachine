using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using SMachine.API.Middlewares;

namespace SMachine.API.Tests.Middlewares
{
    [TestFixture]
    public class ValidationSymbolMapsMiddlewareTests
    {
        private SymbolMapHelper _helper;
        private Mock<RequestDelegate> _next;
        private ValidationSymbolMapsMiddleware _middleware;
        private DefaultHttpContext _context;

        // private Mock<HttpContext> _context;
        private Mock<HttpRequest> _httpRequest;

        [SetUp]
        public void SetUp()
        {
            _helper = new SymbolMapHelper();
            _next = new Mock<RequestDelegate>();
            _middleware = new ValidationSymbolMapsMiddleware(_next.Object);
            // _context = new Mock<HttpContext>();
            _httpRequest = new Mock<HttpRequest>();

            _context = new DefaultHttpContext();
        }

        [Test]
        public async Task InvokeAsync_ValidSymbolMap_ReturnJsonOfTheSymbolMap()
        {
            var jsonOfTheSymbolMap = 
                JsonConvert.SerializeObject(_helper.SymbolMapWithThreeCherries);
            _context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(jsonOfTheSymbolMap));

            await _middleware.InvokeAsync(_context);

            string newJsonOfTheSymbolMap;
            using (var reader = new StreamReader(_context.Request.Body))
            {
                newJsonOfTheSymbolMap = await reader.ReadToEndAsync(); 
            }

            _next.Verify(o => o(_context));
            Assert.That(newJsonOfTheSymbolMap, Is.EqualTo(jsonOfTheSymbolMap));
        }

        [Test]
        public void InvokeAsync_InvalidSymbolMap_ThrowInvalidDataException()
        {
            var jsonOfTheSymbolMap = 
                JsonConvert.SerializeObject(_helper.SymbolMapWithAnUnavailableSymbolType);
            _context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(jsonOfTheSymbolMap));

            Assert.That(
                () => _middleware.InvokeAsync(_context), 
                Throws.Exception.TypeOf<InvalidDataException>()
            );
        }

    }
}