import { AddOrderComponent } from './../../add-order/add-order.component';
import { Order } from './../../data/order';
import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  isAddNew = false;

  orders: Order[];
  numberTable: number;
  ownerName: string;

  constructor(private apiService: ApiService, public dialog: MatDialog, private router: Router) {
  }

  ngOnInit(): void {
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

  deleteOrder(id: number) {
    this.apiService.deleteOrder(id).subscribe(value => {
      console.log(value);
      this.refresh();
    });
  }

  addDishToOrder() {
    console.log("addDishToOrder");
  }

  removeDishFromOrder(id: number) {
    console.log("removeDishFromOrder" + id);
    this.apiService.removeDishFromOrder(id).subscribe(value => {
      console.log(value);
      this.refresh();
    });
  }
}
