using Inventory_System.IRepository;
using Inventory_System.Repository;

namespace Inventory_System.Validator
{
    public class InputValidator
    {
        public string ValidateStringInput(string msg, int minLength)
        {
            string input;
            do
            {
                Console.Write(msg);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || input.Length < minLength)
                {
                    Console.WriteLine($"name must be at least {minLength} characters long.");
                }
            } while (string.IsNullOrWhiteSpace(input) || input.Length < minLength);

            return input;
        }

        public double ValidatedoubleInput(string msg, double minValue )
        {
            double value;
            do
            {
                Console.Write(msg);
                if (!double.TryParse(Console.ReadLine(), out value) || value <= minValue)
                {
                    Console.WriteLine($"Please enter a valid number greater than {minValue}.");
                }
            } while (value <= minValue);

            return value;
        }

        public int ValidateIntInput(string msg, int minValue)
        {
            int value;
            do
            {
                Console.Write(msg);
                if (!int.TryParse(Console.ReadLine(), out value) || value <= minValue)
                {
                    Console.WriteLine($"Please Enter a Valid Number!");
                }
            } while (value <= minValue);

            return value;
        }
    }
}
