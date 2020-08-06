using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vocabilary.Views;

namespace Vocabulary.Backend.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController, Route("[controller]/[action]")]
    public class WordSetsController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<ActionResult<IEnumerable<WordSetView>>> Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public Task<ActionResult<IEnumerable<WordSetView>>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wordSetView"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<ActionResult<WordSetView>> Create([FromBody] WordSetView wordSetView)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wordSetView"></param>
        /// <returns></returns>
        [HttpPut]
        public Task<IActionResult> Update([FromBody] WordSetView wordSetView)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpDelete("{id}")]
        public Task<ActionResult<WordSetView>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
