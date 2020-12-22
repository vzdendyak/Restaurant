import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {MenuListComponent} from './menu/menu-list/menu-list.component';
import {DishInfoComponent} from './dish/dish-info/dish-info.component';
import {IngredientListComponent} from './ingredient/ingredient-list/ingredient-list.component';
import {OrderComponent} from './order/order/order.component';
import {RouterModule} from '@angular/router';
import {ApiService} from './services/api.service';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatOptionModule} from '@angular/material/core';

@NgModule({
  declarations: [
    AppComponent,
    MenuListComponent,
    DishInfoComponent,
    IngredientListComponent,
    OrderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(
      [
        {path: 'menu', component: MenuListComponent},
        {path: 'dishes/:id', component: DishInfoComponent},
        {path: 'ingredients', component: IngredientListComponent},
        {path: 'order', component: OrderComponent},
        {path: '**', redirectTo: 'menu'}
      ]),
    HttpClientModule,
    FormsModule,
    MatAutocompleteModule,
    MatOptionModule
  ],
  providers: [ApiService ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
