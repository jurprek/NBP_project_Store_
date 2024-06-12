import { Component, OnDestroy } from '@angular/core';
import { DeleteInventarRequest } from '../models/delete-inventar-request.model';
import { InventarService } from '../services/inventar.service';
import { response } from 'express';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-delete-inventar',
  templateUrl: './delete-inventar.component.html',
  styleUrl: './delete-inventar.component.css'
})
export class DeleteInventarComponent implements OnDestroy {

  model: DeleteInventarRequest;
  private deleteInventarSubscription?: Subscription;

  constructor(private inventarService: InventarService) {
    this.model = {
      id_inventar: ""
    };
  }
  
  onFormSubmit() {
    this.deleteInventarSubscription = this.inventarService.deleteInventar(this.model)
    .subscribe({
      next: (response) => {
        console.log(this.model)
      }
    })
  }

  ngOnDestroy(): void {
    this.deleteInventarSubscription?.unsubscribe();
  }
}
