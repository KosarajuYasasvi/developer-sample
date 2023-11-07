using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        private static readonly Dictionary<(SwallowType, SwallowLoad), double> AirspeedVelocitiesInfo = new Dictionary<(SwallowType, SwallowLoad), double>
        {
            {(SwallowType.African,SwallowLoad.None),22 },
            {(SwallowType.African,SwallowLoad.Coconut),18 },
            {(SwallowType.European,SwallowLoad.None),20 },
            {(SwallowType.European,SwallowLoad.Coconut),16 },
        };

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            double airspeedVelocity = 0;
            try
            {
                if (AirspeedVelocitiesInfo.TryGetValue((Type, Load), out double airspeed))
                {
                    airspeedVelocity = airspeed;
                }
            }
            catch (Exception)
            {
                airspeedVelocity = -1;
            }
            return airspeedVelocity;
        }
    }
}