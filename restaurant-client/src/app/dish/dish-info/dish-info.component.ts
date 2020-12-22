import {Component, OnInit} from '@angular/core';
import {ApiService} from '../../services/api.service';
import {ActivatedRoute} from '@angular/router';
import {Dish} from '../../data/dish';

@Component({
  selector: 'app-dish-info',
  templateUrl: './dish-info.component.html',
  styleUrls: ['./dish-info.component.scss']
})
export class DishInfoComponent implements OnInit {
  dishId: number;
  dish: Dish;
  isEdit: boolean = false;

  constructor(private route: ActivatedRoute, private apiService: ApiService) {
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
    console.log(this.dish);
  }

  edit() {
    this.isEdit = !this.isEdit;
  }
}
