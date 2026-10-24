public class App {
    public static void main(String[] args) throws Exception {

        var myTestStack = new TestStack<Integer>();

        // push to first stack
        System.out.println("=== Pushing onto Stack 0 ===");
        myTestStack.Push(0, 10);
        myTestStack.Push(0, 20);
        myTestStack.Push(0, 30);

        myTestStack.Push(0, 40);
        myTestStack.Push(0, 50);

        // push to secondStack
        System.out.println("\n=== Pushing onto Stack 1 ===");
        myTestStack.Push(1, 100);
        myTestStack.Push(1, 200);

        // push in third
        System.out.println("\n=== Pushing onto Stack 2 ===");
        myTestStack.Push(2, 1000);

        // printStack
        for (int i = 0; i < 3; i++) {
            System.out.printf("Stack %d: elements = %d, empty = %b%n",
                    i,
                    myTestStack.CurrentElements(i),
                    myTestStack.IsEmpty(i));

            if (!myTestStack.IsEmpty(i)) {
                System.out.printf("Stack %d top element: %d%n",
                        i,
                        myTestStack.Peek(i));
            }
        }

        // pop from firstStack
        System.out.println("\n=== Popping from Stack 0 ===");
        System.out.println("Popped: " + myTestStack.Pop(0));
        System.out.println("Popped: " + myTestStack.Pop(0));

        // printdata after pop
        System.out.println("Stack 0 remaining elements: "
                + myTestStack.CurrentElements(0));

        System.out.println("Stack 0 top element: "
                + myTestStack.Peek(0));

        // check other stakcs after dele
        System.out.println("\n=== Checking Other myTestStack ===");
        System.out.println("Stack 1 top: " + myTestStack.Peek(1));
        System.out.println("Stack 2 top: " + myTestStack.Peek(2));

        // empty firstStack all of it
        System.out.println("\n=== Emptying Stack 0 ===");
        while (!myTestStack.IsEmpty(0)) {
            System.out.println("Popped: " + myTestStack.Pop(0));
        }

        System.out.println("Is Stack 0 empty? " + myTestStack.IsEmpty(0));
    }
}
