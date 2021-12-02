using ALazy.Dev.LaComponents;
using ALazy.Dev.Models.LaData;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ALazy.Dev.BaseComponents
{
    public class LaException : Exception
    {
        public LaException(string message) : base(message)
        {
        }
    }

    public class LaController<TStore, TModel, TRequestModel> : ControllerBase 
        where TModel : LaModel 
        where TRequestModel : LaRequestModel<TModel> 
        where TStore : LaStore<TModel, TRequestModel>
    {
        protected LaAppDBContext _context { get; set; }
        protected TStore _store { get; set; }

        public LaController(LaAppDBContext context, TStore store)
        {
            _context = context;
            _store = store;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(TRequestModel request)
        {
            try
            {
                var m = _store.Create(request);
                return Ok(new {ID = m.ID});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
