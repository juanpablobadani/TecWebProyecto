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
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private IRoomsService roomsService;

        public RoomsController(IRoomsService roomsService)
        {
            this.roomsService = roomsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoom(string orderBy = "Id", bool showGuest = false)
        {
            try
            {
                return Ok(await roomsService.GetRoomsAsync(orderBy, showGuest));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Room>> GetRooms(int id, bool showGuest = false)
        {
            try
            {
                var guest = await this.roomsService.GetRoomAsync(id, showGuest);
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

        [HttpPut("{id}")]
        public async Task<ActionResult<Room>> UpdateRoom(int id, [FromBody]Room room)
        {
            try
            {
                var guestUpDated = await this.roomsService.UpdateRoomAsync(id, room);
                return Ok(guestUpDated);
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
        public async Task<ActionResult<Room>> PostRoom([FromBody] Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postedRoom = await this.roomsService.AddRoomAsync(room);
            return Created($"/api/rooms/{postedRoom.Id}", postedRoom);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteRoom(int id)
        {
            try
            {
                return Ok(await this.roomsService.DeleteRoomAsync(id));
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
