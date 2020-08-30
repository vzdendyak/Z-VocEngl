import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HeaderComponent} from './header/header.component';
import {WordPageModule} from './word/word-page.module';
import {RouterModule} from '@angular/router';
import {WordDetailsComponent} from './word/components/word-details/word-details.component';
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    WordPageModule,
    HttpClientModule,
    RouterModule.forRoot([
      // {path: '',  redirectTo: 'word/0', pathMatch: 'full'},
      {path: 'word/:wordId', component: WordDetailsComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
