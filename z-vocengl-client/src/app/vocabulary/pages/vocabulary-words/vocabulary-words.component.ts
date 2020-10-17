import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vocabulary-words',
  templateUrl: './vocabulary-words.component.html',
  styleUrls: ['./vocabulary-words.component.scss']
})
export class VocabularyWordsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    console.log('voc-page');
  }

}
