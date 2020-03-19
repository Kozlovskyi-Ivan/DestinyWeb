import { DataserviceService } from './../dataservice.service';
import { Activities } from './../../types/Activities';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-crucible',
  templateUrl: './crucible.component.html',
  styleUrls: ['./crucible.component.css']
})
export class CrucibleComponent implements OnInit {

  Activities?:Activities[];
  ActivitiesMain?:Activities[];
  constructor(private dataservice:DataserviceService) { }

  ngOnInit() {
    this.dataservice.getActivities('4191379729')
    .subscribe(data=>this.Activities=data);
    this.dataservice.getActivities('2434762343')
    .subscribe(data=>this.ActivitiesMain=data);
  }

}
