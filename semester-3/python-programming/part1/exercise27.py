def main():

    height = float(input("Enter your height in meters: "))
    weight = float(input("Enter your weight in kilograms: "))

    bmi = weight / (height * height)

    print(f"Your BMI is {bmi:.2f}")

main()