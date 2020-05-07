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
  private url='http://localhost:4000/api';
  private alls=['80','1444','778','4000'];
constructor(private http: HttpClient) { }

getMilestone(name: string){
  // for(let i=4;i<this.alls.length;i++){
  //   ('http://destiny-back:'+this.alls[i]+'/'+'api/Milestones/test/1');
  //   (this.http.get('http://destiny-back:'+this.alls[i]+ '/'+'api/Milestones/test' + '/' +'1')
  //   .subscribe((data: Milestone) => {this.name = data.name, this.description = data.description;}));
  //   (this.name,this.description);console.log(this.name,this.description);
  //   (this.http.get('http://localhost:'+this.alls[i]+ '/'+'api/Milestones/test' + '/' +'2')
  //   .subscribe((data: Milestone) => {this.name = data.name, this.description = data.description;}));
  //   (this.name,this.description);console.log(this.name,this.description);
  //   (this.http.get('http://0.0.0.0:'+this.alls[i]+ '/'+'api/Milestones/test' + '/' +'3')
  //   .subscribe((data: Milestone) => {this.name = data.name, this.description = data.description;}));
  //   console.log(this.name,this.description);
  //   //////////////////////////////////
  //   ('destiny-back:'+this.alls[i]+'/'+'api/Milestones/test/1');
  //   (this.http.get('destiny-back:'+this.alls[i]+ '/'+'api/Milestones/test' + '/' +'1')
  //   .subscribe((data: Milestone) => {this.name = data.name, this.description = data.description;}));
  //   console.log(this.name,this.description);
  //   (this.http.get('localhost:'+this.alls[i]+ '/'+'api/Milestones/test' + '/' +'2')
  //   .subscribe((data: Milestone) => {this.name = data.name, this.description = data.description;}));
  //   (this.name,this.description);console.log(this.name,this.description);
  //   (this.http.get('0.0.0.0:'+this.alls[i]+ '/'+'api/Milestones/test' + '/' +'3')
  //   .subscribe((data: Milestone) => {this.name = data.name, this.description = data.description;}));
  //   console.log(this.name,this.description);
  // }
  return this.http.get(this.url + '/' +'Milestones'+'/' +name)
}
getActivities(name: string){
  return this.http.get<Activities[]>(this.url + '/' +'Milestones'+'/Nightfall/' +name)
}

}
