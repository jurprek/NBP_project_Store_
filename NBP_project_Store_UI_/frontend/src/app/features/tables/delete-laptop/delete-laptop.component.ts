import { Component, OnDestroy } from '@angular/core';
import { DeleteInventarComponent } from '../delete-inventar/delete-inventar.component';
import { DeleteInventarRequest } from '../models/delete-inventar-request.model';
import { GetOneLaptopRequest } from '../models/get-one-laptop-request.model';
import { Subscription } from 'rxjs';
import { LaptopService } from '../services/laptop.service';

@Component({
  selector: 'app-delete-laptop',
  templateUrl: './delete-laptop.component.html',
  styleUrl: './delete-laptop.component.css'
})
export class DeleteLaptopComponent implements OnDestroy {

  model: GetOneLaptopRequest;
  private deleteLaptopSubscription?: Subscription;

  constructor(private laptopService: LaptopService) {
    this.model = {
      id_Laptop: ""
    };
  }

  onFormSubmit() {
    this.deleteLaptopSubscription = this.laptopService.deleteLaptop(this.model)
    .subscribe({
      next: (response) => {
        console.log(this.model)
      }
    })
  }

  ngOnDestroy(): void {
    this.deleteLaptopSubscription?.unsubscribe();
  }

}
