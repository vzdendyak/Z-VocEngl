import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { WordDetailComponent } from './word/components/word-detail/word-detail.component';
import { WordInfoDetailsComponent } from './word/components/word-info-details/word-info-details.component';
import { WordDetailsComponent } from './word/components/word-details/word-details.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    WordDetailComponent,
    WordInfoDetailsComponent,
    WordDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
