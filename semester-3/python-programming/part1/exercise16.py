import math

def main():
    r = float(input("Enter the radius: "))
    area = math.pi * r ** 2
    volume = (4 / 3) * math.pi * r ** 3

    print("Area of the circle:", area)
    print("Volume of the sphere:", volume)

main()