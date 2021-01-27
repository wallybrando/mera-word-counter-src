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
    /// <summary>
    /// Texts Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TextsController : ControllerBase
    {
        private readonly ITextService _textService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textService">Text Service</param>
        public TextsController(ITextService textService)
        {
            _textService = textService;
        }

        /// <summary>
        /// Gets a list of Texts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Text>>> Get()
        {
            return await _textService.ReadTexts();
        }

        /// <summary>
        /// Gets a Text by specified Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Text>> Get(int id)
        {
            var response = await _textService.ReadText_ById(id);

            if (response == null) return NotFound();

            return response;
        }

        /// <summary>
        /// Creates new Text
        /// </summary>
        /// <param name="text">New Text</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Text text)
        {
            return await _textService.CreateText(text);
        }

        /// <summary>
        /// Updates Text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Text text)
        {
            await _textService.UpdateText(text);

            return NoContent();
        }

        /// <summary>
        /// Deletes Text by specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _textService.DeleteText(id);

            if (!response) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Calculates total number of words in text 
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns></returns>
        [HttpPost("calculate")]
        public async Task<ActionResult<int>> Calculate([FromBody] Text text)
        {
            try
            {
                return await _textService.CalculateNumberOfWords(text.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
