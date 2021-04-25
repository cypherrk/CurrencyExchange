using System;

namespace ExternalWebApi.Utility
{
    public static class Utils
    {
        public static float RandomFloat()
        {
            double sample = new Random().NextDouble();
            return (float)sample;
        }

    }
}
