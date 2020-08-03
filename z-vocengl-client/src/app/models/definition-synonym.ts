import {WordInformation} from './word-information';

export class DefinitionSynonym {
  public id: number;
  public text: string;
  public wordInformationId: number;
  // nav
  public wordInformation: WordInformation;
}
