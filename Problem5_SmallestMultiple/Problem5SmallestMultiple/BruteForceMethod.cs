namespace Problem5_SmallestMultiple_BruteForceMethod {
    /* Problem:
     * 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
     * What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20? */

    // This solution uses brute force to find the least common multiple.
    class BruteForceMethod {
        public static void Main(string[] args) {
            //Console.WriteLine(FindSmallestMultiple(10));
            Console.WriteLine("{0:n0}", FindSmallestMultiple(20));

        }

        static int FindSmallestMultiple(int upperLimit) {
            bool foundMultiple = false;
            int potentialMultiple = upperLimit + 1;
            while(foundMultiple == false) {
                if(IsDivisible(potentialMultiple, upperLimit)) {
                    foundMultiple = true;
                } else {
                    potentialMultiple++;
                }
            }
            return potentialMultiple;
        }

        static bool IsDivisible(int number, int upperLimit) {
            if (upperLimit <= 1) {
                return true;
            }
            if(number % upperLimit == 0) {
                if(IsDivisible(number, upperLimit - 1)) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }
    }
}