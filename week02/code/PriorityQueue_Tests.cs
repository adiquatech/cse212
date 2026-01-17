using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Original code might not throw correct exception or message
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue(),
            "The queue is empty.");
    }

    [TestMethod]
    // Scenario: Enqueue one item and dequeue it
    // Expected Result: Returns the enqueued value and queue becomes empty
    // Defect(s) Found: Original Dequeue did not remove the item from the list
    public void TestPriorityQueue_SingleItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Apple", 10);
        Assert.AreEqual("Apple", pq.Dequeue());
        Assert.AreEqual(0, pq.Count, "Queue should be empty after dequeue");
    }

    [TestMethod]
    // Scenario: Multiple items with different priorities
    // Expected Result: Highest priority dequeued first, regardless of enqueue order
    // Defect(s) Found: Original loop missed last item and used wrong comparison (>= instead of >)
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 5);
        pq.Enqueue("High", 10);
        pq.Enqueue("VeryLow", 0);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
        Assert.AreEqual("VeryLow", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items with same (highest) priority — should follow FIFO order
    // Expected Result: Returns items in the order they were enqueued (earliest first)
    // Defect(s) Found: Original code picked the last item on tie instead of first
    public void TestPriorityQueue_TiePriority_FIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Task A", 8);
        pq.Enqueue("Task B", 8);
        pq.Enqueue("Task C", 8);
        pq.Enqueue("Task D", 5);

        Assert.AreEqual("Task A", pq.Dequeue());  // First enqueued with pri 8
        Assert.AreEqual("Task B", pq.Dequeue());
        Assert.AreEqual("Task C", pq.Dequeue());
        Assert.AreEqual("Task D", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue after some dequeues, mixed priorities
    // Expected Result: Correct highest priority dequeued even after queue changes
    // Defect(s) Found: Original did not handle removal properly, queue grew incorrectly
    public void TestPriorityQueue_EnqueueAfterDequeue()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 7);
        pq.Enqueue("C", 2);

        Assert.AreEqual("B", pq.Dequeue());  // Highest = 7

        pq.Enqueue("D", 9);  // New highest
        pq.Enqueue("E", 7);  // Tie with previous high

        Assert.AreEqual("D", pq.Dequeue());  // 9 is highest
        Assert.AreEqual("E", pq.Dequeue());  // Next highest (7), later enqueued but still after
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }
}