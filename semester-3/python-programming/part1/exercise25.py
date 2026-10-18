def main():
    total_seconds = int(input("Enter the number of seconds: "))

    days = total_seconds // 86400
    remaining_seconds = total_seconds % 86400

    hours = remaining_seconds // 3600
    remaining_seconds = remaining_seconds % 3600

    minutes = remaining_seconds // 60
    seconds = remaining_seconds % 60

    print(f"{days}:{hours:02d}:{minutes:02d}:{seconds:02d}")

main()