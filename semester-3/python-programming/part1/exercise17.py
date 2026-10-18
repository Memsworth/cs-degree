def main():
    heatCapacity = float(4.186)
    water_input = int(input("Enter water in milliliters: "))
    start_temp = float(input("Start temp: "))
    end_temp = float(input("end temp: "))
    delta = end_temp - start_temp

    energy_needed = water_input * heatCapacity * delta
    print(f'To raise {water_input}ml of water from {start_temp}C to '
          + f'{end_temp}C, you need {energy_needed}')

    electricity_cost = float(8.9)

    total_cost_in_usd = energy_needed * 2.7777777777778E-7 * electricity_cost

    print(f'cost of heating up water is {total_cost_in_usd:.62f} Cents')


main()