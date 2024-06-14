using System;
using System.Collections.Generic;
namespace Assignment6._3
{ 


public class Caller
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public Caller(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}

public class CallQueue
{
    private LinkedList<Caller> queue;

    public CallQueue()
    {
        queue = new LinkedList<Caller>();
    }

    public void EnqueueCaller(Caller caller)
    {
        queue.AddLast(caller);
    }

    public Caller DequeueCaller()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }
        var caller = queue.First.Value;
        queue.RemoveFirst();
        return caller;
    }

    public void DisplayCallers()
    {
        foreach (var caller in queue)
        {
            Console.WriteLine($"Caller Name: {caller.Name}, Phone Number: {caller.PhoneNumber}");
        }
    }
}

    class Program
    {
        static void Main()
        {
            CallQueue callQueue = new CallQueue();

            // Enqueue some callers
            callQueue.EnqueueCaller(new Caller("John Smith", "555-1234"));
            callQueue.EnqueueCaller(new Caller("Jane Gonzalez", "555-5678"));
            callQueue.EnqueueCaller(new Caller("Jim Anderson", "555-9012"));

            // Display all callers
            Console.WriteLine("Current Call Queue:");
            callQueue.DisplayCallers();

            // Dequeue a caller
            Caller nextCaller = callQueue.DequeueCaller();
            Console.WriteLine($"\nDequeued Caller: {nextCaller.Name}, Phone Number: {nextCaller.PhoneNumber}");

            // Display remaining callers
            Console.WriteLine("\nRemaining Call Queue:");
            callQueue.DisplayCallers();
        }
    }
}
