using TrybeHotel.Models;
using TrybeHotel.Dto;
using System.Text.Json;

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
            try
            {
                Hotel hotelExists = _context.Hotels.Find(room.HotelId) ?? throw new Exception("Hotel not Found");

                _context.Rooms.Add(room);
                _context.SaveChanges();

                var newRoom = _context.Rooms.First(e => e.HotelId == room.HotelId);
                var response = new RoomDto()
                {
                    roomId = newRoom.RoomId,
                    name = newRoom.Name,
                    capacity = newRoom.Capacity,
                    image = newRoom.Image,
                    hotel = new HotelDto()
                    {
                        hotelId = hotelExists.HotelId,
                        name = hotelExists.Name,
                        address = hotelExists.Address,
                        // cityName = newRoom.Hotel
                        // cityId = hotelExists.HotelId,
                    }
                };

                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId)
        {
            try
            {
                var room = _context.Rooms.First(e => e.RoomId == RoomId);
                _context.Rooms.Remove(room);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}