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
  constructor(private Dataservice:DataserviceService) { }

  ngOnInit() {
    this.Dataservice.getMilestone('2590427074')
    .subscribe((data:Milestone)=>this.Milestone=data);
    this.Dataservice.getActivities('2590427074')
    .subscribe((data)=>this.Activities=data);
  }

}
