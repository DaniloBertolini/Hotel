using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 4. Desenvolva o endpoint GET /hotel
        public IEnumerable<HotelDto> GetHotels()
        {
            try
            {
                var response = _context.Hotels.Select(e => new HotelDto()
                {
                    hotelId = e.HotelId,
                    name = e.Name,
                    address = e.Address,
                    cityId = e.City.CityId,
                    cityName = e.City.Name
                }).ToList();

                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // 5. Desenvolva o endpoint POST /hotel
        public HotelDto AddHotel(Hotel hotel)
        {
            try
            {
                var cityExists = _context.Cities.Find(hotel.CityId) ?? throw new Exception("City not Found");

                _context.Hotels.Add(hotel);
                _context.SaveChanges();

                var newHotel = _context.Hotels.First(e => e.HotelId == hotel.HotelId);
                var response = new HotelDto()
                {
                    hotelId = newHotel.HotelId,
                    name = newHotel.Name,
                    address = newHotel.Address,
                    cityId = newHotel.City.CityId,
                    cityName = newHotel.City.Name
                };

                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}