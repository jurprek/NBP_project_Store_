import { Component, OnDestroy } from '@angular/core';
import { DeleteKupacRequest } from '../models/delete-kupac-request.model';
import { Subscription } from 'rxjs';
import { KupacService } from '../services/kupac.service';

@Component({
  selector: 'app-delete-kupac',
  templateUrl: './delete-kupac.component.html',
  styleUrl: './delete-kupac.component.css'
})
export class DeleteKupacComponent implements OnDestroy {

  model: DeleteKupacRequest;
  private deleteKupacSubscription?: Subscription;

  constructor(private kupacService: KupacService) {
    this.model = {
      id_Kupac: ""
    };
  }

  onFormSubmit() {
    this.deleteKupacSubscription = this.kupacService.deleteKupac(this.model)
    .subscribe({
      next: (response) => {
        console.log(this.model)
      }
    })
  }

  ngOnDestroy(): void {
    this.deleteKupacSubscription?.unsubscribe();
  }
}
