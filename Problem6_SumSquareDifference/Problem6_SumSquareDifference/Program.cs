namespace Problem6_SumSquareDifference {
    /* The sum of the squares of the first ten natural numbers is,
     * 1^2 + 2^2 + ... + 10^2 = 385
     * The square of the sum of the first ten natural numbers is,
     * (1 + 2 + ... + 10)^2 = 55^2 = 3025.
     * Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is
     * 3025 - 385 = 2640.
     * Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum. */
    class Program {
        public static void Main(string[] args) {
            //Console.WriteLine(CalculateSumOfSquares(10));
            //Console.WriteLine(CalculateSquareOfSum(10));
            //Console.WriteLine(CalculateDifferenceOfSums(10));
            Console.WriteLine("{0:n0}", CalculateDifferenceOfSums(100));
        }

        static int CalculateSumOfSquares(int upperLimit) {
            double sumOfSquares = 0;
            for(int number = 1; number <= upperLimit; number++) {
                sumOfSquares += Math.Pow(Convert.ToDouble(number), 2.0);
            }
            return Convert.ToInt32(sumOfSquares);
        }

        static int CalculateSquareOfSum(int upperLimit) {
            double sum = 0;
            for (int number = 1; number <= upperLimit; number++) {
                sum += number;
            }
            return Convert.ToInt32(Math.Pow(Convert.ToDouble(sum), 2.0));
        }

        static int CalculateDifferenceOfSums(int upperLimit) {
            return CalculateSquareOfSum(upperLimit) - CalculateSumOfSquares(upperLimit);
        }

    }
}