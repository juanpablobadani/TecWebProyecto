using ProyectoFinalTecWeb.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoFinalTecWeb.Data.Repository
{
    public interface IHotelRepository
    {
        //ROOMS
        Task<RoomEntity> GetRoomAsync(int id, bool showGuest = false);
        Task<IEnumerable<RoomEntity>> GetRooms(string orderBy = "Id", bool showGuest = false);
        Task DeleteRoomAsync(int id);
        void UpdateRoom(RoomEntity room);
        void CreateRoom(RoomEntity room);

        //GUESTS
        Task<IEnumerable<GuestEntity>> GetGuestsAsync(int roomId);
        Task<GuestEntity> GetGuestAsync(int id);
        void UpdateGuestAsync(GuestEntity guest);
        void CreateGuest(GuestEntity guest);
        Task DeleteGuestAsync(int id);


        Task<bool> SaveChangesAsync();
        void DetachEntity<T>(T entity) where T : class;
    }
}
