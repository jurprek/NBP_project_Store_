import { Component, OnDestroy } from '@angular/core';
import { GetPredmetRequest } from '../models/get-predmet-request.model';
import { PredmetService } from '../services/predmet.service';
import { response } from 'express';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-predmet-list',
  templateUrl: './predmet-list.component.html',
  styleUrl: './predmet-list.component.css'
})
export class PredmetListComponent implements OnDestroy {

  predmetColumns: string[] = ['id_Predmet', 'naziv_Predmet', 'id'];
  predmet: GetPredmetRequest[] = [];

  model: GetPredmetRequest;
  private getPredmetSubscription?: Subscription;

  constructor(private predmetService: PredmetService) {
    this.model = {
      id_Predmet: "",
      naziv_Predmet: "",
      id: ""
    };
    
  }

  ngOnInit() {
    this.getPredmetSubscription = this.predmetService.getAllPredmet()
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
        this.predmet = response;
      }
    })
  }

  ngOnDestroy(): void {
    this.getPredmetSubscription?.unsubscribe();

  }
}
