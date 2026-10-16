def main():
    feet = float(input("Enter distance in feet: "))
    inches = feet * 12
    yards = feet / 3
    miles = feet / 5280
    print(f"Inches: {inches:.2f}")
    print(f"Yards: {yards:.2f}")
    print(f"Miles: {miles:.6f}")

main()