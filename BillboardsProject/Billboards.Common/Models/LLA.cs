using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billboards.Common.Models
{
    public struct LLA : IEquatable<LLA>
    {
        public double Longtitude { get; private set; }
        public double Laltitude { get; private set; }

        public LLA(double laltitude, double longtitude):this()
        {           
            Laltitude = laltitude;
            Longtitude = longtitude;
        }

        public override int GetHashCode()
        {
            return Laltitude.GetHashCode() ^  Laltitude.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            LLA lla = (LLA)obj;
            return Equals(lla );
        }

        public bool Equals(LLA other)
        { 

            if (this.Laltitude != other.Laltitude) return false;
            if (this.Longtitude != other.Laltitude) return false;

            return true;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", Laltitude, Longtitude);
        }

        public static object TryParse(string value)
        {
            var parts = value.Split(',');

            if (parts.Length != 2)
            {
                return null;
            }

            int x, y;
            if (int.TryParse(parts[0], out x) && int.TryParse(parts[1], out y))
            {
                return new LLA { Longtitude = x, Laltitude = y };
            }

            return null;
        }
    }
}
