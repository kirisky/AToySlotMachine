using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using src.Backend.SMachine.API.DTOs;
using src.Backend.SMachine.API.Utils;

namespace SMachine.API.Middlewares
{
    public class ValidationSymbolMapsMiddleware
    {
        private RequestDelegate _next;

        public ValidationSymbolMapsMiddleware(RequestDelegate next)
        {
            _next = next; 
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalContent = GetBodyFromRequest(context.Request).Result;
            var symbolMap = JsonConvert.DeserializeObject<SymbolMap>(originalContent);
            var winLinesBuilder = new WinLinesBuilder(symbolMap);

            // todo: write logs here
            if (!VerifyLine(winLinesBuilder.TopLine))
                throw new InvalidDataException("Data in Top-Line has wrong type of the symbols");

            if (!VerifyLine(winLinesBuilder.CenterLine))
                throw new InvalidDataException("Data in Center-Line has wrong type of the symbols");

            if (!VerifyLine(winLinesBuilder.BottomLine))
                throw new InvalidDataException("Data in Bottom-Line has wrong type of the symbols");

            var json = new StringContent(originalContent, Encoding.UTF8, "application/json");
            context.Request.Body = await json.ReadAsStreamAsync();
            
            await _next(context);
        }

        private async Task<string> GetBodyFromRequest(HttpRequest request)
        {
            using (var reader = new StreamReader(request.Body))
            {
                return await reader.ReadToEndAsync();
            }

        }

        private bool VerifyLine(IList<Symbol> winLine)
        {
            if (winLine.Any<Symbol>(s => s < Symbol.None || s > Symbol.Cherry))
                return false;

            return true;
        }
    }
}