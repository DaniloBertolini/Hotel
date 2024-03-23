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
            try
            {
                _context.Cities.Add(city);
                _context.SaveChanges();
                var newCity = _context.Cities.First(e => e.CityId == city.CityId);
                var response = new CityDto()
                {
                    cityId = newCity.CityId,
                    name = newCity.Name
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