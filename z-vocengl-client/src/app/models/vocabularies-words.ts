import {Word} from './word';
import {Vocabulary} from './vocabulary';

export class VocabulariesWords {
  public id: number;
  public wordId: number;
  public vocabularyId: number;
  // nav
  public word: Word;
  public vocabulary: Vocabulary;
}
