namespace Problem5_SmallestMultiple_GreatestCommonFactorMethod {
    /* Problem:
     * 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
     * What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20? */

    // This solution uses the formula LCM(a,b) = (a×b)/GCF(a,b), where GCF is the greatest common factor.
    class GreatestCommonFactorMethod {
        public static void Main(string[] args) {
            //Console.WriteLine(FindLeastCommonMultipleOfMany(10));
            Console.WriteLine("{0:n0}", FindLeastCommonMultipleOfMany(20));
        }

        static long FindGreatestCommonFactor(long number1, long number2) {
            List<long> number1Factors = FindFactors(number1);
            List<long> number2Factors = FindFactors(number2);
            IEnumerable<long> sharedFactors = number1Factors.Intersect(number2Factors);
            if(sharedFactors.Count() == 0) {
                return 1;
            }
            return sharedFactors.Max();
        }

        // uses the simplest method to find factors: dividing up to the square root
        static List<long> FindFactors(long number) {
            double squareRoot = Math.Sqrt(number);
            List<long> factors = new List<long>();
            for (long potentialFactor = (long)squareRoot; potentialFactor >= 1; potentialFactor--) {
                if (number % potentialFactor == 0) {         // check if the potentialFactor IS a factor
                    factors.Add(potentialFactor);
                    factors.Add(number / potentialFactor); // add the other part of the factor pair
                }
            }
            return factors;
        }

        static long FindLeastCommonMultipleOfMany(long upperLimit) {
            long currentLCM = 1;
            for(long number = 1; number <= upperLimit; number++) {
                currentLCM = FindLeastCommonMultipleOfTwo(currentLCM, number);
            }
            return currentLCM;
        }

        static long FindLeastCommonMultipleOfTwo(long number1, long number2) {
            //Console.WriteLine($"Number 1: {number1}, number 2: {number2}, GCF: {FindGreatestCommonFactor(number1, number2)}, divided: {number1 * number2 / FindGreatestCommonFactor(number1, number2)}");
            return (number1 * number2) / FindGreatestCommonFactor(number1, number2);
        }
    }
}