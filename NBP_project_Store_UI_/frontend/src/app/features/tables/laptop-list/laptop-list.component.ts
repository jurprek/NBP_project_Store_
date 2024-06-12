import { Component, OnDestroy } from '@angular/core';
import { GetLaptopRequest } from '../models/get-laptop-request.model';
import { Subscription } from 'rxjs';
import { LaptopService } from '../services/laptop.service';

@Component({
  selector: 'app-laptop-list',
  templateUrl: './laptop-list.component.html',
  styleUrl: './laptop-list.component.css'
})
export class LaptopListComponent implements OnDestroy {

  laptopColumns: string[] = ['id_Laptop', 'model', 'processor', 'ram', 'screen', 'storage', 'graphics', 'os', 'weightKg', 'warrantyMonths'];
  laptop: GetLaptopRequest[] = [];

  model: GetLaptopRequest;
  private getLaptopSubscription?: Subscription;

  constructor(private laptopServices: LaptopService) {
    this.model = {
      id_Laptop: "",
      model: "",
      processor: {
        type: "",
        cores: 0,
        maxSpeedGHz: 0
      },
      ram: {
        sizeGB: 0,
        type: "string"
      },
      screen: {
        sizeInches: 0,
        resolution: "",
        type: ""
      },
      storage: {
        sizeGB: 0,
        type: ""
      },
      os: "",
      graphics: {
        type: ""
      },
      network: {
        wifi: "",
        ethernet: "",
        bluetooth: true
      },
      ports: {
        usB2_0: 0,
        usB3_1: 0,
        hdmi: true,
        usbTypeC: true
      },
      weightKg: 1.7,
      color: "",
      warrantyMonths: 0,
      additionalFeatures: ["", ""]
    };
  }

  ngOnInit() {
    this.getLaptopSubscription = this.laptopServices.getAllLaptops()
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
        this.laptop = response;
      }
    })
  }

  ngOnDestroy(): void {
    this.getLaptopSubscription?.unsubscribe();
  }

}
