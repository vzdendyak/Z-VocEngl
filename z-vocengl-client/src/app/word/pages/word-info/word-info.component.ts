import {Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {WordService} from '../../word.service';
import {WordInformation} from '../../../models/word-information';

@Component({
  selector: 'app-word-info',
  templateUrl: './word-info.component.html',
  styleUrls: ['./word-info.component.scss']
})
export class WordInfoComponent implements OnInit {
  @Input() meanings: WordInformation[];
  @Input() collocations: WordInformation[];

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
