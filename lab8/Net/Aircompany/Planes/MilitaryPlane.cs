using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        public MilitaryType planeType;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            planeType = type;
        }

        public override bool Equals(object planeForEquals)
        {
            var plane = planeForEquals as MilitaryPlane;
            return plane != null &&
                   base.Equals(planeForEquals) &&
                   planeType == plane.planeType;
        }

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + planeType.GetHashCode();
            return hashCode;
        }

        public MilitaryType PlaneTypeIs()
        {
            return planeType;
        }


        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", type=" + planeType +
                    '}');
        }        
    }
}
