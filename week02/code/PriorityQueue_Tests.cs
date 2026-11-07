using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a priority queue with items of varying priorities and dequeue them.
    // Expected Result: Items are dequeued in order of highest priority (highest number first).
    // Defect(s) Found: The loop condition stopped before the last element (index < Count - 1 instead of < Count), 
    // and the dequeued item was never removed from the underlying list.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 10);
        pq.Enqueue("Medium", 5);

        Assert.AreEqual("High", pq.Dequeue());  
        Assert.AreEqual("Medium", pq.Dequeue()); 
        Assert.AreEqual("Low", pq.Dequeue());   
    }

   [TestMethod]
    // Scenario: Create a priority queue with multiple items sharing the same highest priority.
    // Expected Result: The item closest to the front (added first) is removed first (FIFO).
    // Defect(s) Found: The comparison used >= instead of >, causing the later item with equal priority to be selected instead of the first one.
    public void TestPriorityQueue_FIFO_EqualPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("FirstHigh", 10);
        pq.Enqueue("SecondHigh", 10);
        pq.Enqueue("Low", 1);

        Assert.AreEqual("FirstHigh", pq.Dequeue()); 
        Assert.AreEqual("SecondHigh", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

[TestMethod]
    // Scenario: Try to dequeue from an empty priority queue.
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty"
    // Defect(s) Found: None (handled correctly by the exception check, assuming Dequeue throws properly).
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
