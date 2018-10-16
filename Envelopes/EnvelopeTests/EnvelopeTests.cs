using Envelopes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EnvelopeTests
{
    [TestClass]
    public class EnvelopeTests
    {
        [DataTestMethod]
        [DataRow(1, 1, 2, 3)]
        [DataRow(1, 1, 3, 2)]
        [DataRow(2, 3, 2.1f, 3.1f)]
        [DataRow(2, 3, 3.1f, 2.1f)]
        [DataRow(15.5f, 2.8f, 12, 14)]
        [DataRow(15.5f, 2.8f, 14, 12)]
        public void Envelope_IsNestingTest_ReturnedTrue(float sideA1, float sideB1, float sideA2, float sideB2)
        {
            // Arrange
            Envelope envelope1 = Envelope.Initialize(sideA1, sideB1);
            Envelope envelope2 = Envelope.Initialize(sideA2, sideB2);
            bool expected = true;
            
            // Act
            bool actual = envelope1.IsNesting(envelope2);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(2, 3, 1, 1)]
        [DataRow(2, 3, 2, 3)]
        [DataRow(2, 3, 3, 2)]
        [DataRow(4, 4, 4, 4)]
        [DataRow(4, 4, 4, 4.1f)]
        [DataRow(2, 3, 1.9f, 3.1f)]
        [DataRow(2, 3, 3.1f, 1.9f)]
        public void Envelope_IsNestingTest_ReturnedFalse(float sideA1, float sideB1, float sideA2, float sideB2)
        {
            // Arrange
            Envelope envelope1 = Envelope.Initialize(sideA1, sideB1);
            Envelope envelope2 = Envelope.Initialize(sideA2, sideB2);
            bool expected = false;

            // Act
            bool actual = envelope1.IsNesting(envelope2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(2, -3)]
        [DataRow(-5, -4)]
        [DataRow(-5, 4)]
        [ExpectedException(typeof(EnvelopeException), "Exception \"EnvelopeException\" haven`t been thrown")]
        public void Envelope_InitializeTest_ReturnedEnvelopeException(float sideA, float sideB)
        {
            // Arrange
            Envelope envelope1 = Envelope.Initialize(sideA, sideB);
        }
    }
}
