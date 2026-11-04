import java.util.NoSuchElementException;

public class TestQueue<T> implements IQueueADT<T> {

    private int currentCapacity;
    private Object[] storage;
    private int front;
    private int rear;

    public TestQueue(int capacity) {
        currentCapacity = 0;
        storage = new Object[capacity];
        front = 0;
        rear = 0;
    }

    @Override
    public void Enqueue(T data) {

        if (IsFull()) {
            throw new ArrayIndexOutOfBoundsException("Queue overflow");
        }

        storage[rear++] = data;
        currentCapacity++;
    }

    @Override
    public T Dequeue() {

        if (IsEmpty()) {
            throw new NoSuchElementException("Queue is empty");
        }

        T item = (T) storage[front];

        ShiftLeft();

        currentCapacity--;

        return item;
    }

    @Override
    public boolean IsEmpty() {
        return currentCapacity == 0;
    }

    @Override
    public boolean IsFull() {
        return currentCapacity == storage.length;
    }

    private void ShiftLeft() {

        for (int i = 0; i < rear - 1; i++) {
            storage[i] = storage[i + 1];
        }

        storage[rear - 1] = null;
        rear--;
    }

    public T GetFront() {

        if (IsEmpty()) {
            throw new NoSuchElementException("Queue is empty");
        }

        return (T) storage[front];
    }

    public T GetRear() {

        if (IsEmpty()) {
            throw new NoSuchElementException("Queue is empty");
        }

        return (T) storage[rear - 1];
    }

    public void Display() {

        if (IsEmpty()) {
            System.out.println("Queue is empty.");
            return;
        }

        System.out.print("Queue: FRONT -> ");

        for (int i = 0; i < rear; i++) {
            System.out.print(storage[i]);

            if (i < rear - 1) {
                System.out.print(" -> ");
            }
        }

        System.out.println(" <- REAR");
    }

}
