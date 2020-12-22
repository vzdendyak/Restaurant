import {Component, OnInit} from '@angular/core';
import {Ingredient} from '../../data/ingredient';
import {ApiService} from '../../services/api.service';

@Component({
  selector: 'app-ingredient-list',
  templateUrl: './ingredient-list.component.html',
  styleUrls: ['./ingredient-list.component.scss']
})
export class IngredientListComponent implements OnInit {
  ingredients: Ingredient[];
  newIngName = '';

  constructor(private api: ApiService) {

    this.load();
  }

  ngOnInit(): void {
  }

  load() {
    this.api.getIngredients().subscribe(value => {
      this.ingredients = value;
    });
  }

  delete(id: number) {
    this.api.deleteIngredient(id).subscribe(value => {
      this.load();
    });
  }

  addIngredient() {
    this.newIngName = this.newIngName.trim();
    if (this.newIngName.length === 0) {
      return;
    }
    const ingredient: Ingredient = {
      name: this.newIngName,
      id: 0
    };
    this.api.createIngredient(ingredient).subscribe(value => {
      this.load();
      this.newIngName = '';
    });
  }
}
