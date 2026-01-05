public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //solution:First, create a fixed array of doubles with the specified length.
        //Next, use a loop to iterate from 0 to length - 1.
        //In each loop, calculate the multiple by multiplying the i(index) by the number variable and then add the result to the number variable.
        //Lastly with each iteration, assign the result to the fixed array using the current index.

        //create a fixed array of doubles with the specified length
        double[] multiples = new double[length];

        //use a loop to iterate from 0 to length - 1
        for (int i = 0; i < length; i++)
        {
            //calculate the multiple and assign the result to the fixed array using the current index
            multiples[i] = number + (number * i);
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //solution: First, create a loop that runs for the number of times specified by the amount variable.
        //Next, within this loop, store the last element of the list in a temporary variable
        //Then, create another loop that shifts all elements of the list to the right by one position.
        //Finally, place the last element (stored in the temporary variable) at the first position of the list.
        //Repeat this process until the outer loop completes.

        for (int i = 0; i < amount; i++)
        {
            //store the last element in a temporary variable
            int lastElement = data[data.Count - 1];

            //shift all elements to the right by one position
            for (int j = data.Count - 1; j > 0; j--)
            {
                data[j] = data[j - 1];
            }

            //place the last element at the first position
            data[0] = lastElement;
        }
    }
}
