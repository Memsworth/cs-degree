def main():
    less_than_liter = float(0.10)
    more_than_liter = float(0.25)
    liter_or_less_count = int(input("Enter bottles that are liter or less: "))
    more_liter_count = int(input("Enter bottles that are more than one liter: "))
    total_amount = (less_than_liter * liter_or_less_count) + (more_than_liter * more_liter_count)
    print(f'Total = s{total_amount}$')

main()