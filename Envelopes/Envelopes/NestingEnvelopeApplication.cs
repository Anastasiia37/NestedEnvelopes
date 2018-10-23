// <copyright file="NestingEnvelopeApplication.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;

namespace Envelopes
{
    /// <summary>
    /// The class which works with envelopes
    /// </summary>
    public class NestingEnvelopeApplication
    {
        /// <summary>
        /// The no arguments count in command line
        /// </summary>
        private const int NO_ARGUMENTS_COUNT = 0;

        /// <summary>
        /// The expected count of envelopes sides
        /// </summary>
        private const int COUNT_OF_ENVELOPES_SIDES = 4;

        /// <summary>
        /// About the program
        /// </summary>
        private readonly string about = Envelopes.Properties.Resources.ReadMe;

        /// <summary>
        /// The sides of two envelopes
        /// </summary>
        private float[] sides;

        /// <summary>
        /// The first envelope
        /// </summary>
        private Envelope envelope1;

        /// <summary>
        /// The second envelope
        /// </summary>
        private Envelope envelope2;

        /// <summary>
        /// Initializes a new instance of the <see cref="NestingEnvelopeApplication"/> class
        /// </summary>
        public NestingEnvelopeApplication()
        {
            this.sides = new float[COUNT_OF_ENVELOPES_SIDES];
        }

        /// <summary>
        /// Runs the application
        /// </summary>
        /// <param name="args">The arguments from command line</param>
        /// <returns>Return code</returns>
        public int Run(string[] args)
        {
            try
            {
                if (args.Length == NO_ARGUMENTS_COUNT)
                {
                    Console.WriteLine(this.about);
                    Console.ReadKey();
                }
                else
                {
                    this.sides = EnvelopeParser.Parse(args);
                    this.TryToNestEnvelope();
                    string action;
                    do
                    {
                        Console.Write("Do you want to try another two envelopes? (If you do, print \"y\" or \"yes\"): ");
                        action = Console.ReadLine().ToLower();
                        if (action == "y" || action == "yes")
                        {
                            this.GetNewParameters();
                            this.TryToNestEnvelope();
                        }
                    }
                    while (action == "y" && action == "yes");
                    Console.WriteLine(Environment.NewLine + "Thank you for using this application!");
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                this.ShowInstructions();
                return (int)ReturnCode.Error;
            }
            catch (EnvelopeException exception)
            {
                Console.WriteLine(exception.Message);
                this.ShowInstructions();
                return (int)ReturnCode.Error;
            }

            return (int)ReturnCode.Success;
        }

        /// <summary>
        /// Determines whether one envelope can be put in another
        /// </summary>
        private void TryToNestEnvelope()
        {
            try
            {
                this.envelope1 = Envelope.Initialize(this.sides[0], this.sides[1]);
                this.envelope2 = Envelope.Initialize(this.sides[2], this.sides[3]);
                if (this.envelope1.IsNesting(this.envelope2))
                {
                    Console.WriteLine("The first envelope is nesting to the second envelope." + Environment.NewLine);
                }
                else
                {
                    if (this.envelope2.IsNesting(this.envelope1))
                    {
                        Console.WriteLine("The second envelope is nesting to the first envelope." + Environment.NewLine);
                    }
                    else
                    {
                        Console.WriteLine("Can`t put one envelope to another." + Environment.NewLine);
                    }
                }
            }
            catch (EnvelopeException exception)
            {
                Console.WriteLine(exception.Message);
                this.ShowInstructions();
            }
        }

        /// <summary>
        /// Gets the new parameters of two new envelopes from command line
        /// </summary>
        private void GetNewParameters()
        {
            try
            {
                this.ShowInstructions();
                Console.Write("Please, input the sides of envelopes: ");
                this.sides = EnvelopeParser.Parse(Console.ReadLine());
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Shows the instructions how to use the program
        /// </summary>
        private void ShowInstructions()
        {
            Console.WriteLine("Input: sideA1 sideB1 sideA2 sideB2" + Environment.NewLine
                            + "where: sideA1 and sideB1 are sides of the first envelope,"
                            + Environment.NewLine 
                            + "       sideA2 and sideB2 are sides of the second envelope.");
        }
    }
}