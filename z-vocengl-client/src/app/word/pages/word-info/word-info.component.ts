import {Component, OnInit} from '@angular/core';
import {WordService} from '../../word.service';

@Component({
  selector: 'app-word-info',
  templateUrl: './word-info.component.html',
  styleUrls: ['./word-info.component.scss']
})
export class WordInfoComponent implements OnInit {

  constructor(public wordService: WordService) {
  }

  ngOnInit(): void {
  }

  meaningsClick(): void {
    this.wordService.meaningExpanded = !this.wordService.meaningExpanded;
  }

  collocationsClick(): void {
    this.wordService.collocationsExpanded = !this.wordService.collocationsExpanded;
  }
}
