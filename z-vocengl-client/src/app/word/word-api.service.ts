import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {Word} from '../models/word';

@Injectable({
  providedIn: 'root'
})
export class WordApiService {
  url: string = environment.route + '/api/words';

  constructor(private http: HttpClient) {
  }

  getWord(name: string): Observable<Word> {
    return this.http.get<Word>(this.url + `/name/${name}`, {responseType: 'json'});
  }
}
