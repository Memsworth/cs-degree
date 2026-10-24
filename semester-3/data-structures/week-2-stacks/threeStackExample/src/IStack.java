public interface IStack<T> {
    public void Push(int stack, T data);

    public T Pop(int stack);

    public boolean IsEmpty(int stack);

    public T Peek(int stack);

    public int CurrentElements(int stack);
}
