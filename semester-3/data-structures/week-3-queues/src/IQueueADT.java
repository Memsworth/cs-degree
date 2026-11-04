public interface IQueueADT<T> {

    public void Enqueue(T data);

    public T Dequeue();

    public boolean IsEmpty();

    public boolean IsFull();
}