import {Component, OnInit} from '@angular/core';
import {ApiService} from '../../services/api.service';
import {ActivatedRoute} from '@angular/router';
import {Dish} from '../../data/dish';
import {Ingredient} from '../../data/ingredient';
import {MatOptionSelectionChange} from '@angular/material/core';

@Component({
  selector: 'app-dish-info',
  templateUrl: './dish-info.component.html',
  styleUrls: ['./dish-info.component.scss']
})
export class DishInfoComponent implements OnInit {
  dishId: number;
  dish: Dish;
  isEdit = false;
  ingredientsAll: Ingredient[];
  searchText = '';

  constructor(private route: ActivatedRoute, private apiService: ApiService) {
    this.apiService.getIngredients().subscribe(value => {
      this.ingredientsAll = value;
      console.log(this.ingredientsAll);
    });
    this.route.params.subscribe(params => {
      if (params.id) {
        this.dishId = params.id;
        this.apiService.getDish(this.dishId).subscribe(value => {
          this.dish = value;
          this.apiService.getDishIngredients(this.dishId).subscribe(value1 => {
            this.dish.ingredients = value1;
          });
        });
      }
    });

  }

  ngOnInit(): void {
  }


  saveDish() {
    this.dish.price = parseInt(String(this.dish.price));
    this.dish.portionWeight = parseInt(String(this.dish.portionWeight));
    this.dish.cookMinutes = parseInt(String(this.dish.cookMinutes));
    console.log(this.dish);

    this.apiService.updateDish(this.dish).subscribe(value => {
      console.log(value);
    });
  }

  edit() {
    this.isEdit = !this.isEdit;
  }

  updIngredients() {
    this.apiService.getIngredientsByName(this.searchText).subscribe(value => {
      this.ingredientsAll = value;
    });
  }

  addIngredient(event: MatOptionSelectionChange) {
    console.log(event.source.value);
    const ing = event.source.value;
    this.apiService.addIngredientToDish(this.dishId, ing.id).subscribe(value => {
      this.dish.ingredients.push(ing);
    });
  }

  deleteIngredient(id: number) {
    console.log(id);
    const index = this.dish.ingredients.findIndex(i => i.id == id);
    if (index > -1) {
      this.apiService.removeIngredientFromDish(this.dishId, id).subscribe(value => {
        this.dish.ingredients.splice(index, 1);
      });
    }
  }
}
