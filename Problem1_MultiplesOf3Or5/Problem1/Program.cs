namespace Problem1_MultiplesOf3Or5 {
    /* Problem:
     * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
     * Find the sum of all the multiple of 3 or 5 below 1000. */
    class Program {
        public static void Main(string[] args) {
            
            // Console.WriteLine(FindSumOfMultiples(10));
            Console.WriteLine(FindSumOfMultiples(1000));

        }

        static int FindSumOfMultiples(int upperLimit) {
            int sum = 0;
            for (int i = 0; i < upperLimit; i++) {
                if (i % 3 == 0 | i % 5 == 0) {
                    sum += i;
                }
            }
            return sum;
        }
    }
}

