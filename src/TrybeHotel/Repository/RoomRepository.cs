using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            try
            {
                var response = (from room in _context.Rooms
                                join hotel in _context.Hotels on room.HotelId equals hotel.HotelId
                                select new RoomDto()
                                {
                                    roomId = room.RoomId,
                                    name = room.Name,
                                    capacity = room.Capacity,
                                    image = room.Image,
                                    hotel = new HotelDto()
                                    {
                                        hotelId = hotel.HotelId,
                                        name = hotel.Name,
                                        address = hotel.Address,
                                        cityId = hotel.City.CityId,
                                        cityName = hotel.City.Name
                                    }
                                }).ToList();

                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // 7. Desenvolva o endpoint POST /room
        public RoomDto AddRoom(Room room)
        {
            throw new NotImplementedException();
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId)
        {
            throw new NotImplementedException();
        }
    }
}