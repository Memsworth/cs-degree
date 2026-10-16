import math

def main():
    t1 = float(input("Enter latitude of point 1: "))
    g1 = float(input("Enter longitude of point 1: "))

    t2 = float(input("Enter latitude of point 2: "))
    g2 = float(input("Enter longitude of point 2: "))

    t1 = math.radians(t1)
    g1 = math.radians(g1)
    t2 = math.radians(t2)
    g2 = math.radians(g2)

    distance = 6371.01 * math.acos(math.sin(t1) * math.sin(t2)
    + math.cos(t1) * math.cos(t2) * math.cos(g1 - g2))

    print(f"Distance: {distance:.2f} kilometers")


main()