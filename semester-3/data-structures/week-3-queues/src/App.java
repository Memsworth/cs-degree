public class App {
    public static void main(String[] args) throws Exception {
        var queue = new TestQueue<Integer>(5);

        // Check if queue is initially empty
        System.out.println("Is Empty: " + queue.IsEmpty());

        // Enqueue elements
        System.out.println("\n--- Enqueue Operations ---");
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        queue.Display();
        System.out.println("Front: " + queue.GetFront());
        System.out.println("Rear: " + queue.GetRear());

        // Dequeue an element
        System.out.println("\n--- Dequeue Operation ---");
        System.out.println("Dequeued: " + queue.Dequeue());

        queue.Display();
        System.out.println("Front: " + queue.GetFront());
        System.out.println("Rear: " + queue.GetRear());

        // Enqueue more elements
        System.out.println("\n--- More Enqueue Operations ---");
        queue.Enqueue(40);
        queue.Enqueue(50);
        queue.Enqueue(60);

        System.out.println("Front: " + queue.GetFront());
        System.out.println("Rear: " + queue.GetRear());
        queue.Display();

        // Check if queue is full
        System.out.println("\nIs Full: " + queue.IsFull());

        // Dequeue all elements
        System.out.println("\n--- Dequeue All Elements ---");

        while (!queue.IsEmpty()) {
            System.out.println("Dequeued: " + queue.Dequeue());
        }
        queue.Display();

        // Check if queue is empty again
        System.out.println("\nIs Empty: " + queue.IsEmpty());
    }
}
