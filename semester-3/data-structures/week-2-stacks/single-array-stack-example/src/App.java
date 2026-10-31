void main() {

    var converter = new InfixToPostfix();
    String[] expressions = {
            "2+3*4",
            "(2+3)*4",
            "8/2+5",
            "2+3)",
            "2++3",
            "10-4*2"
    };

    for (String expression : expressions) {

        System.out.println("\nInfix: " + expression);

        try {

            var postfix = converter.convert(expression);

            System.out.println("Postfix: " + postfix);

            var answer = converter.evaluatePostfix(postfix);

            System.out.println("Answer: " + answer);

        } catch (IllegalArgumentException | ArithmeticException e) {

            System.out.println("ERROR: " + e.getMessage());
        }
    }
}
