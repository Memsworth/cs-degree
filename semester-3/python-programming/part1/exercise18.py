import math
def main():
    radius = float(input("Enter the radius of the cylinder: "))
    height = float(input("Enter the height of the cylinder: "))
    volume = math.pi * radius ** 2 * height

    print(f"The volume of the cylinder is {volume:.1f}")

main()