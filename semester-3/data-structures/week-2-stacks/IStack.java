public interface IStack<T> {
    public void Push(T data);
    public T Pop();
    public boolean IsEmpty();
    public T Peek();
    public int Capacity();
    public int CurrentElements();
}