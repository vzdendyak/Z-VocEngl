import {VocabulariesWords} from './vocabularies-words';
import {WordInformation} from './word-information';

export class Word {
  public id: number;
  public name: string;
  // nav
  public vocabulariesWords: VocabulariesWords[];
  public wordInformations: WordInformation[];
}
