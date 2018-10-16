using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelopes
{
    public class NestingEnvelopeApplication
    {
        private readonly string about = "There are two envelopes with sides (a1, b1) and (a2, b2). "
            + "The goal is to determine whether one envelope can be inserted into the other. "
            + "The program handle the input of floating-point numbers. "
            + "After each calculation, the program asks the user if he wants to continue. "
            + "If the user answers “y” or “yes” (case insensitive), the program continues working from the beginning, "
            + "otherwise it ends the execution.";

        private float[] sides;
        private Envelope envelope1;
        private Envelope envelope2;

        public NestingEnvelopeApplication()
        {
            this.sides = new float[4];
        }

        public int Run(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(this.about);
                this.ShowInstructions();
                Console.ReadKey();
                return (int)ReturnCode.Error;
            }

            try
            {
                this.sides = Validator.Validate(args);
                this.TryToNestEnvelope();
                while (true)
                {                   
                        Console.Write("Do you want to try another two envelopes? (If you do, print \"y\" or \"yes\"): ");
                        string action = Console.ReadLine().ToLower();
                        if (action != "y" && action != "yes")
                        {
                            break;
                        }

                        this.GetNewParameters();
                        this.TryToNestEnvelope();             
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

            Console.WriteLine("\nThank you for using this application!");
            return (int)ReturnCode.Success;
        }

        private void TryToNestEnvelope()
        {
            try
            {
                this.envelope1 = Envelope.Initialize(this.sides[0], this.sides[1]);
                this.envelope2 = Envelope.Initialize(this.sides[2], this.sides[3]);
                if (this.envelope1.IsNesting(this.envelope2))
                {
                    Console.WriteLine("The first envelope is nesting to the second envelope.\n");
                }
                else
                {
                    if (this.envelope2.IsNesting(this.envelope1))
                    {
                        Console.WriteLine("The second envelope is nesting to the first envelope.\n");
                    }
                    else
                    {
                        Console.WriteLine("Can`t put one envelope to another.\n");
                    }
                }
            }
            catch (EnvelopeException exception)
            {
                Console.WriteLine(exception.Message);
                this.ShowInstructions();
            }
        }

        private void GetNewParameters()
        {
            try
            {
                this.ShowInstructions();
                Console.Write("Please, input the sides of envelopes: ");
                this.sides = Validator.Validate(Console.ReadLine());
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void ShowInstructions()
        {
            Console.WriteLine("Input: sideA1 sideB1 sideA2 sideB2\n"
                            + "where: sideA1 and sideB1 are sides of the first envelope,\n"
                            + "       sideA2 and sideB2 are sides of the second envelope.");
        }
    }
}