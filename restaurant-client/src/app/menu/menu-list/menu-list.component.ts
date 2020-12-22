import {Component, OnInit} from '@angular/core';
import {Dish} from '../../data/dish';
import {ApiService} from '../../services/api.service';

@Component({
  selector: 'app-menu-list',
  templateUrl: './menu-list.component.html',
  styleUrls: ['./menu-list.component.scss']
})
export class MenuListComponent implements OnInit {
  dishes: Dish[];

  constructor(private apiService: ApiService) {
    this.apiService.getDishes().subscribe(value => {
      this.dishes = value;
      this.dishes.forEach((d) => {
        this.apiService.getDishIngredients(d.id).subscribe(value1 => {
          d.ingredients = value1;
        });
      });
    });
    console.log('got' + this.dishes);
  }

  ngOnInit(): void {
  }

}
