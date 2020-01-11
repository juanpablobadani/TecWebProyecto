using AutoMapper;
using Moq;
using ProyectoFinalTecWeb.Data;
using ProyectoFinalTecWeb.Data.Entities;
using ProyectoFinalTecWeb.Data.Repository;
using ProyectoFinalTecWeb.Exceptions;
using ProyectoFinalTecWeb.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HotelUnitTests
{
    public class HotelUnitTests
    {
        [Fact]
        public async void RoomService_shouldReturnExceptionIfNotFoundAsync()
        {
            int RoomId = 45;
            var MoqHotel = new Mock<IHotelRepository>();
            var roomEntity = new RoomEntity() { Id = 1, Name = 12, Description = "Matrimonial" };
            MoqHotel.Setup(r => r.GetRoomAsync(RoomId, false)).Returns(Task.FromResult(roomEntity));

            var profile = new HotelProfile();
            var config = new MapperConfiguration(f => f.AddProfile(profile));
            var mapper = new Mapper(config);

            var roomService = new RoomsService(MoqHotel.Object, mapper);

            await Assert.ThrowsAsync<NotFoundItemException>(() => roomService.GetRoomAsync(1, false));
        }
        [Fact]
        public async void DeleteRoom_ShouldReturnTrue()
        {
            int RoomId = 1;
            var MoqHotel = new Mock<IHotelRepository>();
            var roomEntity = new RoomEntity() { Id = 1, Name = 12, Description = "Matrimonial" };
            MoqHotel.Setup(r => r.DeleteRoomAsync(RoomId));

            var profile = new HotelProfile();
            var config = new MapperConfiguration(f => f.AddProfile(profile));
            var mapper = new Mapper(config);

            var roomService = new RoomsService(MoqHotel.Object, mapper);

            await Assert.ThrowsAsync<NotFoundItemException>(()=> roomService.DeleteRoomAsync(RoomId));
        }
    }
}
