import { Component, OnDestroy } from '@angular/core';
import { DeleteKupnjaRequest } from '../models/delete-kupnja-request.model';
import { Subscription } from 'rxjs';
import { KupnjaService } from '../services/kupnja.service';

@Component({
  selector: 'app-delete-kupnja',
  templateUrl: './delete-kupnja.component.html',
  styleUrl: './delete-kupnja.component.css'
})
export class DeleteKupnjaComponent implements OnDestroy {

  model: DeleteKupnjaRequest;
  private deleteKupnjaSubscription?: Subscription;

  constructor(private kupacService: KupnjaService) {
    this.model = {
      id_Kupnja: ""
    };
  }

  onFormSubmit() {
    this.deleteKupnjaSubscription = this.kupacService.deleteKupnja(this.model)
    .subscribe({
      next: (response) => {
        console.log(this.model)
      }
    })
  }

  ngOnDestroy(): void {
    this.deleteKupnjaSubscription?.unsubscribe();
  }
}
