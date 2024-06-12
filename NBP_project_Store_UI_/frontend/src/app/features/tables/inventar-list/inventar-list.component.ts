import { Component, OnDestroy } from '@angular/core';
import { GetInventarRequest } from '../models/get-inventar-request.model';
import { InventarService } from '../services/inventar.service';
import { response } from 'express';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-inventar-list',
  templateUrl: './inventar-list.component.html',
  styleUrl: './inventar-list.component.css'
})
export class InventarListComponent implements OnDestroy {

  inventarColumns: string[] = ['cijena_Eur', 'id_Inventar', 'id_Poslovnica', 'id_Predmet', 'id'];
  inventar: GetInventarRequest[] = [];

  model: GetInventarRequest;
  private getInventarSubscription?: Subscription;

  constructor(private inventarService: InventarService) {
    this.model = {
      cijena_Eur: "",
      id_Inventar: "",
      id_Poslovnica: "", 
      id_Predmet: "",
      id: ""
    };
    
  }

  ngOnInit() {
    this.getInventarSubscription = this.inventarService.getAllInventar()
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
        this.inventar = response;
      }
    })
  }

  ngOnDestroy(): void {
    this.getInventarSubscription?.unsubscribe();

  }
}
