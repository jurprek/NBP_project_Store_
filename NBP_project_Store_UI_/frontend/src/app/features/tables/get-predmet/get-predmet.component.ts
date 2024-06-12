import { Component, OnDestroy } from '@angular/core';
import { GetKeywordPredmetRequest } from '../models/get-keyword-predmet.model';
import { PredmetService } from '../services/predmet.service';
import { response } from 'express';
import { Subscription } from 'rxjs';
import { GetPredmetRequest } from '../models/get-predmet-request.model';

@Component({
  selector: 'app-get-predmet',
  templateUrl: './get-predmet.component.html',
  styleUrl: './get-predmet.component.css'
})
export class GetPredmetComponent implements OnDestroy {

  predmetColumns: string[] = ['id_Predmet', 'naziv_Predmet', 'id'];
  predmet: GetPredmetRequest[] = [];

  model: GetKeywordPredmetRequest;
  private getPredmetSubscription?: Subscription;

  constructor(private predmetService: PredmetService) {
    this.model = {
      searchId: "",
      searchOpis: ""
    };
    
  }

  onFormSubmit() {
    this.getPredmetSubscription = this.predmetService.getPredmet(this.model)
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
