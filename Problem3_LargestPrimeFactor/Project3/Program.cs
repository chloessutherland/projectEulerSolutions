namespace Problem3_LargestPrimeFactor {
    /* Problem:
     * The prime factors of 13195 are 5, 7, 13 and 29.
     * What is the largest prime factor of the number 600851475143? */
    class Program {
        public static void Main(string[] args) {
            /*List<int> primeFactorsList = findPrimeFactors(13195);
            foreach(int factor in primeFactorsList) {
                Console.WriteLine(factor);
            }*/

            List<long> primeFactorsList = findPrimeFactors(600_851_475_143);
            Console.WriteLine(primeFactorsList.Max());

        }

        // uses the simplest method to find factors: dividing up to the square root
        static List<long> findFactors(long number) {
            double squareRoot = Math.Sqrt(number);
            List<long> factors = new List<long>();
            for(long potentialFactor = (long)squareRoot; potentialFactor > 1; potentialFactor--) {
                if(number % potentialFactor == 0) {         // check if the potentialFactor IS a factor
                    factors.Add(potentialFactor);
                    factors.Add(number / potentialFactor); // add the other part of the factor pair
                }
            }
            return factors;
        }

        static bool isPrime(long number) {
            double squareRoot = Math.Sqrt(number);
            for(long divisor = (long)squareRoot; divisor > 1; divisor--) {
                if(number % divisor == 0) {         // if the number can be divided by another number, it isn't prime
                    return false;
                }
            }
            return true;
        }

        static List<long> findPrimeFactors(long number) {
            List<long> allFactors = findFactors(number);
            List<long> primeFactors = new List<long>();
            foreach(long factor in allFactors) {
                if(isPrime(factor)) {
                    primeFactors.Add(factor);
                }
            }
            return primeFactors;
        }
        
    }
}