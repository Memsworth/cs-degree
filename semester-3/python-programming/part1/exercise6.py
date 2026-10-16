def main():
    tip_percentage = float(0.18)
    local_tax = float(0.025)
    meal_cost = float(input("Enter meal cost: "))
    print(f'meal cost: {meal_cost}$')
    print(f'local tax: {local_tax * meal_cost}$ at {local_tax}')
    print(f'tip percentage cost: {meal_cost * tip_percentage}$ at {tip_percentage}')
    total_amount = meal_cost + (local_tax * meal_cost) + (meal_cost * tip_percentage)
    print(f'Total = {total_amount}$')

main()