import { Component, OnInit } from '@angular/core';
import {logger} from 'codelyzer/util/logger';

@Component({
  selector: 'app-vocabulary-words-details',
  templateUrl: './vocabulary-words-details.component.html',
  styleUrls: ['./vocabulary-words-details.component.scss']
})
export class VocabularyWordsDetailsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    console.log('voc-details');
  }

}
