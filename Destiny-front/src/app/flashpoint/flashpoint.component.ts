import { DataserviceService } from './../dataservice.service';
import { Milestone } from './../../types/Milestone';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-flashpoint',
  templateUrl: './flashpoint.component.html',
  styleUrls: ['./flashpoint.component.css'],
  providers:[DataserviceService]
})
export class FlashpointComponent implements OnInit {

  name?: string;
  description?: string;
  constructor(private dataservice: DataserviceService) { }

  ngOnInit() {
    this.dataservice.getMilestone('463010297')
    .subscribe((data: Milestone)=>{this.name=data.name,this.description=data.description});
  }

}
