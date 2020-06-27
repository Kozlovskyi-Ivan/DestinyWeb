import { Milestone } from './../../types/Milestone';
import { Activities } from './../../types/Activities';
import { DataserviceService } from './../dataservice.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-nightfall',
  templateUrl: './nightfall.component.html',
  styleUrls: ['./nightfall.component.css']
})
export class NightfallComponent implements OnInit {

  Activities?: Activities[];
  Milestone?: Milestone=new Milestone();
  constructor(private dataservice: DataserviceService) { }

  ngOnInit() {
    // this.dataservice.getActivities('1942283261')
    //   .subscribe((data: Activities[]) => { this.Activities = data });
    // this.dataservice.getMilestone('1942283261')
    //   .subscribe((data: Milestone) => this.Milestone = data);
    this.getDataOnInit();
  }
  async getDataOnInit(){
    this.Activities=await this.dataservice.getActivitiesAsync('1942283261');
    this.Milestone=await this.dataservice.getMilestoneAsync('1942283261');
  }

  chechForImage() {
    if (this.Milestone.imageUrl === undefined) {
      return '/assets/Image/help.jpg';
      // return 'https://www.bungie.net/'+this.Milestone.imageUrl;
    } else {
      // return '/assets/Image/help.jpg';
      return 'https://www.bungie.net/' + this.Milestone.imageUrl;

    }
  }
  getIcon(){
    if(this.Activities===undefined){
      // this.getIcon();
    }else{
      return this.Activities[0].icon;
    }
  }
  getDescription(){
    if(this.Activities===undefined){
      // this.getIcon();
    }else{
      return this.Activities[0].description;
    }
  }
}
