using Microsoft.EntityFrameworkCore;
using ProyectoFinalTecWeb.Data.Entities;
using ProyectoFinalTecWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalTecWeb.Data.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private List<Guest> guests = new List<Guest>();
        private HotelDBContext hotelDBContext;

        public HotelRepository(HotelDBContext hotelDBContext)
        {
            this.hotelDBContext = hotelDBContext;

        }

        public void CreateGuest(GuestEntity guest)
        {
            hotelDBContext.Entry(guest.Room).State = EntityState.Unchanged;
            hotelDBContext.Guests.Add(guest);
        }

        public void CreateRoom(RoomEntity room)
        {
           hotelDBContext.Rooms.Add(room);
        }

        public async Task DeleteGuestAsync(int id)
        {
            var guest = await hotelDBContext.Guests.SingleAsync(a => a.Id == id);
            hotelDBContext.Guests.Remove(guest);
        }

        public async Task DeleteRoomAsync(int id)
        {
            var room = await hotelDBContext.Rooms.SingleAsync(r => r.Id == id);
            hotelDBContext.Rooms.Remove(room);
        }

        public void DetachEntity<T>(T entity) where T : class
        {
            hotelDBContext.Entry(entity).State = EntityState.Detached;
        }

        public async Task<GuestEntity> GetGuestAsync(int id)
        {
            IQueryable<GuestEntity> query = hotelDBContext.Guests;
            query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<GuestEntity>> GetGuestsAsync(int roomId)
        {
            IQueryable<GuestEntity> query = hotelDBContext.Guests.Where(x => x.Room.Id == roomId);
            query = query.AsNoTracking().Where(x => x.Room.Id == roomId);
            return await query.ToArrayAsync();
        }

        public async Task<RoomEntity> GetRoomAsync(int id, bool showGuest = false)
        {
            IQueryable<RoomEntity> query = hotelDBContext.Rooms;

            if (showGuest)
            {
                query = query.Include(a => a.Guests);
            }
            query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<RoomEntity>> GetRooms(string orderBy = "Id", bool showGuest = false)
        {
            IQueryable<RoomEntity> query = hotelDBContext.Rooms;

            if (showGuest)
            {
                query = query.Include(a => a.Guests);
            }

            switch (orderBy)
            {
                case "id":
                    query = query.OrderBy(a => a.Id);
                    break;
                case "name":
                    query = query.OrderBy(a => a.Name);
                    break;
                case "description":
                    query = query.OrderBy(a => a.Description);
                    break;

                case "gender":
                    query = query.OrderBy(a => a.Price);
                    break;
                default:
                    break;
            }

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await hotelDBContext.SaveChangesAsync()) > 0;
        }

        public void UpdateGuestAsync(GuestEntity guest)
        {
            hotelDBContext.Entry(guest.Room).State = EntityState.Unchanged;
            hotelDBContext.Guests.Update(guest);
        }

        public void UpdateRoom(RoomEntity room)
        {
            hotelDBContext.Rooms.Update(room);
        }
    }
}
