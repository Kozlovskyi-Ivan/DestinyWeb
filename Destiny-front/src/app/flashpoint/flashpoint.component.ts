import { Activities } from './../../types/Activities';
import { DataserviceService } from './../dataservice.service';
import { Milestone } from './../../types/Milestone';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-flashpoint',
  templateUrl: './flashpoint.component.html',
  styleUrls: ['./flashpoint.component.css'],
  providers: [DataserviceService]
})
export class FlashpointComponent implements OnInit {

  Milestone?: Milestone = new Milestone();
  // name?: string;
  // description?: string;
  // Activities?: Activities[];
  // image?: string;
  constructor(private dataservice: DataserviceService) { }

  ngOnInit() {
    // this.dataservice.getMilestone('463010297')
    // .subscribe((data: Milestone) => {this.name = data.name, this.description = data.description;});
    // let callback= await this.dataservice.getMilestoneAsync('463010297');
    // this.name=callback.name;
    // this.description=callback.description;
    // this.image=callback.imageUrl;
    // this.chechForImage();
    this.getDataOnInit();
  }
  async getDataOnInit() {
    let callback = await this.dataservice.getMilestoneAsync('463010297');
    this.Milestone = callback;
    // this.name = callback.name;
    // this.description = callback.description;
    // this.image = callback.imageUrl;
    this.chechForImage();
  }
  chechForImage() {
    if (!(this.Milestone === undefined)) {
      switch (this.Milestone.name) {
        case 'FLASHPOINT: NESSUS':
          this.Milestone.imageUrl = '/assets/Image/patrol_nessus.jpg';
          return this.Milestone.imageUrl;
        case 'FLASHPOINT: TANGLED SHORE':
          this.Milestone.imageUrl = '/assets/Image/Tangled_Shore.jpg';
          return this.Milestone.imageUrl;
        case 'FLASHPOINT: EDZ':
          this.Milestone.imageUrl = '/assets/Image/patrol_edz.jpg';
          return this.Milestone.imageUrl;
        case 'FLASHPOINT: TITAN':
          this.Milestone.imageUrl = '/assets/Image/patrol_titan.jpg';
          return this.Milestone.imageUrl;
        case 'FLASHPOINT: IO':
          this.Milestone.imageUrl = '/assets/Image/patrol_Io.jpg';
          return this.Milestone.imageUrl;
        case 'FLASHPOINT: MERCURY':
          this.Milestone.imageUrl = '/assets/Image/freeroam_mercury.jpg';
          return this.Milestone.imageUrl;
        case 'FLASHPOINT: MARS':
          this.Milestone.imageUrl = '/assets/Image/free_roam_polaris.jpg';
          return this.Milestone.imageUrl;
        default:
          this.Milestone.imageUrl = '/assets/Image/help.jpg';
          return this.Milestone.imageUrl;
      }
    } else {

    }
  }



}
