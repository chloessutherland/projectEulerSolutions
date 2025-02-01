using System.Net.Http.Headers;

namespace Problem4_LargestPalindromeProduct {
    /* Problem:
     * A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 x 99.
     * Find the largest palindrome made from the product of two 3-digit numbers. */
    class Program {
        public static void Main(string[] args) {
            // Console.WriteLine(FindLargestPalindrome(99, 10));
            Console.WriteLine(FindLargestPalindrome(999, 100));
        }

        static bool IsPalindrome(int number) {
            string numberAsString = number.ToString();
            char[] numberAsCharArray = numberAsString.ToCharArray();
            Array.Reverse(numberAsCharArray);
            string reversedString = new string(numberAsCharArray);
            if(reversedString.Equals(numberAsString)) {
                return true;
            } else { 
                return false; 
            }
        }

        static int FindLargestPalindrome(int upperBound, int lowerBound) {
            int largestPalindrome = 0;
            for(int firstNumber = upperBound; firstNumber >= lowerBound; firstNumber--) {
                for(int secondNumber = upperBound; secondNumber >= lowerBound; secondNumber--) {
                    int product = firstNumber * secondNumber;
                    if(IsPalindrome(product)) {
                        if(product > largestPalindrome) {
                            largestPalindrome = product;
                        }
                    }
                }
            }
            return largestPalindrome;
        }

    }
}