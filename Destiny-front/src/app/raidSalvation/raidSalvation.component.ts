import { Activities } from './../../types/Activities';
import { Milestone } from './../../types/Milestone';
import { DataserviceService } from './../dataservice.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-raidSalvation',
  templateUrl: './raidSalvation.component.html',
  styleUrls: ['./raidSalvation.component.css']
})
export class RaidSalvationComponent implements OnInit {

  constructor(private dataservice:DataserviceService) { }

  Milestone?:Milestone;
  Activities?:Activities[];
  ngOnInit() {
    // this.dataservice.getMilestone('2712317338')
    // .subscribe((data:Milestone)=>this.Milestone=data);
    // this.dataservice.getActivities('2712317338')
    // .subscribe((data:Activities[])=>this.Activities=data);
    this.getDataOnInit();

  }
  async getDataOnInit() {
    this.Milestone = await this.dataservice.getMilestoneAsync('2712317338');
    this.Activities = await this.dataservice.getActivitiesAsync('2712317338');
  }
  getIcon() {
    if (this.Activities === undefined) {
    } else {
      return this.Activities[0].icon;
    }
  }
  getBackImage() {
    if (this.Milestone === undefined) {
      return '/assets/Image/help.jpg';
    } else {
      return this.Milestone.imageUrl;
    }
  }
}
