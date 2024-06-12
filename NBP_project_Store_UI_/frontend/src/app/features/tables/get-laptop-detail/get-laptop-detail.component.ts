import { Component, OnDestroy } from '@angular/core';
import { GetLaptopRequest } from '../models/get-laptop-request.model';
import { GetLaptopDetailsRequest } from '../models/get-laptop-details-request.model';
import { Subscription } from 'rxjs';
import { LaptopService } from '../services/laptop.service';

@Component({
  selector: 'app-get-laptop-detail',
  templateUrl: './get-laptop-detail.component.html',
  styleUrl: './get-laptop-detail.component.css'
})
export class GetLaptopDetailComponent implements OnDestroy {

  laptopColumns: string[] = ['id_Laptop', 'model', 'processor', 'ram', 'screen', 'storage', 'graphics', 'os', 'weightKg', 'warrantyMonths'];
  laptop: GetLaptopRequest[] = [];

  model: GetLaptopDetailsRequest;
  private getLaptopSubscription?: Subscription;

  constructor(private laptopServices: LaptopService) {
    this.model = {
      keyword: "",
    };
  }

  onFormSubmit() {
    console.log(this.model)
    this.getLaptopSubscription = this.laptopServices.getLaptopDetails(this.model)
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
        if (Array.isArray(response)) {
          this.laptop = (response);
        }
        else {
          this.laptop = Array(response);
        }
        
      }
    })
  }

  ngOnDestroy(): void {
    this.getLaptopSubscription?.unsubscribe();
  }

}
