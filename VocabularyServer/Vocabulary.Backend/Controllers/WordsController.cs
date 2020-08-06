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
    public class WordsController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wordSetId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        public Task<ActionResult<IEnumerable<WordView>>> GetAll(int wordSetId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wordView"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<ActionResult<WordView>> Create([FromBody]WordView wordView)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="wordView"></param>
        /// <returns></returns>
        [HttpPut]
        public Task Update([FromBody] WordView wordView)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public Task<ActionResult<WordView>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}