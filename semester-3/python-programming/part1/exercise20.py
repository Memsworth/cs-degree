def main():

    R = 8.314 
    pressure = float(input("Enter pressure in Pascals: "))
    volume = float(input("Enter volume in liters: "))
    temperature_c = float(input("Enter temperature in Celsius: "))
    temperature_k = temperature_c + 273.15
    volume_m3 = volume / 1000

    moles = (pressure * volume_m3) / (R * temperature_k)

    print(f"Amount of gas: {moles:.2f} moles")

main()