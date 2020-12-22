import {Ingredient} from './ingredient';

export class Dish {
  public id: number;
  public price: number;
  public name: string;
  public description: string;
  public portionWeight: string;
  public cookMinutes: string;
  public ingredients: Ingredient[];
}
