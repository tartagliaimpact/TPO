using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private List<Plane> planes = new List<Plane>(){
           new PassengerPlane("Boeing-737", 900, 12000, 60500, 164),
           new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 192),
           new PassengerPlane("Boeing-747", 980, 16100, 70500, 242),
           new PassengerPlane("Airbus A320", 930, 11800, 65500, 188),
           new PassengerPlane("Airbus A330", 990, 14800, 80500, 222),
           new PassengerPlane("Embraer 190", 870, 8100, 30800, 64),
           new PassengerPlane("Sukhoi Superjet 100", 870, 11500, 50500, 140),
           new PassengerPlane("Bombardier CS300", 920, 11000, 60700, 196),
           new MilitaryPlane("B-1B Lancer", 1050, 21000, 80000, MilitaryType.BOMBER),
           new MilitaryPlane("B-2 Spirit", 1030, 22000, 70000, MilitaryType.BOMBER),
           new MilitaryPlane("B-52 Stratofortress", 1000, 20000, 80000, MilitaryType.BOMBER),
           new MilitaryPlane("F-15", 1500, 12000, 10000, MilitaryType.FIGHTER),
           new MilitaryPlane("F-22", 1550, 13000, 11000, MilitaryType.FIGHTER),
           new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT)
        };

        private PassengerPlane planeWithMaxPassengerCapacity = new PassengerPlane("Boeing-747", 980, 16100, 70500, 242);

        [Test]
        public void VerifyPlanesTypeExistInAirport()
        {
            Airport airport = new Airport(planes);
            List<MilitaryPlane> transportMilitaryPlanes = airport.GetTransportMilitaryPlanes().ToList();

            Assert.True(airport.GetTransportMilitaryPlanes()
                .Any(militaryPlane => militaryPlane.PlaneTypeIs() == MilitaryType.TRANSPORT));
        }

        [Test]
        public void VerifyPassengerPlaneWithMaxCapacityExists()
        {
            Airport airport = new Airport(planes);
            Assert.IsNotNull(airport.GetPassengerPlaneWithMaxPassengersCapacity());
        }

        [Test]
        public void VerifyPlanesSortedByMaxLoadCapacity()
        {
            Airport airport = new Airport(planes);
            airport = airport.SortByMaxLoadCapacity();
            List<Plane> planesSortedByMaxLoadCapacity = airport.GetPlanes().ToList();
            Assert.True(planesSortedByMaxLoadCapacity
                .Select((plane, index) => new { Plane = plane, Index = index })
                .All(pair => pair.Index == 0 || pair.Plane.GetMAXLoadCapacity() >= planesSortedByMaxLoadCapacity[pair.Index - 1].GetMAXLoadCapacity()));
        }
    }
}
