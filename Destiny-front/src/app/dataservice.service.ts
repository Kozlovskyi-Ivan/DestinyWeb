import { Milestone } from './../types/Milestone';
import { Activities } from './../types/Activities';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { throwError } from 'rxjs/internal/observable/throwError';


@Injectable({
  providedIn: 'root'
})
export class DataserviceService {
  name?: string;
  description?: string;
  // private url='http://localhost:52881/api';
  // private url='http://destiny-back:80/api';
  //for dev
  private url = 'https://tranquil-hollows-61671.herokuapp.com/api';
  constructor(private http: HttpClient) { }

  getMilestone(name: string) {
    return this.http.get(this.url + '/' + 'Milestones' + '/' + name).pipe(
      retry(3), // retry a failed request up to 3 times
      catchError(this.handleError) // then handle the error
    );
  }
  getActivities(name: string) {
    return this.http.get<Activities[]>(this.url + '/' + 'Milestones' + '/Nightfall/' + name).pipe(
      retry(3), // retry a failed request up to 3 times
      catchError(this.handleError) // then handle the error
    );
  }
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  };

  async getMilestoneAsync(name: string) {
    return await this.http.get<Milestone>(this.url + '/' + 'Milestones' + '/' + name)
      .toPromise();
  }
  async getActivitiesAsync(name: string) {
    return await this.http.get<Activities[]>(this.url + '/' + 'Milestones' + '/Nightfall/' + name)
      .toPromise();
  }



}
