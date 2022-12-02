using Microsoft.AspNetCore.Mvc;
using People_Data.HTTP;
using People_Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace People_Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DBHelper _db;
        public PeopleController(EF_DataContext eF_DataContext)
        {
            _db = new DBHelper(eF_DataContext);
        }
        // GET: api/<PeopleController>

        /// <summary>
        /// Gets the list of all People.
        /// </summary>
        /// <returns>The list of People.</returns>
        [HttpGet]
        //[Route("GetProducts")]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            ResponseType type=ResponseType.Success;
           
            
            try
            {
                var data=_db.GetPeople();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                    return NotFound(ResponseHandler.GetAppResponse(type, data));
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<PeopleController>/5
        /// <summary>
        /// Gets the information of a person by his Id.
        /// </summary>
        /// <returns>The information of a  required person.</returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            ResponseType type=ResponseType.Success;
            try
            {
                PeopleModel data = _db.GetbyID(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                    return NotFound(ResponseHandler.GetAppResponse(type, data));

                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        // POST api/<PeopleController>
        /// <summary>
        /// Creates an Object of People.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/SaveOrder
        ///     {        
        ///       "firstName": "Mike",
        ///       "lastName": "Andrew",
        ///       "age": 27        
        ///     }
        /// </remarks>
        /// <param name="People"></param>  
        /// /// <returns>A newly created employee</returns>
        /// <response code="201">Succes!!</response>
        /// <response code="400">Bad Response</response>  
        [HttpPost]

        [HttpPost]
        [Consumes(System.Net.Mime.MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
      //  [Route("SaveOrder")]
        public IActionResult Post([FromBody] PeopleModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                if (ModelState.IsValid)
                {
                    _db.CreateOrder(model);
                }
                ResponseHandler.GetAppResponse(type, model);
                return CreatedAtAction(nameof(Get), new { id = model.Id }, model); 
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<PeopleController>/5
        /// <summary>
        /// Update an Object of People.
        /// </summary>
       /// <param name = "People" > </param >
        /// /// <returns>A newly created employee</returns>
        /// <response code="204">No Content</response>
        /// <response code="404">Record Not Found</response>
        /// <response code="400">Bad Response</response>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
       // [Route("UpdateOrder")]
        public IActionResult Put([FromBody] PeopleModel model)
        {
            var data = _db.GetPeople();
            if (!data.Any())
            {
                return NoContent();
            }
            try
            {
                ResponseType type = ResponseType.Success;
                
                    var ct = _db.GetbyID(model.Id);
               
               
                if(ct != null)
                {
                    _db.SaveOrder(model);
                    return Ok(ResponseHandler.GetAppResponse(type, model));
                }
                else
                {
                    return NotFound(ResponseHandler.GetAppResponse(type, model));

                }
                //if (ModelState.IsValid)
                //{
                //    _db.SaveOrder(model);
                //}
               
            }
            catch (Exception ex)
            {
                return NotFound(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<PeopleController>/5
        /// <summary>
        /// Deletes an Object of People.
        /// </summary>
        /// <param name = "People" ></param >
        /// /// <returns>A newly created employee</returns>
        /// <response code="204">No Content</response>
        /// <response code="404">Record Not Found</response>
        /// <response code="400">Bad Response</response>
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            var db= _db.GetPeople();
            if (!db.Any())
            {
                return NoContent();
            }
            try
            {
                ResponseType type = ResponseType.Success;
                
                
                var ct= _db.GetbyID(id);
                if (ct != null)
                {
                    _db.DeleteOrder(id);
                    return Ok(ResponseHandler.GetAppResponse(type, id));
                }
                type = ResponseType.NotFound;
                return NotFound(ResponseHandler.GetAppResponse(type, id));

            }
            catch (Exception ex)
            {
                return NotFound(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        
        //[HttpPost]
        //[Route("SetById")]
        //public IActionResult PeepbyId(PeopleModel nmodel)
        //{
        //    try
        //    {
        //        ResponseType type = ResponseType.Success;
        //        _db.crbyId(nmodel);
        //        return Ok(ResponseHandler.GetAppResponse(type, "Updated!"));

        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ResponseHandler.GetExceptionResponse(ex));
        //    }
        //}
    }
}
