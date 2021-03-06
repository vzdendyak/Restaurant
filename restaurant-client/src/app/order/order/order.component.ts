import { DishOrder } from './../../data/dishOrder';
import { AddOrderComponent } from './../../add-order/add-order.component';
import { Order } from './../../data/order';
import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Dish } from 'src/app/data/dish';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  tableForSearch: number = null;

  dishes: Dish[];

  isAddNew = false;
  isUpdate = false;

  orders: Order[];
  numberTable: number;
  ownerName: string;

  isAddDishToOrder = false;

  choseOrderId = 0;

  portionNumber: number = null;

  selectedValue: string;

  constructor(private apiService: ApiService, public dialog: MatDialog, private router: Router) {

  }

  ngOnInit(): void {
    this.apiService.getDishes().subscribe(value => {
      this.dishes = value;
      this.dishes.forEach((d) => {
        this.apiService.getDishIngredients(d.id).subscribe(value1 => {
          d.ingredients = value1;
          console.log(this.dishes);
        });
      });
    });
    this.refresh();
  }

  refresh() {
    this.apiService.getOrders().subscribe(value => {
      this.orders = value;
      this.orders.forEach((d) => {
        this.apiService.getOrderDish(d.id).subscribe(value1 => {
          d.dishOrder = value1;
          d.dishOrder.forEach((a) => {
            this.apiService.getDish(a.dishId).subscribe(value2 => {
              a.dish = value2;
            });
          });
        });
      });
    });
  }

  show(orderId: number) {
    console.log(this.selectedValue + "  " + orderId);
  }

  searchByTableNumber() {
    this.apiService.searchByTableNumber(this.tableForSearch).subscribe(value => {
      this.orders = value;
      this.orders.forEach((d) => {
        this.apiService.getOrderDish(d.id).subscribe(value1 => {
          d.dishOrder = value1;
          d.dishOrder.forEach((a) => {
            this.apiService.getDish(a.dishId).subscribe(value2 => {
              a.dish = value2;
              console.log(this.orders);
            });
          });
        });
      });
    });
  }

  addNewOrder() {
    console.log(this.numberTable + this.ownerName);
    if (this.isAddNew && this.numberTable != 0 && this.ownerName != '') {
      const order: Order = {
        id: 0,
        tableNumber: Number(this.numberTable),
        ownerName: this.ownerName,
        totalPrice: 0,
        dishOrder: null
      };
      this.apiService.createOrder(order).subscribe(value => {
        this.numberTable = 0;
        this.ownerName = '';
        this.refresh();
      });
    }
    this.numberTable = null;
    this.ownerName = '';
    this.isAddNew = !this.isAddNew;
  }

  updateOrder(order: Order) {
    this.choseOrderId = order.id;
    if (this.isUpdate && this.numberTable != 0 && this.ownerName != '') {
      const orderUp: Order = {
        id: order.id,
        tableNumber: Number(this.numberTable),
        ownerName: this.ownerName,
        totalPrice: order.totalPrice,
        dishOrder: order.dishOrder
      };
      console.log(orderUp);
      this.apiService.updateOrder(orderUp).subscribe(value => {
        console.log(value);
        this.refresh();
      });
    }
    this.ownerName = '';
    this.isUpdate = !this.isUpdate;
  }

  deleteOrder(id: number) {
    this.apiService.deleteOrder(id).subscribe(value => {
      console.log(value);
      this.refresh();
    });
  }

  addDishToOrder(orderId: number) {
    console.log("addDishToOrder " + orderId);
    this.choseOrderId = orderId;
    this.isAddDishToOrder = !this.isAddDishToOrder;
  }

  addDishToOrderSubmit(orderId: number) {
    console.log(this.selectedValue + "   " + orderId);
    if (this.portionNumber != 0 && this.selectedValue != "") {
      const dishOrder: DishOrder = {
        id: 0,
        orderId: orderId,
        dishId: Number(this.selectedValue),
        portionNumber: this.portionNumber,
        dish: null
      };
      this.apiService.addDishToOrder(dishOrder).subscribe(value => {
        console.log(value);
        this.refresh();
      });
    }
  }

  removeDishFromOrder(id: number) {
    console.log("removeDishFromOrder" + id);
    this.apiService.removeDishFromOrder(id).subscribe(value => {
      console.log(value);
      this.refresh();
    });
  }
}
