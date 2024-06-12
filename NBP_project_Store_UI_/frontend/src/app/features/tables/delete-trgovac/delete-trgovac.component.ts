import { Component, OnDestroy } from '@angular/core';
import { DeleteTrgovacRequest } from '../models/delete-trgovac-request.model';
import { TrgovacService } from '../services/trgovac.service';
import { response } from 'express';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-delete-trgovac',
  templateUrl: './delete-trgovac.component.html',
  styleUrl: './delete-trgovac.component.css'
})
export class DeleteTrgovacComponent implements OnDestroy {

  model: DeleteTrgovacRequest;
  private deleteTrgovacSubscription?: Subscription;

  constructor(private trgovacService: TrgovacService) {
    this.model = {
      id_Trgovac: ""
    };
  }
  
  onFormSubmit() {
    this.deleteTrgovacSubscription = this.trgovacService.deleteTrgovac(this.model)
    .subscribe({
      next: (response) => {
        console.log(this.model)
      }
    })
  }

  ngOnDestroy(): void {
    this.deleteTrgovacSubscription?.unsubscribe();
  }
}
