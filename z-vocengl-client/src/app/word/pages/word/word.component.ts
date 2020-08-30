import {Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {HeaderService} from '../../../header/header.service';
import {Word} from '../../../models/word';
import {WordInformation} from '../../../models/word-information';

@Component({
  selector: 'app-word',
  templateUrl: './word.component.html',
  styleUrls: ['./word.component.scss']
})
export class WordComponent implements OnInit, OnChanges {
  @Input() word: Word;
  collocations: WordInformation[];
  meanings: WordInformation[];

  constructor(public headerService: HeaderService) {
  }

  ngOnInit(): void {
    // setTimeout(r => {
    //     this.meanings[2].definitionsSynonyms =  this.collocations[0].collocationWords;
    //   }, 2000
    // );
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (!this.meanings) {
      this.meanings = this.word?.wordInformations.filter(r => r.typeId == 1);
      console.log('CHANGE MEANINGS: ' + this.meanings);

    }
    if (!this.collocations) {
      this.collocations = this.word?.wordInformations.filter(r => r.typeId == 2);
      console.log('CHANGE COLLOCATIONS: ' + this.collocations);
    }

  }

}
