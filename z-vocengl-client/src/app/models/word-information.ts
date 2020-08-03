import {Example} from './example';
import {Type} from './type';
import {Word} from './word';
import {PartOfSpeech} from './part-of-speech';
import {DefinitionSynonym} from './definition-synonym';
import {CollocationWord} from './collocation-word';

export class WordInformation {
  public id: number;
  public text: string;
  public wordId: number;
  public partOfSpeechId: number;
  public typeId: number;
  // nav
  public examples: Example[];
  public definitionsSynonyms: DefinitionSynonym[];
  public collocationWords: CollocationWord[];
  public type: Type;
  public word: Word;
  public partOfSpeech: PartOfSpeech;
}
