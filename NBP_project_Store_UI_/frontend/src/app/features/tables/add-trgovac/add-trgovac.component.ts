import { Component, OnDestroy } from '@angular/core';
import { AddTrgovacRequest } from '../models/add-trgovac-request.model';
import { TrgovacService } from '../services/trgovac.service';
import { response } from 'express';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-trgovac',
  templateUrl: './add-trgovac.component.html',
  styleUrl: './add-trgovac.component.css'
})
export class AddTrgovacComponent implements OnDestroy {

  model: AddTrgovacRequest;
  private addTrgovacSubscription?: Subscription;

  constructor(private trgovacService: TrgovacService) {
    this.model = {
      id_Trgovac: "",
      ime_Trgovac: "",
      prezime_Trgovac: ""
    };
  }

  onFormSubmit() {
    console.log(this.model);
    this.addTrgovacSubscription = this.trgovacService.addTrgovac(this.model)
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
      }
    })
  }

  ngOnDestroy(): void {
    this.addTrgovacSubscription?.unsubscribe();
  }
}
