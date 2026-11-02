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

        // Step 1: Creating the array with the variable length as indicator for the size of the array
        double[] multiples = new double[length];
        // Step 2: Looping trough the array and assigning the multiples for the the number according to the lenght number

        for (int i = 0; i < length; i++)
        {
            // Step 3: Assigning the multiples with I, for the order that it should be in the array. Also making the multiplication starting from 1, so we add "+ 1", so we can start from the multiple from 1.
            multiples[i] = number * (i + 1);
        }

        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

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
        // Step 1: Creating a new list to store the rotated values
        List<int> rotatedList = new List<int>(data.Count);
        // step 2: setting the index where the list should start and getting the info for the remaining part of the list
        List<int> part =data.GetRange(data.Count - amount, amount);
        List<int> remainingPart = data.GetRange(0, data.Count - amount);

        // step 3: Adding the part to the rotated list and then adding the remaining part to the rotated list
        rotatedList.AddRange(part);
        rotatedList.AddRange(remainingPart);
        // step 4: Clearing the original list and adding the rotated values to it
        data.Clear();
        data.AddRange(rotatedList);
        
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}
