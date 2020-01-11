using AutoMapper;
using ProyectoFinalTecWeb.Data.Entities;
using ProyectoFinalTecWeb.Models;

namespace ProyectoFinalTecWeb.Data
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            this.CreateMap<RoomEntity, Room>()
                .ReverseMap();

            this.CreateMap<GuestEntity, Guest>()
                .ReverseMap();
        }

    }
}
