public class MyTestStack<T> implements IStack<T> {
    private Object[] storage;
    private int size;
    private int currentCount;

    public MyTestStack(int capacity)
    {
        size = capacity;
        currentCount = 0;
        storage = new Object[capacity];
    }
    @Override
    public void Push(T data) {
        if(currentCount == storage.length){
            throw new ArrayIndexOutOfBoundsException("Stack overflow");
        }
        storage[currentCount++] = data;
    }

    @Override
    public T Pop() {
        if(currentCount == 0){
            throw new IllegalStateException("Stack is empty");
        }
        T data = (T)storage[--currentCount];
        storage[currentCount] = null;
        return  data;
    }

    @Override
    public boolean IsEmpty() {
        return currentCount == 0;
    }

    @Override
    public T Peek() {
        if(currentCount == 0){
            throw new IllegalStateException("Stack is empty");
        }
        return (T)storage[currentCount - 1];
    }

    @Override
    public int Capacity() {
        return size;
    }

    @Override
    public int CurrentElements() {
        return currentCount;
    }
}


