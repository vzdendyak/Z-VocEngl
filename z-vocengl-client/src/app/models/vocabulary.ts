import {User} from './user';
import {VocabulariesWords} from './vocabularies-words';

export class Vocabulary {
  public id: number;
  public name: string;
  public userId: string;
  // nav
  public user: User;
  public vocabulariesWords: VocabulariesWords[];
}
