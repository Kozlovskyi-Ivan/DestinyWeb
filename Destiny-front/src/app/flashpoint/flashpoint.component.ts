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

  name?: string;
  description?: string;
  Activities?: Activities[];
  image?: string;
  constructor(private dataservice: DataserviceService) { }

  ngOnInit() {
    this.dataservice.getMilestone('463010297')
    .subscribe((data: Milestone) => {this.name = data.name, this.description = data.description;});
    this.chechForImage();
  }
  chechForImage() {
    switch (this.name) {
      case 'FLASHPOINT: NESSUS':
       this.image = '/assets/Image/patrol_nessus.jpg';
       return this.image;
      case 'FLASHPOINT: TANGLED SHORE':
       this.image = '/assets/Image/Tangled_Shore.jpg';
       return this.image;
      case 'FLASHPOINT: EDZ':
       this.image = '/assets/Image/patrol_edz.jpg';
       return this.image;
      case 'FLASHPOINT: TITAN':
       this.image = '/assets/Image/patrol_titan.jpg';
       return this.image;
      case 'FLASHPOINT: IO':
       this.image = '/assets/Image/patrol_Io.jpg';
       return this.image;
      case 'FLASHPOINT: MERCURY':
       this.image = '/assets/Image/freeroam_mercury.jpg';
       return this.image;
      case 'FLASHPOINT: MARS':
       this.image = '/assets/Image/free_roam_polaris.jpg';
       return this.image;
      default:
        this.image = '/assets/Image/help.jpg';
        return this.image;
    }
  }

}
