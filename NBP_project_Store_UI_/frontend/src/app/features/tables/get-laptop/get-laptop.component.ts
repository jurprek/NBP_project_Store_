import { Component, OnDestroy } from '@angular/core';
import { GetLaptopRequest } from '../models/get-laptop-request.model';
import { Subscription } from 'rxjs';
import { GetOneLaptopRequest } from '../models/get-one-laptop-request.model';
import { LaptopService } from '../services/laptop.service';

@Component({
  selector: 'app-get-laptop',
  templateUrl: './get-laptop.component.html',
  styleUrl: './get-laptop.component.css'
})
export class GetLaptopComponent implements OnDestroy{

  laptopColumns: string[] = ['id_Laptop', 'model', 'processor', 'ram', 'screen', 'storage', 'graphics', 'os', 'weightKg', 'warrantyMonths'];
  laptop: GetLaptopRequest[] = [];

  model: GetOneLaptopRequest;
  private getLaptopSubscription?: Subscription;

  constructor(private laptopServices: LaptopService) {
    this.model = {
      id_Laptop: "",
    };
  }

  onFormSubmit() {
    console.log(this.model)
    this.getLaptopSubscription = this.laptopServices.getLaptop(this.model)
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
