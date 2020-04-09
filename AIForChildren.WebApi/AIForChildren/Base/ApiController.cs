using System.Collections.Generic;
using AIForChildren.Models.Client;
using Microsoft.AspNetCore.Mvc;

namespace AIForChildren.Base
{
    public class ApiController : Controller
    {

        [NonAction] // Bu non action belirtmezsek eğer asp.net bunu action olarak algılar ve .../Success miş gibi davranmasını sağlar.
        public IActionResult Success(string message = default, object data = default, object data2 = default,
            int code = 200)
        {
            return Ok(
                new AIReturn
                {
                    Success = true,
                    Message = message,
                    Data = data,
                    Data2 = data2,
                    Code = code
                }
            ); //Burada JSON' da dönebilirdim farketmez zaten döneceğim datadan o bunu anlıycak.
        }

        [NonAction]
        public IActionResult Error(string message = default, string internalMessage = default, object data = default,
            int code = 400, List<AIReturnError> errorMessage = null)
        {
            var rv = new AIReturn
            {
                Success = false,
                //User Message
                Message = message,
                //API User Message
                InternalMessage = internalMessage,
                Data = data,
                Code = code
            };

            if (rv.Code == 500)
                return StatusCode(500, rv);
            if (rv.Code == 401)
                return Unauthorized();
            if (rv.Code == 403)
                return Forbid();
            if (rv.Code == 404)
                return NotFound(rv);

            return BadRequest(rv);
        }
    }
}