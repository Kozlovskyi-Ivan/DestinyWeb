import { Activities } from './../types/Activities';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataserviceService {

  // private url='http://localhost:52881/api';
  private url='http://destiny-back:1444/api';
constructor(private http: HttpClient) { }

getMilestone(name: string){
  return this.http.get(this.url + '/' +'Milestones'+'/' +name)
}
getActivities(name: string){
  return this.http.get<Activities[]>(this.url + '/' +'Milestones'+'/Nightfall/' +name)
}

}
