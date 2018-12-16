import { Cart } from './../models/cart';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SizeForOrder } from '../models/sizeForOrder';
import { PizzaTypeForOrder } from '../models/pizzaTypeForOrder';
import { HttpRouteGetter } from 'src/helpers/httpRouteGetter';



@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(
    private httpClient: HttpClient
  ) { }

  httpRouteGetter: HttpRouteGetter = new HttpRouteGetter();
  requestOptions = {
    headers: new HttpHeaders({
      'Authorization': 'my-request-token'
    }),
    withCredentials: true
  };

  getAllSizes() {
    const route = this.httpRouteGetter.httpRoute + 'pizzaorder/sizes';
    return this.httpClient.get<SizeForOrder[]>(route);

  }


  getAllPizzaTypes() {
    const route = this.httpRouteGetter.httpRoute + 'pizzaorder/pizzatypes';
    return this.httpClient.get<PizzaTypeForOrder[]>(route);
  }

  getToppings() {
    const route = this.httpRouteGetter.httpRoute + 'pizzaorder/toppings';
    return this.httpClient.get<string[]>(route);
  }

  submitPizza(pizza: any) {

    const route = this.httpRouteGetter.httpRoute + 'cart/addPizzaToCart';
    return this.httpClient.post<number>(route, pizza, this.requestOptions);
  }

  getPizzasFromCart() {

    const route = this.httpRouteGetter.httpRoute + 'cart/pizzas';
    return this.httpClient.get<Cart>(route, this.requestOptions);
  }
  /*
    submitPizza(pizza: any) {
        const requestOptions = {
        headers: new HttpHeaders({
          'Authorization': 'my-request-token'
        }),
        withCredentials: true
      };
      const route = this.httpRouteGetter.httpRoute + 'carttest';
      return this.httpClient.get(route, requestOptions);
    }
    */

}
