import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Playlists } from './playlists';
const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};
const apiUrl = '/api/v1/products';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
private handleError<T> (operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {
    // TODO: send the error to remote logging infrastructure
    console.error(error); // log to sonsole instead
    //Let the app keep running by returning an empty result.
    return of(result as T);
  }
}
  constructor(private http: HttpClient) { }

  getPlaylists (): Observable<Playlists[]> {
    return this.http.get<Playlists[]>(apiUrl)
    .pipe(
      tap(heroes => console.log('fetched playlists')),
      catchError(this.handleError('getPlaylist', []))
    );
  }
}
