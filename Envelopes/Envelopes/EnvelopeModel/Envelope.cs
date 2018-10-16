using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelopes
{
    public class Envelope
    {
        private Envelope(float sideA, float sideB)
        {
            this.SideA = sideA;
            this.SideB = sideB;
        }

        public float SideA
        {
            get;
            private set;
        }

        public float SideB
        {
            get;
            private set;
        }

        public static Envelope Initialize(float sideA, float sideB)
        {
            if (sideA <= 0 || sideB <= 0)
            {
                throw new EnvelopeException("Sides of envelope can not be less than zero!");
            }

            return new Envelope(sideA, sideB);
        }

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
