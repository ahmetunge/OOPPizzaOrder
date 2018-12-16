import { HttpRouteGetter } from 'src/helpers/httpRouteGetter';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Cart } from '../models/cart';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(
    private httpClient: HttpClient,
  ) { }

  httpRouteGetter = new HttpRouteGetter();

  requestOptions = {
    headers: new HttpHeaders({
      'Authorization': 'my-request-token'
    }),
    withCredentials: true
  };

  getPizzasFromCart() {
    const route = this.httpRouteGetter.httpRoute + 'cart' + '/pizzas';

    return this.httpClient.get<Cart>(route, this.requestOptions);
  }

  getPizzasTotalQuantity() {
    const route = this.httpRouteGetter.httpRoute + 'cart' + '/pizzas/totalQuantity';

    return this.httpClient.get<number>(route, this.requestOptions);
  }

  deletePizzaFromCart(pizzaId: number) {
    const route = this.httpRouteGetter.httpRoute + 'cart' + '/pizzas/' + pizzaId.toString();

    return this.httpClient.delete<Cart>(route, this.requestOptions);
  }

}
