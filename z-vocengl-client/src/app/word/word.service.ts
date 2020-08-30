import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WordService {
  meaningExpanded: boolean;
  collocationsExpanded: boolean;

  constructor() {
    this.meaningExpanded = true;
    this.collocationsExpanded = true;
  }
}
