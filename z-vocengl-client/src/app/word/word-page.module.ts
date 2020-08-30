import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {WordDetailsComponent} from './components/word-details/word-details.component';
import {WordComponent} from './pages/word/word.component';
import {WordInfoComponent} from './pages/word-info/word-info.component';
import {WordService} from './word.service';


@NgModule({
  declarations: [
    WordDetailsComponent,
    WordComponent,
    WordInfoComponent],
  imports: [
    CommonModule
  ],
  providers: [WordService]
})
export class WordPageModule {
}
