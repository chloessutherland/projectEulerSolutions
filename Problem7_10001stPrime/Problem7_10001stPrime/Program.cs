namespace Problem7_10001stPrime {
    /* By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
     * What is the 10 001st prime number? */
    class Program {
        public static void Main(string[] args) {
            //Console.WriteLine(FindPrimeNumbers(6));
            Console.WriteLine("{0:n0}", FindPrimeNumbers(10_001));
        }
        
        static int FindPrimeNumbers(int limit) {
            int primeCount = 0;
            int currentNumber = 1;
            while(primeCount < limit) {
                currentNumber++;
                if (IsPrime(currentNumber)) {
                    primeCount++;
                }
            }
            return currentNumber;

            static bool IsPrime(long number) {
                double squareRoot = Math.Sqrt(number);
                for (long divisor = (long)squareRoot; divisor > 1; divisor--) {
                    if (number % divisor == 0) {         // if the number can be divided by another number, it isn't prime
                        return false;
                    }
                }
                return true;
            }
        }
    }
}