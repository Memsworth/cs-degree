void main() {

    IStack<Integer> testStack = new MyTestStack<Integer>(5);
    System.out.println("Hello from second line");
    Scanner sc = new Scanner(System.in);
    for (int i = 0; i < 5; i++) {
        System.out.printf("Stack capacity: %d, elements: %d%n\n", testStack.Capacity(), testStack.CurrentElements());
        System.out.println("Enter an integer: ");
        Integer userInput = sc.nextInt();
        testStack.Push(userInput);
    }


    for (int i = 0; i < 5; i++) {
        System.out.printf("Stack capacity: %d, elements: %d%n\n", testStack.Capacity(), testStack.CurrentElements());
        System.out.println("popping an element");
        Integer data = testStack.Pop();
        System.out.println("popped: "+ data);
    }
}

