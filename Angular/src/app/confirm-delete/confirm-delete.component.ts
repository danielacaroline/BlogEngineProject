import { Component } from '@angular/core';
import { Subject } from 'rxjs';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-confirm-delete',
  templateUrl: './confirm-delete.component.html',
  styleUrls: ['./confirm-delete.component.scss']
})
export class ConfirmDeleteComponent {
  public onClose!: Subject<boolean>;

  constructor(public modal: NgbActiveModal) { }

  public ngOnInit(): void {
      this.onClose = new Subject();
  }

  public onConfirm(): void {
      this.onClose.next(true);
      
      this.modal.close("Ok");
  }

  public onCancel(): void {
      this.onClose.next(false);
      this.modal.close()
  }
}
