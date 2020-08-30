import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HeaderService {
  burgerActive: boolean;

  constructor() {
    this.burgerActive = false;
  }

  burgerClick(): void {
    this.burgerActive = !this.burgerActive;
    document.body.classList.toggle('lock');
  }
}
