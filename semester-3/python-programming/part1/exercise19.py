import math

def main():
    height = float(input("Enter the height in meters: "))
    initial_speed = 0
    gravity = 9.8
    final_speed = math.sqrt(initial_speed ** 2 + 2 * gravity * height)
    print(f"The object hits the ground at {final_speed:.2f} m/s")


main()