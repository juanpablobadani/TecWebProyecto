using ProyectoFinalTecWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoFinalTecWeb.Services
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetGuestsAsync(int roomId);
        Task<Guest> GetGuestAsync(int id, int roomId);
        Task<Guest> UpdateGuestAsync(int id, int roomid, Guest guest);
        Task<Guest> CreateGuest(int roomId, Guest guest);
        Task<bool> DeleteGuestAsync(int roomId, int id);

    }
}
