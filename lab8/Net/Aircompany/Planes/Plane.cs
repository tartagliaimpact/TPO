using System.Collections.Generic;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        public string planeModel;
        public int planeMaxSpeed;
        public int planeMaxFlightDistance;
        public int planeMaxLoadCapacity;

        public Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            planeModel = model;
            planeMaxSpeed = maxSpeed;
            planeMaxFlightDistance = maxFlightDistance;
            planeMaxLoadCapacity = maxLoadCapacity;
        }

        public string GetModel()
        {
            return planeModel;
        }

        public int GetMaxSpeed()
        {
            return planeMaxSpeed;
        }

        public int GetMAXFlightDistance()
        {
            return planeMaxFlightDistance;
        }

        public int GetMAXLoadCapacity()
        {
            return planeMaxLoadCapacity;
        }

        public override string ToString()
        {
            return "Plane{" +
                "model='" + planeModel + '\'' +
                ", maxSpeed=" + planeMaxSpeed +
                ", maxFlightDistance=" + planeMaxFlightDistance +
                ", maxLoadCapacity=" + planeMaxLoadCapacity +
                '}';
        }

        public override bool Equals(object planeForEquals)
        {
            var plane = planeForEquals as Plane;
            return plane != null &&
                   planeModel == plane.planeModel &&
                   planeMaxSpeed == plane.planeMaxSpeed &&
                   planeMaxFlightDistance == plane.planeMaxFlightDistance &&
                   planeMaxLoadCapacity == plane.planeMaxLoadCapacity;
        }

        public override int GetHashCode()
        {
            var hashCode = -1043886837;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(planeModel);
            hashCode = hashCode * -1521134295 + planeMaxSpeed.GetHashCode();
            hashCode = hashCode * -1521134295 + planeMaxFlightDistance.GetHashCode();
            hashCode = hashCode * -1521134295 + planeMaxLoadCapacity.GetHashCode();
            return hashCode;
        }        

    }
}
