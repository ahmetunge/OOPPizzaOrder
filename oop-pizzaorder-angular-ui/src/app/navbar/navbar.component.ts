
import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared/shared.service';
import { CartService } from '../shared/cart.service';
import { Cart } from '../models/cart';
import * as $ from 'jquery';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  constructor(
    private sharedService: SharedService,
    private cartService: CartService
  ) {
    this.sharedService.currentValue.subscribe(res => {
      this.totalPizzas = res;
      if (this.totalPizzas === 0) {
        this.doCartButtonDisable();
      } else {
        this.doCartButtonEnable();
      }
    });
  }
  totalPizzas = 0;

  cart = new Cart();

  ngOnInit() {
    this.getPizzasTotalQuantity();
  }

  getPizzasInCart() {
    this.cartService.getPizzasFromCart().subscribe(res => {
      this.cart = res;
      if (this.cart.totalQuantity > 0) {
        this.doCartButtonEnable();
      } else {
        this.doCartButtonDisable();
      }
    });
  }

  getPizzasTotalQuantity() {
    this.cartService.getPizzasTotalQuantity().subscribe(res => {
      this.totalPizzas = res;
      if (this.totalPizzas === 0) {
        this.doCartButtonDisable();
      } else {
        this.doCartButtonEnable();
      }
    });
  }

  deletePizzaFromCart(pizzaId: number) {
    this.cartService.deletePizzaFromCart(pizzaId).subscribe(res => {
      this.cart = res;
      this.totalPizzas = this.cart.totalQuantity;
      if (this.cart.totalQuantity > 0) {
        this.doCartButtonEnable();
      } else {
        this.doCartButtonDisable();
        $('.close').click();
      }
    });
  }

  doCartButtonDisable() {

    $('#btnCart').attr('disabled', true);
  }

  doCartButtonEnable() {

    $('#btnCart').attr('disabled', false);
  }

}

