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
    public class RoomsService : IRoomsService
    {
        private IHotelRepository roomsRepository;
        private readonly IMapper mapper;

        public RoomsService(IHotelRepository authorsRepository, IMapper mapper)
        {
            this.roomsRepository = authorsRepository;
            this.mapper = mapper;
        }

        private HashSet<string> allowedOrderByQueries = new HashSet<string>()
        {
            "Id",
            "Name",
            "Description",
            "Price"
        };
        public async Task<Room> AddRoomAsync(Room room)
        {
            var roomEntity = mapper.Map<RoomEntity>(room);

            roomsRepository.CreateRoom(roomEntity);
            if (await roomsRepository.SaveChangesAsync())
            {
                return mapper.Map<Room>(roomEntity);
            }

            throw new Exception("There were an error with the DB");
        }

        public async Task<bool> DeleteRoomAsync(int id)
        {
            await ValidateRoom(id);
            await roomsRepository.DeleteRoomAsync(id);
            if (await roomsRepository.SaveChangesAsync())
            {
                return true;
            }
            return false;
        }

        public async Task<Room> GetRoomAsync(int id, bool showGuests)
        {
            var room = await roomsRepository.GetRoomAsync(id);
            if (room == null)
            {
                throw new NotFoundItemException($"the room not found");
            }
            return mapper.Map<Room>(room);
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync(string orderBy, bool showGuests)
        {
            var orderByLower = orderBy.ToLower();
            if (!allowedOrderByQueries.Contains(orderBy))
            {
                throw new BadRequestOperationException($"invalid orderBy value: {orderBy} the only values allowed are {string.Join(", ", allowedOrderByQueries)}");
            }
            showGuests = true;
            var Roomentities = await roomsRepository.GetRooms(orderBy, showGuests);
            return mapper.Map<IEnumerable<Room>>(Roomentities);
        }

        public async Task<Room> UpdateRoomAsync(int id, Room room)
        {
            if (id != room.Id)
            {
                throw new NotFoundItemException($"not found room with id:{id}");
            }
            await ValidateRoom(id);
            room.Id = id;
            var roomEntity = mapper.Map<RoomEntity>(room);
            roomsRepository.UpdateRoom(roomEntity);
            if (await roomsRepository.SaveChangesAsync())
            {
                return mapper.Map<Room>(roomEntity);
            }
            throw new Exception("there were an error with the BD");
        }

        private async Task ValidateRoom(int id)
        {
            var room = await roomsRepository.GetRoomAsync(id);
            if (room == null)
            {
                throw new NotFoundItemException("invalid room to delete");
            }
            roomsRepository.DetachEntity(room);
        }
    }
}
