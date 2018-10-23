// <copyright file="EnvelopeException.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;

namespace Envelopes
{
    /// <summary>
    /// Class for exceptions of Envelope class
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class EnvelopeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnvelopeException"/> class.
        /// </summary>
        public EnvelopeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvelopeException"/> class
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public EnvelopeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvelopeException"/> class
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="inner">The inner exception</param>
        public EnvelopeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
