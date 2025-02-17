using Microsoft.EntityFrameworkCore;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace trybe_hotel.Test.Test;

public class ContextTest : DbContext, ITrybeHotelContext
{
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Hotel> Hotels { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public ContextTest(DbContextOptions<ContextTest> options) : base(options)
    { }

}