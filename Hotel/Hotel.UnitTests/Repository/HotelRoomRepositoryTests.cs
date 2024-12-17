using Hotel.DataAccess.Entities;
using Hotel.DataAccess;
using NUnit.Framework;
using FluentAssertions;

namespace Hotel.UnitTests.Repository
{
    [TestFixture]
    [Category("Integration")]
    public class HotelRoomRepositoryTests : RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllHotelRoomsTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
            var hotel = new HotelEntity()
            {
                Title = "Test",
                Info = "Test",
                Adress = "Test",
                PhoneNumber = "Test",
                Email = "Test",
                ExternalId = Guid.NewGuid(),
            };
            context.Hotels.Add(hotel);
            context.SaveChanges();

            var rooms = new HotelRoomEntity[]
            {
            new HotelRoomEntity()
            {
                Description = "description1",
                NumberOfGuests = 1,
                Price = 1,
                HotelId = hotel.Id,
                ExternalId = Guid.NewGuid(),
            },
            new HotelRoomEntity()
            {
                Description = "description2",
                NumberOfGuests = 2,
                Price = 2,
                HotelId = hotel.Id,
                ExternalId = Guid.NewGuid(),
            },
            };
            context.HotelRooms.AddRange(rooms);
            context.SaveChanges();

            //execute
            var repository = new Repository<HotelRoomEntity>(DbContextFactory);
            var actualRooms = repository.GetAll();

            //assert        
            actualRooms.Should().BeEquivalentTo(rooms, options => options.Excluding(x => x.Hotel));
        }

        [Test]
        public void GetAllHotelRoomsWithFilterTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var hotel = new HotelEntity()
            {
                Title = "Test",
                Info = "Test",
                Adress = "Test",
                PhoneNumber = "Test",
                Email = "Test",
                ExternalId = Guid.NewGuid(),
            };
            context.Hotels.Add(hotel);
            context.SaveChanges();

            var rooms = new HotelRoomEntity[]
            {
            new HotelRoomEntity()
            {
                Description = "description1",
                NumberOfGuests = 1,
                Price = 1,
                HotelId = hotel.Id,
                ExternalId = Guid.NewGuid(),
            },
            new HotelRoomEntity()
            {
                Description = "description2",
                NumberOfGuests = 2,
                Price = 2,
                HotelId = hotel.Id,
                ExternalId = Guid.NewGuid(),
            },
            };
            context.HotelRooms.AddRange(rooms);
            context.SaveChanges();

            //execute
            var repository = new Repository<HotelRoomEntity>(DbContextFactory);
            var actualRooms = repository.GetAll(x => x.NumberOfGuests == 1).ToArray();

            //assert
            actualRooms.Should().BeEquivalentTo(rooms.Where(x => x.NumberOfGuests == 1),
                options => options.Excluding(x => x.Hotel));
        }

        [Test]
        public void SaveNewHotelRoomTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            //execute
            var hotel = new HotelEntity()
            {
                Title = "Test",
                Info = "Test",
                Adress = "Test",
                PhoneNumber = "Test",
                Email = "Test",
                ExternalId = Guid.NewGuid(),
            };
            context.Hotels.Add(hotel);
            context.SaveChanges();

            var room = new HotelRoomEntity()
            {
                Description = "description1",
                NumberOfGuests = 1,
                Price = 1,
                HotelId = hotel.Id,
                ExternalId = Guid.NewGuid(),
            };
            var repository = new Repository<HotelRoomEntity>(DbContextFactory);
            repository.Save(room);

            //assert
            var actualRoom = context.HotelRooms.SingleOrDefault();
            actualRoom.Should().BeEquivalentTo(room, options => options.Excluding(x => x.Hotel)
                .Excluding(x => x.Id)
                .Excluding(x => x.ModificationTime)
                .Excluding(x => x.CreationTime)
                .Excluding(x => x.ExternalId));
            actualRoom.Id.Should().NotBe(default);
            actualRoom.ModificationTime.Should().NotBe(default);
            actualRoom.CreationTime.Should().NotBe(default);
            actualRoom.ExternalId.Should().NotBe(Guid.Empty);
        }

        [Test]
        public void UpdateHotelRoomTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var hotel = new HotelEntity()
            {
                Title = "Test",
                Info = "Test",
                Adress = "Test",
                PhoneNumber = "Test",
                Email = "Test",
                ExternalId = Guid.NewGuid(),
            };
            context.Hotels.Add(hotel);
            context.SaveChanges();

            var room = new HotelRoomEntity()
            {
                Description = "description1",
                NumberOfGuests = 1,
                Price = 1,
                HotelId = hotel.Id,
                ExternalId = Guid.NewGuid(),
            };
            context.HotelRooms.Add(room);
            context.SaveChanges();

            //execute
            room.Description = "new description";
            room.NumberOfGuests = 2;
            var repository = new Repository<HotelRoomEntity>(DbContextFactory);
            repository.Save(room);

            //assert
            var actualRoom = context.HotelRooms.SingleOrDefault();
            actualRoom.Should().BeEquivalentTo(room, options => options.Excluding(x => x.Hotel));
        }

        [Test]
        public void DeleteHotelRoomTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var hotel = new HotelEntity()
            {
                Title = "Test",
                Info = "Test",
                Adress = "Test",
                PhoneNumber = "Test",
                Email = "Test",
                ExternalId = Guid.NewGuid(),
            };
            context.Hotels.Add(hotel);
            context.SaveChanges();

            var room = new HotelRoomEntity()
            {
                Description = "description1",
                NumberOfGuests = 1,
                Price = 1,
                HotelId = hotel.Id,
                ExternalId = Guid.NewGuid(),
            };
            context.HotelRooms.Add(room);
            context.SaveChanges();

            //execute
            var repository = new Repository<HotelRoomEntity>(DbContextFactory);
            repository.Delete(room);

            //assert
            context.HotelRooms.Count().Should().Be(0);
        }

        [Test]
        public void GetHotelRoomByIdTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var hotel = new HotelEntity()
            {
                Title = "Test",
                Info = "Test",
                Adress = "Test",
                PhoneNumber = "Test",
                Email = "Test",
                ExternalId = Guid.NewGuid(),
            };
            context.Hotels.Add(hotel);
            context.SaveChanges();

            var rooms = new HotelRoomEntity[]
            {
            new HotelRoomEntity()
            {
                Description = "description1",
                NumberOfGuests = 1,
                Price = 1,
                HotelId = hotel.Id,
                ExternalId = Guid.NewGuid(),
            },
            new HotelRoomEntity()
            {
                Description = "description2",
                NumberOfGuests = 2,
                Price = 2,
                HotelId = hotel.Id,
                ExternalId = Guid.NewGuid(),
            },
            };
            context.HotelRooms.AddRange(rooms);
            context.SaveChanges();

            //case 1 
            //execute
            var repository = new Repository<HotelRoomEntity>(DbContextFactory);
            var actualRoom = repository.GetById(rooms[0].Id);

            //assert
            actualRoom.Should().BeEquivalentTo(rooms[0], options => options.Excluding(x => x.Hotel));

            //case2
            //execute
            actualRoom = repository.GetById(5);

            //assert
            actualRoom.Should().BeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CleanUp();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        public void CleanUp()
        {
            using (var context = DbContextFactory.CreateDbContext())
            {
                context.HotelRooms.RemoveRange(context.HotelRooms);
                context.Hotels.RemoveRange(context.Hotels);
                context.SaveChanges();
            }
        }
    }
}
