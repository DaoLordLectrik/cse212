using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with some values and its priorities
    // Expected Result: In order return the values, try to dequeue one more time and get an error
    // Defect(s) Found: The equal to sign needed to be removed from the evaulation so it would return
    // The first priority value that was inputted. Removed the -1 in the for loop to show correct
    public void TestPriorityQueue_1()
    {

        var priorityQueue1 = new PriorityQueue();

        priorityQueue1.Enqueue("Dog", 2);
        priorityQueue1.Enqueue("Hen", 4);
        priorityQueue1.Enqueue("Horse", 3);
        priorityQueue1.Enqueue("Snake", 1);
        var result1 = priorityQueue1.Dequeue();
        Trace.Assert(result1 == "Hen");
        var result2 = priorityQueue1.Dequeue();
        Trace.Assert(result2 == "Horse");
        var result3 = priorityQueue1.Dequeue();
        Trace.Assert(result3 == "Dog");
        var result4 = priorityQueue1.Dequeue();
        Trace.Assert(result4 == "Snake");
        var result5 = priorityQueue1.Dequeue();
    }

    [TestMethod]
    // Scenario: Create a queue with the following inputs: Dog (3), Snake (5), Horse (4), Donkey (2), Eel (1) 
    // Expected Result: Return in order the following items: Snake, Horse, Dog, Donkey, Eel
    // Defect(s) Found: No defect found. All defects were solved in the first test above.
    public void TestPriorityQueue_2()
    {
        var priorityQueue2 = new PriorityQueue();
        priorityQueue2.Enqueue("Dog", 3);
        priorityQueue2.Enqueue("Snake", 5);
        priorityQueue2.Enqueue("Horse", 4);
        priorityQueue2.Enqueue("Donkey", 2);
        priorityQueue2.Enqueue("Eel", 1);
        var result1 = priorityQueue2.Dequeue();
        Trace.Assert(result1 == "Snake");
        var result2 = priorityQueue2.Dequeue();
        Trace.Assert(result2 == "Horse");
        var result3 = priorityQueue2.Dequeue();
        Trace.Assert(result3 == "Dog");
        var result4 = priorityQueue2.Dequeue();
        Trace.Assert(result4 == "Donkey");
        var result5 = priorityQueue2.Dequeue();
        Trace.Assert(result5 == "Eel");
    }



}