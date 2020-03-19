import { Activities } from './../../types/Activities';
import { DataserviceService } from './../dataservice.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nightfall',
  templateUrl: './nightfall.component.html',
  styleUrls: ['./nightfall.component.css']
})
export class NightfallComponent implements OnInit {

  Activities?:Activities[]=[];
  constructor(private dataservice:DataserviceService ) { }

  ngOnInit() {
    this.dataservice.getActivities('1942283261')
    .subscribe((data: Activities[])=>{this.Activities=data});
  }

}
