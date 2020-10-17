import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VocabularyWordsDetailsComponent } from './components/vocabulary-words-details/vocabulary-words-details.component';
import { VocabularyWordsComponent } from './pages/vocabulary-words/vocabulary-words.component';
import {MaterialModule} from '../material/material.module';
import {MatDividerModule} from '@angular/material/divider';



@NgModule({
  declarations: [VocabularyWordsDetailsComponent, VocabularyWordsComponent],
  imports: [
    CommonModule,
    MaterialModule,
    MatDividerModule
  ]
})
export class VocabularyPageModule { }
