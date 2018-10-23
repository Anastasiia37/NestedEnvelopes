// <copyright file="Program.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

namespace Envelopes
{
    /// <summary>
    /// The start point
    /// </summary>
    public class Program
    {
        /// <summary>
        /// MaThe start method
        /// </summary>
        /// <param name="args">The argument from command line</param>
        /// <returns>0 if success, 1 if error occurred</returns>
        public static int Main(string[] args)
        {
            NestingEnvelopeApplication myApplication = new NestingEnvelopeApplication();
            return myApplication.Run(args);
        }
    }
}