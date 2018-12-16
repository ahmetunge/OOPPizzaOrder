import { CartLine } from './cartLine';

export class Cart {
    cartLines: CartLine[];
    totalPrice: number;
    totalQuantity: number;
}
