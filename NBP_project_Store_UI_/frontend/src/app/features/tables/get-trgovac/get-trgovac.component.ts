import { Component, OnDestroy } from '@angular/core';
import { GetKeywordTrgovacRequest } from '../models/get-keyword-trgovac.model';
import { TrgovacService } from '../services/trgovac.service';
import { response } from 'express';
import { Subscription } from 'rxjs';
import { GetTrgovacRequest } from '../models/get-trgovac-request.model';

@Component({
  selector: 'app-get-trgovac',
  templateUrl: './get-trgovac.component.html',
  styleUrl: './get-trgovac.component.css'
})
export class GetTrgovacComponent implements OnDestroy {

  trgovacColumns: string[] = ['id_Trgovac', 'ime_Trgovac', 'prezime_Trgovac', 'id'];
  trgovac: GetTrgovacRequest[] = [];

  model: GetKeywordTrgovacRequest;
  private getTrgovacSubscription?: Subscription;

  constructor(private trgovacService: TrgovacService) {
    this.model = {
      searchId: "",
      searchIme: "",
      searchPrezime: ""
    };
    
  }

  onFormSubmit() {
    this.getTrgovacSubscription = this.trgovacService.getTrgovac(this.model)
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
        this.trgovac = response;
      }
    })
  }

  ngOnDestroy(): void {
    this.getTrgovacSubscription?.unsubscribe();

  }
}
