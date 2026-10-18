import math

def main():
    s1 = float(input("Enter the length of the first side: "))
    s2 = float(input("Enter the length of the second side: "))
    s3 = float(input("Enter the length of the third side: "))

    s = (s1 + s2 + s3) / 2
    area = math.sqrt(s * (s - s1) * (s - s2) * (s - s3))
    print(f"The area of the triangle is {area:.2f}")

main()