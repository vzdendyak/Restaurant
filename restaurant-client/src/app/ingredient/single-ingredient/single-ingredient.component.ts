import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {ApiService} from '../../services/api.service';
import {Ingredient} from '../../data/ingredient';

@Component({
  selector: 'app-single-ingredient',
  templateUrl: './single-ingredient.component.html',
  styleUrls: ['./single-ingredient.component.scss']
})
export class SingleIngredientComponent implements OnInit {
  ingredient: Ingredient;
  ingId: number;
  isEdit = false;

  constructor(private route: ActivatedRoute, private apiService: ApiService) {
    this.route.params.subscribe(params => {
      if (params.id) {
        this.ingId = params.id;
        this.apiService.getIngredient(this.ingId).subscribe(value => {
          this.ingredient = value;
        });
      }
    });
  }

  ngOnInit(): void {
  }

  edit() {
    this.isEdit = !this.isEdit;
  }

  save() {
    this.apiService.updateIngredient(this.ingredient).subscribe(value => {
      console.log(value);
    });
  }
}
