import { Component, OnDestroy } from '@angular/core';
import { GetLaptopRequest } from '../models/get-laptop-request.model';
import { Subscription } from 'rxjs';
import { LaptopService } from '../services/laptop.service';

@Component({
  selector: 'app-add-laptop',
  templateUrl: './add-laptop.component.html',
  styleUrl: './add-laptop.component.css'
})
export class AddLaptopComponent implements OnDestroy{

  model: GetLaptopRequest;
  private addLaptopSubscription?: Subscription;

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
      additionalFeatures: ["Andrija", "Tena"]
    };
  }

  onFormSubmit() {
    console.log(this.model);
    this.addLaptopSubscription = this.laptopServices.addLaptop(this.model)
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
      }
    })
  }

  ngOnDestroy(): void {
    this.addLaptopSubscription?.unsubscribe();
  }

}
