using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mera.WordCounter.Server.Controllers.API.Common;
using Mera.WordCounter.Server.Interfaces.Services;
using Mera.WordCounter.Shared.Entities;
using Microsoft.Extensions.Logging;

namespace Mera.WordCounter.Server.Controllers.API.v1
{
    /// <summary>
    /// Texts Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TextsController : BaseController<ITextService, TextsController>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textService">Text Service</param>
        /// <param name="logger">Logger interface</param>
        public TextsController(ITextService textService, ILogger<TextsController> logger) : base(textService, logger)
        {
            
        }

        /// <summary>
        /// Gets a list of Texts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Text>>> Get()
        {
            try
            {
                Logger.LogInformation("Start: Getting detail information of 'Text' collection items");

                var response = await Service.ReadTexts();

                return response;
            }
            catch (Exception ex)
            {
                return ProcessException(ex);
            }
        }

        /// <summary>
        /// Gets a Text by specified Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Text>> Get(int id)
        {
            try
            {
                Logger.LogInformation($"Start: Getting item details for 'Text' with Id '{id}'");

                var response = await Service.ReadText_ById(id);

                if (response == null) return NotFound();

                return response;
            }
            catch (Exception ex)
            {
                return ProcessException(ex);
            }
        }

        /// <summary>
        /// Creates new Text
        /// </summary>
        /// <param name="text">New Text</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Text text)
        {
            try
            {
                Logger.LogInformation($"Start: Creating new item of type 'Text'");
                return await Service.CreateText(text);
            }
            catch (Exception ex)
            {
                return ProcessException(ex);
            }
        }

        /// <summary>
        /// Updates Text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Text text)
        {
            try
            {
                Logger.LogInformation($"Start: Updating item of type 'Text' with Id '{text.Id}'");
                await Service.UpdateText(text);

                return NoContent();
            }
            catch (Exception ex)
            {
                return ProcessException(ex);
            }
        }

        /// <summary>
        /// Deletes Text by specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Logger.LogInformation($"Start: Deleting item of type 'Text' with Id '{id}'");
                var response = await Service.DeleteText(id);

                if (!response) return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return ProcessException(ex);
            }
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
                Logger.LogInformation($"Start: Calculating number of words for item with Id '{text.Id}'");
                return await Service.CalculateNumberOfWords(text.Content);
            }
            catch (Exception ex)
            {
                return ProcessException(ex);
            }
        }
    }
}
