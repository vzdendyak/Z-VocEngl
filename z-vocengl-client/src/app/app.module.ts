import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HeaderComponent} from './header/header.component';
import {WordPageModule} from './word/word-page.module';
import {RouterModule} from '@angular/router';
import {WordDetailsComponent} from './word/components/word-details/word-details.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {VocabularyPageModule} from './vocabulary/vocabulary-page.module';
import {VocabularyWordsDetailsComponent} from './vocabulary/components/vocabulary-words-details/vocabulary-words-details.component';
import {MaterialModule} from './material/material.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    WordPageModule,
    VocabularyPageModule,
    HttpClientModule,
    RouterModule.forRoot([
      // {path: '',  redirectTo: 'word/0', pathMatch: 'full'},
      {path: 'word/:name', component: WordDetailsComponent},
      {path: 'vocabulary/:id', component: VocabularyWordsDetailsComponent}
    ]),
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
