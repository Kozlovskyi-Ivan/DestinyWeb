import { Activities } from './../types/Activities';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Milestone } from 'src/types/Milestone';

@Injectable({
  providedIn: 'root'
})
export class DataserviceService {
  name?: string;
  description?: string;
  // private url='http://localhost:52881/api';
  // private url='http://destiny-back:80/api';
  //for dev
  private url='https://tranquil-hollows-61671.herokuapp.com/api';
constructor(private http: HttpClient) { }

getMilestone(name: string){

  return this.http.get(this.url + '/' +'Milestones'+'/' +name)
}
getActivities(name: string){
  return this.http.get<Activities[]>(this.url + '/' +'Milestones'+'/Nightfall/' +name)
}

}
