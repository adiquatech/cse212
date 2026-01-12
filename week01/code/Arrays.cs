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
        
        // Step 1: Create a new array of doubles with the specified length.
        // Step 2: Loop from 0 to length-1, calculating each multiple as number * (i + 1).
        // Step 3: Assign each calculated value to the corresponding index in the array.
        // Step 4: Return the completed array.
        
        double[] multiples = new double[length];
        
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        
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
        
        // Step 1: Handle edge cases - if list is empty or amount is 0 or multiple of list size, no change needed.
        // Step 2: Calculate the effective rotation amount using modulo to wrap around if amount > data.Count (though per spec, amount <= count).
        // Step 3: Use list slicing to get the last 'amount' elements (which move to front).
        // Step 4: Get the first (data.Count - amount) elements (which move to end).
        // Step 5: Clear the original list.
        // Step 6: Add the sliced last part first, then the first part to achieve rotation.
        
        if (data.Count == 0 || amount == 0) return;
        
        amount %= data.Count;  // Effective amount (safe even if amount > count)
        
        List<int> tail = data.GetRange(data.Count - amount, amount);  // Last 'amount' elements
        List<int> head = data.GetRange(0, data.Count - amount);       // First part
        
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}