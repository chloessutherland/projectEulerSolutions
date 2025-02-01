using System.Linq;

namespace Problem5_SmallestMultiple_PrimeFactorizationMethod {
    /* Problem:
     * 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
     * What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20? */
    
    // This solution uses prime factorization by multiplying together the prime factors of each number to the power of their highest power (multiplicity).
    // For more information: https://study.com/skill/learn/how-to-find-the-least-common-multiple-of-3-numbers-explanation.html
    class PrimeFactorizationMethod {
        public static void Main(string[] args) {
            //Console.WriteLine(FindLeastCommonMultiple(10));
            Console.WriteLine("{0:n0}", FindLeastCommonMultiple(20));
        }

        static int findAFactor(int number) {            // uses the simplest method to find factors: dividing up to the square root
            double squareRoot = Math.Sqrt(number);
            for (int potentialFactor = (int)squareRoot; potentialFactor > 1; potentialFactor--) {
                if (number % potentialFactor == 0) {         // check if the potentialFactor IS a factor
                    return potentialFactor;
                }
            }
            return 1;
        }

        static List<int> findPrimeFactors(int number) {
            int firstHalf = findAFactor(number);
            int secondHalf = number / firstHalf;
            List<int> primeFactors = new List<int>();
            if (IsPrime(firstHalf)) {
                primeFactors.Add(firstHalf);
            } else {
                primeFactors.AddRange(findPrimeFactors(firstHalf));     // keep generating factors until they're prime
            }
            if (IsPrime(secondHalf)) {
                primeFactors.Add(secondHalf);
            } else {
                primeFactors.AddRange(findPrimeFactors(secondHalf));    // keep generating factors until they're prime
            }
            return primeFactors;
        }

        static bool IsPrime(long number) {
            double squareRoot = Math.Sqrt(number);
            for (long divisor = (long)squareRoot; divisor > 1; divisor--) {
                if (number % divisor == 0) {         // if the number can be divided by another number, it isn't prime
                    return false;
                }
            }
            return true;
        }

        static Dictionary<int, int> FindPrimeFactorsWithLargestMultiplicity(int upperLimit) {
            Dictionary<int, int> primeFactorsWithLargestMultiplicity = new Dictionary<int, int>(); // key = prime factor, value = multiplicity
            for (int number = 1; number <= upperLimit; number++) {
                List<int> primeFactors = findPrimeFactors(number);
                foreach (int primeFactor in primeFactors) {
                    int multiplicity = FindMultiplicity(primeFactors, primeFactor);
                    if (primeFactorsWithLargestMultiplicity.ContainsKey(primeFactor) == false) {    // if we don't already have the prime factor, add it
                        primeFactorsWithLargestMultiplicity.Add(primeFactor, multiplicity);
                    } else {
                        if (FindMultiplicity(primeFactors, primeFactor) > primeFactorsWithLargestMultiplicity[primeFactor]) { // if the multiplicity found is larger than currently in the dictionary
                            primeFactorsWithLargestMultiplicity[primeFactor] = multiplicity;
                        }
                    }
                }
            }
            return primeFactorsWithLargestMultiplicity;
        }

        static int FindMultiplicity(List<int> primeFactors, int primeFactor) {
            return primeFactors.Where(primeF => primeF == primeFactor).Count();     // look for elements that equal the primeFactor and return the count
        }

        static int FindLeastCommonMultiple(int upperLimit) {
            Dictionary<int, int> primeFactorsWithMultiplicity = FindPrimeFactorsWithLargestMultiplicity(upperLimit);
            double leastCommonMultiple = 1;
            foreach (int primeFactor in primeFactorsWithMultiplicity.Keys) {
                leastCommonMultiple *= Math.Pow(Convert.ToDouble(primeFactor), Convert.ToDouble(primeFactorsWithMultiplicity[primeFactor]));
            }
            return Convert.ToInt32(leastCommonMultiple);
        }
    }
}