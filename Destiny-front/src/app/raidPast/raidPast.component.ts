import { Component, OnInit } from '@angular/core';
import { DataserviceService } from '../dataservice.service';
import { Milestone } from 'src/types/Milestone';
import { Activities } from 'src/types/Activities';

@Component({
  selector: 'app-raidPast',
  templateUrl: './raidPast.component.html',
  styleUrls: ['./raidPast.component.css']
})
export class RaidPastComponent implements OnInit {

  Milestone?:Milestone;
  Activities?:Activities[];
  constructor(private dataservice:DataserviceService) { }

  ngOnInit() {
    // this.Dataservice.getMilestone('1342567285')
    // .subscribe((data:Milestone)=>this.Milestone=data);
    // this.Dataservice.getActivities('1342567285')
    // .subscribe((data:Activities[])=>this.Activities=data);
    this.getDataOnInit();

  }
  async getDataOnInit() {
    this.Milestone = await this.dataservice.getMilestoneAsync('1342567285');
    this.Activities = await this.dataservice.getActivitiesAsync('1342567285');
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
