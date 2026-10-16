def main():
    feet = int(input("Enter the number of feet: "))
    inches = int(input("Enter the number of inches: "))
    total_inches = (feet * 12) + inches
    centimeters = total_inches * 2.54
    print(f"Height in centimeters: {centimeters:.2f} cm")

main()