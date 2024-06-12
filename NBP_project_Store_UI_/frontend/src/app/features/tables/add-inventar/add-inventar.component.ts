import { Component, OnDestroy } from '@angular/core';
import { AddInventarRequest } from '../models/add-inventar-request.model';
import { InventarService } from '../services/inventar.service';
import { response } from 'express';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-inventar',
  templateUrl: './add-inventar.component.html',
  styleUrl: './add-inventar.component.css'
})
export class AddInventarComponent implements OnDestroy {

  model: AddInventarRequest;
  private addInventarSubscription?: Subscription;

  constructor(private inventarService: InventarService) {
    this.model = {
      id_inventar: "",
      id_poslovnica: "",
      id_predmet: "",
      cijena: ""
    };
  }

  onFormSubmit() {
    console.log(this.model);
    this.addInventarSubscription = this.inventarService.addInventar(this.model)
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
      }
    })
  }

  ngOnDestroy(): void {
    this.addInventarSubscription?.unsubscribe();
  }
}
