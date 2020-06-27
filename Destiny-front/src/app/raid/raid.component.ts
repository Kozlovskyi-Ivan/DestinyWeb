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

  Milestone:Milestone=new Milestone();
  RaidLeviathan:Activities[];
  RaidLeviathanEater:Activities[];
  RaidLeviathanSpire:Activities[];
  constructor(private dataservice:DataserviceService) { }

  ngOnInit() {
    // this.dataservice.getMilestone('3660836525')
    // .subscribe((data:Milestone)=>this.Milestone=data);
    // this.dataservice.getActivities('3660836525')
    // .subscribe((data:Activities[])=>this.RaidLeviathan=data);
    // this.dataservice.getActivities('2986584050')
    // .subscribe((data:Activities[])=>this.RaidLeviathanEater=data);
    // this.dataservice.getActivities('2683538554')
    // .subscribe((data:Activities[])=>this.RaidLeviathanSpire=data);
    this.getDataOnInit();
  }

  async getDataOnInit(){
    this.Milestone=await this.dataservice.getMilestoneAsync('3660836525');
    this.RaidLeviathan=await this.dataservice.getActivitiesAsync('3660836525');
    this.RaidLeviathanEater=await this.dataservice.getActivitiesAsync('2986584050');
    this.RaidLeviathanSpire=await this.dataservice.getActivitiesAsync('2683538554');
  }
  getIcon(){
    if(this.RaidLeviathan===undefined){
    }else{
      return this.RaidLeviathan[0].icon;
    }
  }
  getBackImage(){
    if(this.Milestone===undefined){
      return '/assets/Image/help.jpg';
    }else{
      return this.Milestone.imageUrl;
    }
  }

}
