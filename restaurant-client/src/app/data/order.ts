import { DishOrder } from "./dishOrder";

export class Order {
    public id: number;
    public tableNumber: number;
    public ownerName: string;
    public totalPrice: number;
    public dishOrder: DishOrder[];
}
