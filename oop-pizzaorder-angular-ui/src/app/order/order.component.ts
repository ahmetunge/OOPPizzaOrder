import { SharedService } from './../shared/shared.service';
import { PizzaToAddCart } from './../models/pizzaToAddCart';
import { PizzaTypeForOrder } from './../models/pizzaTypeForOrder';
import { SizeForOrder } from './../models/sizeForOrder';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { OrderService } from './order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
  providers: [OrderService]
})
export class OrderComponent implements OnInit {
  constructor(
    private orderService: OrderService,
    private formBuilder: FormBuilder,
    private router: Router,
    private sharedService: SharedService
  ) { }

  submitted = false;

  submitForm: FormGroup;

  sizeId: FormControl = new FormControl('', [Validators.required]);
  pizzaTypeId = new FormControl('', Validators.required);
  numberOfPizza = new FormControl('', Validators.required);
  sizesForOrder: SizeForOrder[] = [];
  pizzaTypesForOrder: PizzaTypeForOrder[] = [];
  toppingsForOrder: string[] = [];
  selectedToppings: string[] = [];
  pizzaToAddCart: PizzaToAddCart = new PizzaToAddCart();

  edgeTypeId = new FormControl('0');

  ngOnInit() {
    this.toppingsForOrder = [];
    this.selectedToppings = [];
    this.getAllSizesFromService();
    this.getAllPizzaTypsFromService();
    this.getAllToppings();
    this.createValidation();
  }

  createValidation() {
    this.submitForm = this.formBuilder.group({
      sizeId: this.sizeId,
      pizzaTypeId: this.pizzaTypeId,
      numberOfPizza: this.numberOfPizza,
      edgeTypeId: this.edgeTypeId
    });
  }

  get f() {
    return this.submitForm.controls;
  }

  getAllSizesFromService() {
    this.orderService.getAllSizes().subscribe(res => {
      this.sizesForOrder = res;
    });
  }

  getAllPizzaTypsFromService() {
    this.orderService.getAllPizzaTypes().subscribe(res => {
      this.pizzaTypesForOrder = res;
    });
  }

  getAllToppings() {
    this.orderService.getToppings().subscribe(res => {
      this.toppingsForOrder = res;
    });
  }

  // Cahnge event of checkboxesd
  onChange(event) {
    if (event.checked) {
      this.selectedToppings.push(event.source.value);
    } else {
      const i = this.selectedToppings.findIndex(x => x === event.source.value);
      this.selectedToppings.splice(i, 1);
    }
  }

  onSubmit() {
    const x = this.selectedToppings;
    this.submitted = true;
    if (this.submitForm.invalid) {
      return;
    }
    this.pizzaToAddCart = this.submitForm.value;
    this.pizzaToAddCart.toppings = this.selectedToppings;
    this.pizzaToAddCart.edgeTypeId = this.edgeTypeId.value;
    this.sendPizzasToService();
  }


  sendPizzasToService() {
    this.orderService.submitPizza(this.pizzaToAddCart).subscribe(res => {
      this.sendTotalNumbersToNavbar(res);
    });
  }

  sendTotalNumbersToNavbar(total: number) {
    this.sharedService.sendTotalNumber(total);
  }
}
