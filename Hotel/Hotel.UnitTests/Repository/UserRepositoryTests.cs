using FluentAssertions;
using Hotel.DataAccess.Entities;
using Hotel.DataAccess;
using NUnit.Framework;


namespace Hotel.UnitTests.Repository
{
    [TestFixture]
    [Category("Integration")]
    public class UserRepositoryTests : RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllUsersTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var users = new UserEntity[]
            {
            new UserEntity()
            {
                Name = "user1",
                Surname = "test1",
                Patronymic = "1",
                Birthday = new DateTime(2000, 12, 1),
                PhoneNumber = "89102558965",
                Email = "user1@gmail.com",
                ImageUrl = "image1.jpg",
                ExternalId = Guid.NewGuid(),
                PasswordHash = "*",
            },
            new UserEntity()
            {
                Name = "user2",
                Surname = "test2",
                Patronymic = "2",
                Birthday = new DateTime(2000, 4, 10),
                PhoneNumber = "89523058475",
                Email = "user2@gmail.com",
                ImageUrl = "image2.jpg",
                ExternalId = Guid.NewGuid(),
                PasswordHash = "**",
            },
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            //execute
            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUsers = repository.GetAll();

            //assert        
            actualUsers.Should().BeEquivalentTo(users);
        }

        [Test]
        public void GetAllUsersWithFilterTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var users = new UserEntity[]
            {
            new UserEntity()
            {
                Name = "user1",
                Surname = "test1",
                Patronymic = "1",
                Birthday = new DateTime(2000, 12, 1),
                PhoneNumber = "89102558965",
                Email = "user1@gmail.com",
                ImageUrl = "image1.jpg",
                ExternalId = Guid.NewGuid(),
                PasswordHash = "*",
            },
            new UserEntity()
            {
                Name = "user2",
                Surname = "test2",
                Patronymic = "2",
                Birthday = new DateTime(2000, 4, 10),
                PhoneNumber = "89523058475",
                Email = "user2@gmail.com",
                ImageUrl = "image2.jpg",
                ExternalId = Guid.NewGuid(),
                PasswordHash = "**",
            },
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            //execute
            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUsers = repository.GetAll(x => x.Name == "user1").ToArray();

            //assert
            actualUsers.Should().BeEquivalentTo(users.Where(x => x.Name == "user1"));
        }

        [Test]
        public void SaveNewUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            //execute
            var user = new UserEntity()
            {
                Name = "user1",
                Surname = "test1",
                Patronymic = "1",
                Birthday = new DateTime(2000, 12, 1),
                PhoneNumber = "89102558965",
                Email = "user1@gmail.com",
                ImageUrl = "image1.jpg",
                ExternalId = Guid.NewGuid(),
                PasswordHash = "*",
            };
            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Save(user);

            //assert
            var actualUser = context.Users.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user, options => options
                .Excluding(x => x.Id)
                .Excluding(x => x.ModificationTime)
                .Excluding(x => x.CreationTime)
                .Excluding(x => x.ExternalId));
            actualUser.Id.Should().NotBe(default);
            actualUser.ModificationTime.Should().NotBe(default);
            actualUser.CreationTime.Should().NotBe(default);
            actualUser.ExternalId.Should().NotBe(Guid.Empty);
        }

        [Test]
        public void UpdateUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var user = new UserEntity()
            {
                Name = "user1",
                Surname = "test1",
                Patronymic = "1",
                Birthday = new DateTime(2000, 12, 1),
                PhoneNumber = "89102558965",
                Email = "user1@gmail.com",
                ImageUrl = "image1.jpg",
                ExternalId = Guid.NewGuid(),
                PasswordHash = "*",
            };
            context.Users.Add(user);
            context.SaveChanges();

            //execute
            user.Name = "new name1";
            user.Surname = "new name2";
            user.Patronymic = "new name3";
            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Save(user);

            //assert
            var actualUser = context.Users.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user);
        }

        [Test]
        public void DeleteUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();
           
            var user = new UserEntity()
            {
                Name = "user1",
                Surname = "test1",
                Patronymic = "1",
                Birthday = new DateTime(2000, 12, 1),
                PhoneNumber = "89102558965",
                Email = "user1@gmail.com",
                ImageUrl = "image1.jpg",
                ExternalId = Guid.NewGuid(),
                PasswordHash = "*",
            };
            context.Users.Add(user);
            context.SaveChanges();

            //execute
            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Delete(user);

            //assert
            context.Users.Count().Should().Be(0);
        }

        [Test]
        public void GetUserByIdTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var users = new UserEntity[]
            {
            new UserEntity()
            {
                Name = "user1",
                Surname = "test1",
                Patronymic = "1",
                Birthday = new DateTime(2000, 12, 1),
                PhoneNumber = "89102558965",
                Email = "user1@gmail.com",
                ImageUrl = "image1.jpg",
                ExternalId = Guid.NewGuid(),
                PasswordHash = "*",
            },
            new UserEntity()
            {
                Name = "user2",
                Surname = "test2",
                Patronymic = "2",
                Birthday = new DateTime(2000, 4, 10),
                PhoneNumber = "89523058475",
                Email = "user2@gmail.com",
                ImageUrl = "image2.jpg",
                ExternalId = Guid.NewGuid(),
                PasswordHash = "**",
            },
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            //case 1 
            //execute
            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUser = repository.GetById(users[0].Id);

            //assert
            actualUser.Should().BeEquivalentTo(users[0]);

            //case2
            //execute
            actualUser = repository.GetById(5);

            //assert
            actualUser.Should().BeNull();
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
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();
            }
        }
    }
}
