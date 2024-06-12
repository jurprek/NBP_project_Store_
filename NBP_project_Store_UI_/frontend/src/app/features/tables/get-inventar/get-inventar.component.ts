import { Component, OnDestroy } from '@angular/core';
import { GetKeywordInventarRequest } from '../models/get-keyword-inventar.model';
import { InventarService } from '../services/inventar.service';
import { response } from 'express';
import { Subscription } from 'rxjs';
import { GetInventarRequest } from '../models/get-inventar-request.model';

@Component({
  selector: 'app-get-inventar',
  templateUrl: './get-inventar.component.html',
  styleUrl: './get-inventar.component.css'
})
export class GetInventarComponent implements OnDestroy {

  inventarColumns: string[] = ['cijena_Eur', 'id_Inventar', 'id_Poslovnica', 'id_Predmet', 'id'];
  inventar: GetInventarRequest[] = [];

  model: GetKeywordInventarRequest;
  private getInventarSubscription?: Subscription;

  constructor(private inventarService: InventarService) {
    this.model = {
      predmetKeyword: "",
      poslovnicaKeyword: ""
    };
    
  }

  onFormSubmit() {
    this.inventar = [];
    this.getInventarSubscription = this.inventarService.getInventar(this.model)
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
        this.inventar = response;
      },
      error: (response) => {
        this.inventar = [];
      }
    })
  }

  ngOnDestroy(): void {
    this.getInventarSubscription?.unsubscribe();

  }
}
