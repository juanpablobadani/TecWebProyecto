using AutoMapper;
using ProyectoFinalTecWeb.Data.Entities;
using ProyectoFinalTecWeb.Data.Repository;
using ProyectoFinalTecWeb.Exceptions;
using ProyectoFinalTecWeb.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoFinalTecWeb.Services
{
    public class GuestService : IGuestService
    {
        private IHotelRepository hotelRepository;
        private readonly IMapper mapper;

        public GuestService(IHotelRepository hotelRepository, IMapper mapper)
        {
            this.hotelRepository = hotelRepository;
            this.mapper = mapper;
        }

        private HashSet<string> allowedOrderByValues = new HashSet<string>()
        {
            "Id",
            "Name",
            "Lastname",
            "Ci",
            "Gender",
            "RoomId"
        };


        private async Task ValidateRoom(int id)
        {
            var room = await hotelRepository.GetRoomAsync(id);
            if (room == null)
            {
                throw new NotFoundItemException($"cannot found room with id:{id}");
            }
        }

        public async Task<IEnumerable<Guest>> GetGuestsAsync(int roomId)
        {
            //ValidateRoom(roomId);
            string orderBy = "Id";
            var orderByToLower = orderBy.ToLower();
            var Guestentities = await hotelRepository.GetGuestsAsync(roomId);
            return mapper.Map<IEnumerable<Guest>>(Guestentities);
        }

        public async Task<Guest> GetGuestAsync(int id, int roomId)
        {
            var guestEntity = await hotelRepository.GetGuestAsync(id);
            if (guestEntity == null)
            {
                throw new NotFoundItemException("Guest not found");
            }

            return mapper.Map<Guest>(guestEntity);
        }

        public async Task<Guest> CreateGuest(int roomId, Guest guest)
        {
            if (guest.RoomId != null && roomId != guest.RoomId)
            {
                throw new BadRequestOperationException("URL equipo id and Jugador.EquipoId should be equal");
            }

            guest.RoomId = roomId;
            await ValidateRoom(roomId);
            var guestEntity = mapper.Map<GuestEntity>(guest);
           // guestEntity.Room = null;  
            hotelRepository.CreateGuest(guestEntity);
            if (await hotelRepository.SaveChangesAsync())
            {
                return mapper.Map<Guest>(guestEntity);
            }
            throw new Exception("there where and error with the DB");
        }

        public async Task<bool> DeleteGuestAsync(int roomId, int id)
        {
            await ValidateRoom(roomId);
            await hotelRepository.DeleteGuestAsync(id);
            if (await hotelRepository.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<Guest> UpdateGuestAsync(int id, int roomId, Guest guest)
        {

            if (id != guest.Id)
            {
                throw new NotFoundItemException($"not found guest with id:{id}");
            }

            await ValidateGuestUpdate(id, roomId, guest);
            guest.Id = id;
            guest.RoomId = roomId;
            var guestEntity = mapper.Map<GuestEntity>(guest);
            hotelRepository.UpdateGuestAsync(guestEntity);
            if (await hotelRepository.SaveChangesAsync())
            {
                return mapper.Map<Guest>(guestEntity);
            }
            throw new Exception("there were an error with the BD");
        }

        private async Task ValidateGuestUpdate(int id, int roomId, Guest Editguest)
        {
            var room = await hotelRepository.GetRoomAsync(roomId);
            if (room == null)
            {
                throw new NotFoundItemException($"CanNot found Room with id {roomId}");
            }

            var guest = await hotelRepository.GetGuestAsync(id);
            if (guest == null)
            {
                throw new NotFoundItemException($"CanNot found Room with id {id}");
            }
        }
    }
}
