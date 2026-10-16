def main():
    widget_weight = int(75)
    gizmo_weight = int(112)

    gizmo_amount = int(input("Enter gizmo count: "))
    widget_amount = int(input("Enter widget count: "))

    total_gizmo_weight = gizmo_amount * gizmo_weight / 1000
    total_widget_weight = widget_amount * widget_weight / 1000

    print(f'gizmo weight: {total_gizmo_weight}KG')
    print(f'widget weight: {total_widget_weight}KG')

main()