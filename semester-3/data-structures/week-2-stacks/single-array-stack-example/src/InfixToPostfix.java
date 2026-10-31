
public class InfixToPostfix {

    private int precedence(char operator) {
        switch (operator) {
            case '^':
                return 3;
            case '*':
            case '/':
                return 2;
            case '+':
            case '-':
                return 1;
            default:
                return -1;
        }
    }

    private boolean isOperator(char c) {
        return c == '+' || c == '-' ||
                c == '*' || c == '/' || c == '^';
    }

    public String convert(String expression) {

        var stack = new MyTestStack<Character>(expression.length());

        var postfix = new StringBuilder();

        var expectOperand = true;

        for (int i = 0; i < expression.length(); i++) {

            var current = expression.charAt(i);

            if (Character.isWhitespace(current)) {
                continue;
            }

            if (Character.isLetterOrDigit(current)) {

                if (!expectOperand) {
                    throw new IllegalArgumentException(
                            "Invalid expression: Missing operator");
                }

                postfix.append(current);
                expectOperand = false;
            }

            else if (current == '(') {

                if (!expectOperand) {
                    throw new IllegalArgumentException(
                            "Invalid expression before '('");
                }

                stack.Push(current);
            }

            else if (current == ')') {

                if (expectOperand) {
                    throw new IllegalArgumentException(
                            "Invalid expression before ')'");
                }

                while (!stack.IsEmpty() && stack.Peek() != '(') {
                    postfix.append(stack.Pop());
                }

                if (stack.IsEmpty()) {
                    throw new IllegalArgumentException(
                            "Unbalanced parentheses: Extra ')'");
                }

                stack.Pop();
                expectOperand = false;
            }

            else if (isOperator(current)) {

                if (expectOperand) {
                    throw new IllegalArgumentException(
                            "Invalid expression: Operator in wrong position");
                }

                while (!stack.IsEmpty() &&
                        stack.Peek() != '(' &&
                        (precedence(stack.Peek()) > precedence(current) ||
                                (precedence(stack.Peek()) == precedence(current)
                                        && current != '^'))) {

                    postfix.append(stack.Pop());
                }

                stack.Push(current);
                expectOperand = true;
            }

            else {
                throw new IllegalArgumentException(
                        "Invalid character: " + current);
            }
        }

        if (expectOperand) {
            throw new IllegalArgumentException(
                    "Invalid expression: Incomplete expression");
        }

        while (!stack.IsEmpty()) {

            var operator = stack.Pop();

            if (operator == '(') {
                throw new IllegalArgumentException(
                        "Unbalanced parentheses: Missing ')'");
            }

            postfix.append(operator);
        }

        return postfix.toString();
    }

    public int evaluatePostfix(String postfix) {

        var stack = new MyTestStack<Integer>(postfix.length());

        for (int i = 0; i < postfix.length(); i++) {

            char current = postfix.charAt(i);

            if (Character.isWhitespace(current)) {
                continue;
            }

            if (Character.isDigit(current)) {
                stack.Push(current - '0');
            }

            else if (isOperator(current)) {

                if (stack.CurrentElements() < 2) {
                    throw new IllegalArgumentException(
                            "Invalid postfix expression");
                }

                int b = stack.Pop();
                int a = stack.Pop();

                int result;

                switch (current) {

                    case '+':
                        result = a + b;
                        break;

                    case '-':
                        result = a - b;
                        break;

                    case '*':
                        result = a * b;
                        break;

                    case '/':
                        if (b == 0) {
                            throw new ArithmeticException(
                                    "Division by zero");
                        }
                        result = a / b;
                        break;

                    case '^':
                        result = (int) Math.pow(a, b);
                        break;

                    default:
                        throw new IllegalArgumentException(
                                "Unknown operator");
                }

                stack.Push(result);
            }
        }

        if (stack.CurrentElements() != 1) {
            throw new IllegalArgumentException(
                    "Invalid postfix expression");
        }

        return stack.Pop();
    }

}
