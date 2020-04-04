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
    this.dataservice.getMilestone('2712317338')
    .subscribe(data=>this.Milestone=data);
    this.dataservice.getActivities('2712317338')
    .subscribe(data=>this.Activities=data);
  }

}
