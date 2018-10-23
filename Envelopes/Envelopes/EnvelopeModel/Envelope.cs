// <copyright file="Envelope.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;

namespace Envelopes
{
    /// <summary>
    /// Class for envelopes
    /// </summary>
    public class Envelope
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope"/> class
        /// </summary>
        /// <param name="sideA">The first side of the envelope</param>
        /// <param name="sideB">The second side of the envelope</param>
        private Envelope(float sideA, float sideB)
        {
            this.SideA = sideA;
            this.SideB = sideB;
        }

        /// <summary>
        /// Gets the sideA f the envelope
        /// </summary>
        /// <value>
        /// The first side of the envelope
        /// </value>
        public float SideA
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the sideB f the envelope
        /// </summary>
        /// <value>
        /// The second side of the envelope
        /// </value>
        public float SideB
        {
            get;
            private set;
        }

        /// <summary>
        /// Initialize the envelope with specified sides
        /// </summary>
        /// <param name="sideA">The sideA</param>
        /// <param name="sideB">The sideB</param>
        /// <returns>New instance of Envelope</returns>
        /// <exception cref="EnvelopeException">Sides of envelope can not be less than zero!</exception>
        public static Envelope Initialize(float sideA, float sideB)
        {
            if (sideA <= 0 || sideB <= 0)
            {
                throw new EnvelopeException("Sides of envelope can not be less than zero!", new ArgumentException());
            }

            return new Envelope(sideA, sideB);
        }

        /// <summary>
        /// Determines whether this envelope is nesting to the specified another envelope
        /// </summary>
        /// <param name="anotherEnvelope">Another envelope</param>
        /// <returns>
        ///   <c>true</c> if this envelope is nesting; otherwise, <c>false</c>.
        /// </returns>
        public bool IsNesting(Envelope anotherEnvelope)
        {
            for (int alpha = 90; alpha >= 0; alpha--)
            {
                if ((this.SideA * Math.Cos(alpha * Math.PI / 180)) + (this.SideB * Math.Cos((90 - alpha) * Math.PI / 180)) < anotherEnvelope.SideA)
                {
                    if ((this.SideA * Math.Cos((90 - alpha) * Math.PI / 180)) + (this.SideB * Math.Sin((90 - alpha) * Math.PI / 180)) < anotherEnvelope.SideB)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}