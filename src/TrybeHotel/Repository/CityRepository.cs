using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly ITrybeHotelContext _context;
        public CityRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 2. Desenvolva o endpoint GET /city
        public IEnumerable<CityDto> GetCities()
        {
            try
            {
                var response = _context.Cities.Select(e => new CityDto()
                {
                    cityId = e.CityId,
                    name = e.Name
                }).ToList();

                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // 3. Desenvolva o endpoint POST /city
        public CityDto AddCity(City city)
        {
            throw new NotImplementedException();
        }

    }
}