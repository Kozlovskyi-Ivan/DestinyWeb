import { Milestone } from './../../types/Milestone';
import { DataserviceService } from './../dataservice.service';
import { Activities } from './../../types/Activities';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-raid',
  templateUrl: './raid.component.html',
  styleUrls: ['./raid.component.css']
})
export class RaidComponent implements OnInit {

  Milestone:Milestone;
  RaidLeviathan:Activities[];
  RaidLeviathanEater:Activities[];
  RaidLeviathanSpire:Activities[];
  constructor(private dataservice:DataserviceService) { }

  ngOnInit() {
    this.dataservice.getMilestone('3660836525')
    .subscribe((data:Milestone)=>this.Milestone=data);
    this.dataservice.getActivities('3660836525')
    .subscribe((data:Activities[])=>this.RaidLeviathan=data);
    this.dataservice.getActivities('2986584050')
    .subscribe((data:Activities[])=>this.RaidLeviathanEater=data);
    this.dataservice.getActivities('2683538554')
    .subscribe((data:Activities[])=>this.RaidLeviathanSpire=data);
  }

}
