using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalTecWeb.Exceptions;
using ProyectoFinalTecWeb.Models;
using ProyectoFinalTecWeb.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoFinalTecWeb.Controllers
{
    [Route("api/rooms/{roomId:int}/guests")]

    public class GuestsController : ControllerBase
    {
        private IGuestService guestService;

        public GuestsController(IGuestService guestService)
        {
            this.guestService = guestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuests(int roomId)
        {
            try
            {
                var guests = await guestService.GetGuestsAsync(roomId);
                return Ok(guests);
            }
            catch (BadRequestOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happend");
            }
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Guest>> GetGuest(int id, int roomId)
        {
            try
            {
                var guest = await this.guestService.GetGuestAsync(id, roomId);
                return Ok(guest);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happend");
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Guest>> UpdateGuest(int id, int roomId, [FromBody]Guest guest)
        {
            try
            {
                return Ok(await this.guestService.UpdateGuestAsync(id, roomId, guest));
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guest>> PostGuest(int roomId, [FromBody] Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postedGuest = await this.guestService.CreateGuest(roomId, guest);
            return Created($"/api/rooms/{roomId}/guests/{postedGuest.Id}", postedGuest);
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<bool>> DeleteGuest(int id, int roomId)
        {
            try
            {
                return Ok(await this.guestService.DeleteGuestAsync(roomId, id));
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }


    }
}
