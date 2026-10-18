def main():

    number = int(input("Enter a four-digit integer: "))

    d1 = number // 1000
    d2 = (number // 100) % 10
    d3 = (number // 10) % 10
    d4 = number % 10

    total = d1 + d2 + d3 + d4
    print(f"{d1} + {d2} + {d3} + {d4} = {total}")

main()