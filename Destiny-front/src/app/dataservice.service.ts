import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataserviceService {

  private url='http://localhost:52881/api';
constructor(private http: HttpClient) { }

getMilestone(name: string){
  return this.http.get(this.url + '/' +'Milestones'+'/' +name)
}

}
