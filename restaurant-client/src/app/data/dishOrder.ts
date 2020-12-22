import { Dish } from './dish';
export class DishOrder {
    public id: number;
    public orderId: number;
    public dishId: number;
    public portionNumber: number;
    public dish: Dish;
}
