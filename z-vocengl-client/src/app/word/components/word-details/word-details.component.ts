import {Component, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {WordApiService} from '../../word-api.service';
import {Word} from '../../../models/word';

@Component({
  selector: 'app-word-details',
  templateUrl: './word-details.component.html',
  styleUrls: ['./word-details.component.scss']
})
export class WordDetailsComponent implements OnInit {
  currentWord: Word;

  constructor(private wordApi: WordApiService) {
    console.log('start');
    wordApi.getWord('abandon').subscribe(value => {
      this.currentWord = value;
      this.currentWord.name = this.currentWord.name[0].toUpperCase() + this.currentWord.name.slice(1);
      console.log('got: ', this.currentWord);

    });
  }

  ngOnInit(): void {
  }



}
