using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Server.Interfaces.Services;
using Mera.WordCounter.Shared.Entities;

namespace Mera.WordCounter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TextsController : ControllerBase
    {
        private readonly ApplicationDbContext context; // for removing
        private readonly ITextService textService;

        public TextsController(ApplicationDbContext context, ITextService textService)
        {
            this.context = context;
            this.textService = textService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Text>>> Get()
        {
            return await textService.ReadTexts();
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> PostCreate([FromBody] Text text)
        {
            return await textService.CreateText(text);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Text text)
        {
            try
            {
                //int result = 0;

                ////Trim whitespace from beginning and end of string
                //text.Content = text.Content.Trim();

                ////Necessary because foreach will execute once with empty string returning 1
                //if (text.Content == "")
                //    return 0;

                ////Ensure there is only one space between each word in the passed string
                //while (text.Content.Contains("  "))
                //{
                //    text.Content = text.Content.Replace("  ", " ");
                //}

                ////Count the words
                //foreach (string y in text.Content.Split(' '))
                //{
                //    result++;
                //}

                return await textService.CalculateNumberOfWords(text.Content);

                //return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
