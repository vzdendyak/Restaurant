import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuListComponent } from './menu/menu-list/menu-list.component';
import { DishInfoComponent } from './dish/dish-info/dish-info.component';
import { IngredientListComponent } from './ingredient/ingredient-list/ingredient-list.component';
import { OrderComponent } from './order/order/order.component';
import { RouterModule } from '@angular/router';
import { ApiService } from './services/api.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatOptionModule } from '@angular/material/core';
import { SingleIngredientComponent } from './ingredient/single-ingredient/single-ingredient.component';
import { AddOrderComponent } from './add-order/add-order.component';
import { MatDialogModule } from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [
    AppComponent,
    MenuListComponent,
    DishInfoComponent,
    IngredientListComponent,
    OrderComponent,
    SingleIngredientComponent,
    AddOrderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(
      [
        { path: 'menu', component: MenuListComponent },
        { path: 'dishes/:id', component: DishInfoComponent },
        { path: 'ingredients', component: IngredientListComponent },
        { path: 'ingredient/:id', component: SingleIngredientComponent },
        { path: 'order', component: OrderComponent },
        { path: 'order/new', component: AddOrderComponent },
        { path: '**', redirectTo: 'menu' }
      ]),
    HttpClientModule,
    FormsModule,
    MatAutocompleteModule,
    MatOptionModule,
    MatDialogModule,
    BrowserAnimationsModule,
    MatSelectModule
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
