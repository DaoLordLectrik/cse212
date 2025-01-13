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


        //Create an array that will hold the multiples. Data type double and size set as lenght to match the length of the multiples
        double[] multiples=new double[length];

        // Use a loop to fill data in each element of the array.

        for (int i = 0; i < length; i++)
        {
            // Calculate the multiple of the data number and assign it to the current position in the array
            multiples[i] = (i + 1) * number;
        }

        // Return the entered list of multiples
        return multiples;
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


        //If the amount is 0 or equal to data Count, no rotation is to be done
        if (amount == 0 || amount == data.Count) return;

        //Calculate the rotation amount by using modulo.
        amount = amount % data.Count;

        //Seperate the list to two parts and rotate the.
        List<int> lastSplit = data.GetRange(data.Count - amount, amount);
        List<int> firstSplit = data.GetRange(0, data.Count - amount);

        //Clear the original list, add lastPart to the front and firstPart will follow
        data.Clear();
        data.AddRange(lastSplit);
        data.AddRange(firstSplit);
    }
}