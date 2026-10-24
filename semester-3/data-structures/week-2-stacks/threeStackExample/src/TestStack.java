import java.util.Stack;

public class TestStack<T> implements IStack<T> {

    private Object[] storage;
    private int[] count;
    private int[] stackTop = { -1, -1, -1 };
    private final int capacity;

    public TestStack() {
        storage = new Object[14];
        count = new int[3];
        capacity = 4;
    }

    @Override
    public void Push(int stack, T data) {

        // TODO DRY: Fix this dry later
        var isStack = IsStack(stack);

        if (!isStack) {
            System.out.println("Error");
            return;
        } else if (count[stack] == capacity) {
            System.err.println("Full");
            return;
        }

        var base = stack * capacity;
        var index = base + count[stack];

        storage[index] = data;
        count[stack]++;
        stackTop[stack] = index;
    }

    @Override
    public T Pop(int stack) {
        if (!IsStack(stack)) {
            throw new IllegalArgumentException("Invalid stack index");
        }

        if (count[stack] == 0) {
            throw new IllegalStateException("Stack is empty");
        }

        var base = stack * capacity;
        var index = base + count[stack] - 1;

        var data = (T) storage[index];

        storage[index] = null;
        count[stack]--;

        stackTop[stack] = count[stack] == 0
                ? -1
                : base + count[stack] - 1;

        return data;
    }

    @Override
    public boolean IsEmpty(int stack) {

        // TODO DRY: Fix this dry later
        var isStack = IsStack(stack);

        if (!isStack) {
            System.out.println("Error");
            return false;
        }
        return count[stack] == 0;
    }

    @Override
    public T Peek(int stack) {
        if (!IsStack(stack)) {
            throw new IllegalArgumentException("Invalid stack index");
        }

        if (count[stack] == 0) {
            throw new IllegalStateException("Stack is empty");
        }

        var base = stack * capacity;
        var index = base + count[stack] - 1;

        var data = (T) storage[index];

        return data;
    }

    @Override
    public int CurrentElements(int stack) {

        var isStack = IsStack(stack);

        if (!isStack) {
            System.out.println("Error");
            return -1;
        }
        return count[stack];
    }

    private boolean IsStack(int stack) {
        if (stack >= 3 || stack < 0)
            return false;
        return true;
    }

}
