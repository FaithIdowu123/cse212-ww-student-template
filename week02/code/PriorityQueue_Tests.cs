using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{

    [TestMethod]
    // Scenario: Check if the queue throws an exception when dequeueing from an empty queue
    // Expected Result: InvalidOperationException is thrown
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Enqueue a single item and dequeue it
    // Expected Result: The dequeued item matches the enqueued item
    // Defect(s) Found: Dequeue method was index variable was initialized as 1 instead of 0 and loop condition was incorrect
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("OnlyItem", 10);

        var dequeuedItem = priorityQueue.Dequeue();
        Assert.AreEqual("OnlyItem", dequeuedItem, "Dequeued item should match the enqueued item.");
    }

    // Add more test cases as needed below..
    [TestMethod]
    // Scenario: Enqueue multiple items and dequeue them in order of priority
    // Expected Result: Items are dequeued in correct priority order
    // Defect(s) Found: Dequeue method was index variable was initialized as 1 instead of 0 and loop condition was incorrect
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("HighPriority", 5);
        priorityQueue.Enqueue("MediumPriority", 3);

        var firstDequeued = priorityQueue.Dequeue();
        Assert.AreEqual("HighPriority", firstDequeued, "First dequeued item should be HighPriority.");

        var secondDequeued = priorityQueue.Dequeue();
        Assert.AreEqual("MediumPriority", secondDequeued, "Second dequeued item should be MediumPriority.");

        var thirdDequeued = priorityQueue.Dequeue();
        Assert.AreEqual("LowPriority", thirdDequeued, "Third dequeued item should be LowPriority.");
    }


    [TestMethod]
    // Scenario: Enqueue multiple items with same priority and dequeue them
    // Expected Result: Items are dequeued in correct priority order (based on insertion order for same priority)
    // Defect(s) Found: Dequeue method's if condition in the priority loop was incorrect
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Priority1", 3);
        priorityQueue.Enqueue("Priority2", 5);
        priorityQueue.Enqueue("Priority3", 5);

        var firstDequeued = priorityQueue.Dequeue();
        Assert.AreEqual("Priority2", firstDequeued, "First dequeued item should be Priority2.");

        var secondDequeued = priorityQueue.Dequeue();
        Assert.AreEqual("Priority3", secondDequeued, "Second dequeued item should be Priority3.");

        var thirdDequeued = priorityQueue.Dequeue();
        Assert.AreEqual("Priority1", thirdDequeued, "Third dequeued item should be Priority1.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items, dequeue them in order of priority and check if the queue is empty afterwards
    // Expected Result: Queue is empty after all items are dequeued
    // Defect(s) Found: Dequeue method did not remove the item from the queue after dequeuing
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Priority1", 7);
        priorityQueue.Enqueue("Priority2", 1);
        priorityQueue.Enqueue("Priority3", 3);

        var firstDequeued = priorityQueue.Dequeue();

        var secondDequeued = priorityQueue.Dequeue();

        var thirdDequeued = priorityQueue.Dequeue();

        var isEmpty = priorityQueue.ToString();
        Assert.AreEqual("[]", isEmpty, "Queue should be empty after dequeuing all items.");

    }   
}