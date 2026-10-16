import math

def main():
    a = int(input("Enter the first integer (a): "))
    b = int(input("Enter the second integer (b): "))

    print("Sum:", a + b)
    print("Difference:", a - b)
    print("Product:", a * b)
    print("Quotient:", a / b)
    print("Remainder:", a % b)
    print("log10(a):", math.log10(a))
    print("a raised to the power b:", a ** b)


main()