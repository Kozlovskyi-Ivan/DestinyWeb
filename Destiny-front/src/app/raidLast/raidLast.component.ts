import { DataserviceService } from './../dataservice.service';
import { Activities } from './../../types/Activities';
import { Milestone } from './../../types/Milestone';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-raidLast',
  templateUrl: './raidLast.component.html',
  styleUrls: ['./raidLast.component.css']
})
export class RaidLastComponent implements OnInit {

  Milestone?:Milestone;
  Activities?:Activities[];
  constructor(private Dataservice:DataserviceService) { }

  ngOnInit() {
    this.Dataservice.getMilestone('3181387331')
    .subscribe((data:Milestone)=>this.Milestone=data);
    this.Dataservice.getActivities('3181387331')
    .subscribe((data)=>this.Activities=data);
  }

}
