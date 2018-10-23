// <copyright file="EnvelopeParser.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;

namespace Envelopes
{
    /// <summary>
    /// Parse the input string and returns the sides of envelopes
    /// </summary>
    public static class EnvelopeParser
    {
        /// <summary>
        /// The valid parameters count in command line
        /// </summary>
        private const int PARAMETERS_COUNT = 4;

        /// <summary>
        /// Parses the specified arguments
        /// </summary>
        /// <param name="args">The arguments from command line</param>
        /// <returns>The sides of two envelopes</returns>
        /// <exception cref="ArgumentException">
        /// Please, add arguments!
        /// or
        /// You do not have correct number of arguments!
        /// or
        /// You arguments are not valid! Cannot convert to float! Check your input parameters!
        /// </exception>
        public static float[] Parse(string[] args)
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

        /// <summary>
        /// Parses the specified string
        /// </summary>
        /// <param name="arg">The string with envelope`s sides</param>
        /// <returns>The sides of two envelopes</returns>
        public static float[] Parse(string arg)
        {
            arg = arg.Trim().Replace("  ", " ");
            string[] parameters = arg.Split(new char[] { ' ' });
            return EnvelopeParser.Parse(parameters);
        }
    }
}