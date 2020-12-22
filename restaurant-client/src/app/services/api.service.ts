import { Order } from './../data/order';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Dish } from '../data/dish';
import { Ingredient } from '../data/ingredient';
import { DishOrder } from '../data/dishOrder';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  dishUrl: string = environment.apiUrl + '/dishes';
  ingredientUrl: string = environment.apiUrl + '/ingredients';
  orderUrl: string = environment.apiUrl + '/orders';

  constructor(private http: HttpClient) {
  }

  getDishes(): Observable<Dish[]> {
    return this.http.get<Dish[]>(this.dishUrl);
  }

  getDish(id: number): Observable<Dish> {
    return this.http.get<Dish>(`${this.dishUrl}/${id}`);
  }

  getDishIngredients(dishId: number): Observable<Ingredient[]> {
    return this.http.get<Ingredient[]>(`${this.dishUrl}/${dishId}/ingredients`);
  }


  createDish(item: Dish): Observable<any> {
    return this.http.post(this.dishUrl, item);
  }

  updateDish(item: Dish): Observable<any> {
    return this.http.put(this.dishUrl, item);
  }

  updateIngredient(item: Ingredient) {
    return this.http.put(this.ingredientUrl, item);

  }

  deleteDish(dishId: number): Observable<any> {
    return this.http.delete(this.dishUrl + `/${dishId}`);
  }

  getIngredients(): Observable<Ingredient[]> {
    return this.http.get<Ingredient[]>(this.ingredientUrl);
  }

  getIngredientsByName(name: string): Observable<Ingredient[]> {
    if (name.length == 0) {
      name = 'null';
    }
    return this.http.get<Ingredient[]>(`${this.ingredientUrl}/name/${name}`);
  }

  addIngredientToDish(dishId: number, ingredientId: number) {
    return this.http.post(`${this.dishUrl}/${dishId}/ingredients/${ingredientId}`, null);
  }

  removeIngredientFromDish(dishId: number, ingredientId: number) {
    return this.http.delete(`${this.dishUrl}/${dishId}/ingredients/${ingredientId}`);
  }

  deleteIngredient(id: number) {
    return this.http.delete(`${this.ingredientUrl}/${id}`);
  }

  createIngredient(ingredient: Ingredient) {
    return this.http.post(this.ingredientUrl, ingredient);
  }

  getIngredient(ingId: number) {
    return this.http.get<Ingredient>(`${this.ingredientUrl}/${ingId}`);
  }


  // Orders
  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.orderUrl}`);
  }

  getOrderDish(ordersId: number): Observable<DishOrder[]> {
    return this.http.get<DishOrder[]>(`${this.orderUrl}/dishOrders/${ordersId}`);
  }

  createOrder(item: Order): Observable<any> {
    return this.http.post(this.orderUrl, item);
  }

  deleteOrder(id: number) {
    return this.http.delete(`${this.orderUrl}/${id}`);
  }

  removeDishFromOrder(dishOrdersId: number) {
    return this.http.delete(`${this.orderUrl}/dishOrders/${dishOrdersId}`);
  }

 /*  addDishToOrder(order: Order) {
    return this.http.post(`${this.orderUrl}/dishOrders`, order);
  } */
}
