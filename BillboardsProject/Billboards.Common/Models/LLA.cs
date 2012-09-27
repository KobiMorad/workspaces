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
 
    }
}
