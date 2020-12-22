import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu/menu.component';
import { MenuListComponent } from './menu/menu-list/menu-list.component';
import { DishInfoComponent } from './dish/dish-info/dish-info.component';
import { IngredientListComponent } from './ingredient/ingredient-list/ingredient-list.component';
import { OrderComponent } from './order/order/order.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    MenuListComponent,
    DishInfoComponent,
    IngredientListComponent,
    OrderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
