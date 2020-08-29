import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  burgerActive: boolean;
  meaningsExpanded: boolean;
  collocationsExpanded: boolean;

  constructor() {
    this.burgerActive = false;
    this.collocationsExpanded = true;
    this.meaningsExpanded = true;
  }

  ngOnInit(): void {
  }

  burgerClick(): void {
    this.burgerActive = !this.burgerActive;
    // document.body.classList.add('lock');
    // document.body.classList.remove('lock');
    document.body.classList.toggle('lock');
  }

  meaningsClick(): void {
    this.meaningsExpanded = !this.meaningsExpanded;
  }

  collocationsClick(): void {
    this.collocationsExpanded = !this.collocationsExpanded;
  }
}
