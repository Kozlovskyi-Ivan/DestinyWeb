import { Component, OnInit } from '@angular/core';
import { Milestone } from 'src/types/Milestone';
import { Activities } from 'src/types/Activities';
import { DataserviceService } from '../dataservice.service';

@Component({
  selector: 'app-raidSorrow',
  templateUrl: './raidSorrow.component.html',
  styleUrls: ['./raidSorrow.component.css']
})
export class RaidSorrowComponent implements OnInit {

  Milestone?:Milestone;
  Activities?:Activities[];
  constructor(private dataservice:DataserviceService) { }

  ngOnInit() {
    // this.Dataservice.getMilestone('2590427074')
    // .subscribe((data:Milestone)=>this.Milestone=data);
    // this.Dataservice.getActivities('2590427074')
    // .subscribe((data: Activities[])=>this.Activities=data);
    this.getDataOnInit();
  }
  async getDataOnInit() {
    this.Milestone = await this.dataservice.getMilestoneAsync('2590427074');
    this.Activities = await this.dataservice.getActivitiesAsync('2590427074');
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
