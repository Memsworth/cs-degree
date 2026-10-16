def main():
    width_input = float(input("Enter width in ft: "))
    length_input = float(input("Enter length in ft: "))
    area_in_feet = width_input * length_input
    ft_in_acre = 43560

    print(f'Area of {width_input} & {length_input} is {area_in_feet}')
    print(f'In Acres: {area_in_feet/ft_in_acre}')

    

main()