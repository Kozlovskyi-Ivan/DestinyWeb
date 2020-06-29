import { Activities } from 'src/types/Activities';
import { DataserviceService } from './../dataservice.service';
// import { Activities } from './../../types/Activities';
import { Milestone } from './../../types/Milestone';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-raidLast',
  templateUrl: './raidLast.component.html',
  styleUrls: ['./raidLast.component.css']
})
export class RaidLastComponent implements OnInit {

  Milestone?: Milestone;
  Activities?: Activities[];
  constructor(private dataservice: DataserviceService) { }

  ngOnInit() {
    // this.Dataservice.getMilestone('3181387331')
    // .subscribe((data: Milestone) => this.Milestone = data);
    // this.Dataservice.getActivities('3181387331')
    // .subscribe((data: Activities[]) => this.Activities = data);
    this.getDataOnInit();
  }
  async getDataOnInit() {
    this.Milestone = await this.dataservice.getMilestoneAsync('3181387331');
    this.Activities = await this.dataservice.getActivitiesAsync('3181387331');
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
