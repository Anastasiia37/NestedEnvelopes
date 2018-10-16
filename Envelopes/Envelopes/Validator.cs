using System;

namespace Envelopes
{
    public static class Validator
    {
        private const int PARAMETERS_COUNT = 4;

        public static float[] Validate(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException("Please, add arguments!");
            }

            if (args.Length != PARAMETERS_COUNT)
            {
                throw new ArgumentException("You do not have correct number of arguments!");
            }
                        
            float[] sides = new float[4];
            if (!float.TryParse(args[0], out sides[0]) || !float.TryParse(args[1], out sides[1]) 
                || !float.TryParse(args[2], out sides[2]) || !float.TryParse(args[3], out sides[3]))
            {
                throw new ArgumentException("You arguments are not valid! Cannot conver to float! Check your input parameters!");
            }

            return sides;           
        }

        public static float[] Validate(string arg)
        {
            arg = arg.Trim().Replace("  ", " ");
            string[] parameters = arg.Split(new char[] { ' ' });
            return Validator.Validate(parameters);
        }
    }
}
