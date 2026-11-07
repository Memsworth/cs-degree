public class TestCircularQueue<T> implements IQueueADT<T> {

    private Object[] storage;
    private int currentCount;
    private int front;
    private int rear;
    private int capacity;

    public TestCircularQueue(int capacity) {

        if (capacity <= 0) {
            throw new IllegalArgumentException("Capacity must be positive");
        }

        storage = new Object[capacity];
        front = rear = -1;
        currentCount = 0;
        this.capacity = capacity;
    }

    @Override
    public void Enqueue(T data) {

        if (IsFull()) {
            throw new IllegalStateException("Queue is full");
        }

        if (IsEmpty()) {
            front = 0;
            rear = 0;
        } else {
            rear = (rear + 1) % capacity;
        }
        storage[rear] = data;
        currentCount++;
    }

    @Override
    public T Dequeue() {
        if (IsEmpty()) {
            throw new IllegalStateException("Queue is empty");
        }
        var item = storage[front];
        storage[front] = null;
        front = (front + 1) % capacity;
        currentCount--;

        if (currentCount == 0) {
            front = rear = -1;
        } else {
            front = (front + 1) % capacity;
        }
        return (T) item;
    }

    @Override
    public boolean IsEmpty() {
        return currentCount == 0;
    }

    @Override
    public boolean IsFull() {
        return currentCount == storage.length;
    }

    public void Display() {

        if (IsEmpty()) {
            System.out.println("Queue is empty.");
            return;
        }

        System.out.print("Queue: FRONT -> ");

        for (int i = 0; i < currentCount; i++) {

            int index = (front + i) % capacity;

            System.out.print(storage[index]);

            if (i < currentCount - 1) {
                System.out.print(" -> ");
            }
        }

        System.out.println(" <- REAR");
    }

}
