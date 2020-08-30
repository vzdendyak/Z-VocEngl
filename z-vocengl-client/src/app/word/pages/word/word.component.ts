import { Component, OnInit } from '@angular/core';
import {HeaderService} from '../../../header/header.service';

@Component({
  selector: 'app-word',
  templateUrl: './word.component.html',
  styleUrls: ['./word.component.scss']
})
export class WordComponent implements OnInit {


  constructor(public headerService: HeaderService) { }

  ngOnInit(): void {
  }

}
