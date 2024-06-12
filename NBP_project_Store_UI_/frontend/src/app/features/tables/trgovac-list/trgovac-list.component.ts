import { Component, OnDestroy } from '@angular/core';
import { GetTrgovacRequest } from '../models/get-trgovac-request.model';
import { TrgovacService } from '../services/trgovac.service';
import { response } from 'express';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-trgovac-list',
  templateUrl: './trgovac-list.component.html',
  styleUrl: './trgovac-list.component.css'
})
export class TrgovacListComponent implements OnDestroy {

  trgovacColumns: string[] = ['id_Trgovac', 'ime_Trgovac', 'prezime_Trgovac', 'id'];
  trgovac: GetTrgovacRequest[] = [];

  model: GetTrgovacRequest;
  private getTrgovacSubscription?: Subscription;

  constructor(private trgovacService: TrgovacService) {
    this.model = {
      id_Trgovac: "",
      ime_Trgovac: "",
      prezime_Trgovac: "",
      id: ""
    };
    
  }

  ngOnInit() {
    this.getTrgovacSubscription = this.trgovacService.getAllTrgovac()
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
