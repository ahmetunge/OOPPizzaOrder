import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SharedService {
  private valueSource = new BehaviorSubject<number>(0);
  currentValue = this.valueSource.asObservable();
  constructor() { }
  sendTotalNumber(message: number) {
    this.valueSource.next(message);
  }

}
