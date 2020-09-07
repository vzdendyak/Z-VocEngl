import {Component, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {WordApiService} from '../../word-api.service';
import {Word} from '../../../models/word';
import {ActivatedRoute, Route} from '@angular/router';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-word-details',
  templateUrl: './word-details.component.html',
  styleUrls: ['./word-details.component.scss']
})
export class WordDetailsComponent implements OnInit {
  currentWord: Word;
  currentWordName: string;
  subscription: Subscription;

  constructor(private wordApi: WordApiService, private route: ActivatedRoute) {
    this.subscription = route.params.subscribe(value => {
      this.currentWordName = value.name;
      console.log('component: ' + this.currentWordName);

      wordApi.getWord(this.currentWordName).subscribe(value => {
        if (value) {
          this.currentWord = value;
          this.currentWord.name = this.currentWord.name[0].toUpperCase() + this.currentWord.name.slice(1);
          console.log('got: ', this.currentWord);
        } else {
          const tempWord: Word = {name: 'Not found', wordInformations: null, id: null, vocabulariesWords: null};
          this.currentWord = tempWord;
        }


      });
    });
  }

  ngOnInit(): void {
  }


}
