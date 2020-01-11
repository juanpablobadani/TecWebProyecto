using ProyectoFinalTecWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoFinalTecWeb.Services
{
    public interface IRoomsService
    {
        Task<IEnumerable<Room>> GetRoomsAsync(string orderBy, bool showGuests);
        Task<Room> GetRoomAsync(int id, bool showGuests);
        Task<Room> AddRoomAsync(Room room);
        Task<Room> UpdateRoomAsync(int id, Room room);
        Task<bool> DeleteRoomAsync(int id);
    }
}
