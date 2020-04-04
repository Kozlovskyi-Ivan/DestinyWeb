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
  constructor(private Dataservice:DataserviceService) { }

  ngOnInit() {
    this.Dataservice.getMilestone('1342567285')
    .subscribe((data:Milestone)=>this.Milestone=data);
    this.Dataservice.getActivities('1342567285')
    .subscribe((data)=>this.Activities=data);
  }

}
