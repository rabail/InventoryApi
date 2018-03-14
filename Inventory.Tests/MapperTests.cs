using System;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementService;
using NSubstitute;
using NUnit.Framework;

namespace Inventory.Tests
{
    [TestFixture]
    public class MapperTests
    {
        InventoryModel schedule;
        IInputHelper helper;

        [SetUp]
        public void Setup()
        {
            schedule = new InventoryModel
            {
                AllowedArrivalDays = new InventoryModel.Schedule
                {
                    Sunday = true,
                    Monday = true,
                    Tuesday = true,
                    Wednesday = true,
                    Thursday = true,
                    Friday = true,
                    Saturday = true
                },
                AllowedDepartureDays = new InventoryModel.Schedule
                {
                    Sunday = true,
                    Monday = true,
                    Tuesday = true,
                    Wednesday = true,
                    Thursday = true,
                    Friday = true,
                    Saturday = true
                }
            };

            helper = Substitute.For<IInputHelper>();
            helper.GetInputAsString().Returns(schedule);
        }

        [Test]
        public void ShoulMapAll()
        {
            var m = new Mapper(helper.GetInputAsString().Result);
            var mapper = m.GetMapper();
            Assert.NotNull(mapper);
            Assert.AreEqual(mapper.Count, 1);
            Assert.AreEqual(mapper[mapper.Keys.First()].Count, 7);
        }
    }
}
