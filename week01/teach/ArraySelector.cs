public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }


    private static int[] ListSelector(int[] list1, int[] list2, int[] select) {
    List<int> result = new List<int>();
    
    int idx1 = 0;  // pointer for list1
    int idx2 = 0;  // pointer for list2
    
    foreach (int choice in select) {
        if (choice == 1) {
            // Take next from list1
            result.Add(list1[idx1]);
            idx1++;               // move pointer forward
        }
        else if (choice == 2) {
            // Take next from list2
            result.Add(list2[idx2]);
            idx2++;               // move pointer forward
        }
        // Note: assumes input is valid (no out-of-range, only 1 or 2)
    }
    
    return result.ToArray();  // convert List back to int[]
}
}