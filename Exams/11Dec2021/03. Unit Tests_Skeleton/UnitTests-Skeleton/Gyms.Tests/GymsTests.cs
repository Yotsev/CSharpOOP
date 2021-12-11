using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void InvalidGymName()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym("", 2));
        }
        [Test]
        public void InvalidGymCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Gym", -2));
        }

        [Test]
        public void ValidGymName()
        {
            var gym = new Gym("Gym", 3);
            Assert.AreEqual("Gym", gym.Name);
        }
        [Test]
        public void ValidGymCapacity()
        {
            var gym = new Gym("Gym", 3);
            Assert.AreEqual(3, gym.Capacity);
        }
        [Test]
        public void ReturnsValidCount()
        {
            
            var gym1 = new Gym("Gym1", 4);
            gym1.AddAthlete(new Athlete("Pesho"));
            gym1.AddAthlete(new Athlete("Gosho"));
            gym1.AddAthlete(new Athlete("Ivan"));

            Assert.AreEqual(3, gym1.Count);
        }

        [Test]
        public void GymIsFull()
        {
            var gym1 = new Gym("Gym1", 3);
            gym1.AddAthlete(new Athlete("Pesho"));
            gym1.AddAthlete(new Athlete("Gosho"));
            gym1.AddAthlete(new Athlete("Ivan"));

            Assert.Throws<InvalidOperationException>(() => gym1.AddAthlete(new Athlete("Yogi")));
        }

        [Test]
        public void RemoveThrowExeption()
        {
            var gym1 = new Gym("Gym1", 3);
            gym1.AddAthlete(new Athlete("Pesho"));
            gym1.AddAthlete(new Athlete("Gosho"));
            Assert.Throws<InvalidOperationException>(() => gym1.RemoveAthlete("Ivan"));
        }
        [Test]
        public void RemoveMemeber()
        {
            var gym1 = new Gym("Gym1", 3);
            gym1.AddAthlete(new Athlete("Pesho"));
            gym1.AddAthlete(new Athlete("Gosho"));
            gym1.AddAthlete(new Athlete("Ivan"));
            gym1.RemoveAthlete("Pesho");
            Assert.AreEqual(2, gym1.Count);
            gym1.RemoveAthlete("Gosho");
            Assert.AreEqual(1, gym1.Count);

        }

        [Test]
        public void InjuredThrowExeption()
        {
            var gym1 = new Gym("Gym1", 3);
            gym1.AddAthlete(new Athlete("Pesho"));
            gym1.AddAthlete(new Athlete("Gosho"));
            gym1.AddAthlete(new Athlete("Ivan"));

            Assert.Throws<InvalidOperationException>(() => gym1.InjureAthlete("Yogi"));
        }

        [Test]
        public void ChangesStatus()
        {
            var gym1 = new Gym("Gym1", 3);
            gym1.AddAthlete(new Athlete("Pesho"));
            gym1.AddAthlete(new Athlete("Gosho"));
            gym1.AddAthlete(new Athlete("Ivan"));
            gym1.InjureAthlete("Pesho");
            Assert.IsTrue(gym1.InjureAthlete("Pesho").IsInjured);
        }

        [Test]
        public void ReportReturnscorrectInformation()
        {
            var gym1 = new Gym("Gym1", 1);
            gym1.AddAthlete(new Athlete("Pesho"));

            Assert.AreEqual($"Active athletes at Gym1: Pesho", gym1.Report());
        }
    }
}
