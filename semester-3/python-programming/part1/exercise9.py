def main():
    deposit = float(input("Enter the amount deposited: "))
    interest_rate = 0.04

    balance = deposit * (1 + interest_rate)
    print(f"Balance after 1 year: ${balance:.2f}")

    balance = balance * (1 + interest_rate)
    print(f"Balance after 2 years: ${balance:.2f}")

    balance = balance * (1 + interest_rate)
    print(f"Balance after 3 years: ${balance:.2f}")


main()