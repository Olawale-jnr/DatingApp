import { Observable } from 'rxjs';
import { ConfirmDialogueComponent } from './../modals/confirm-dialogue/confirm-dialogue.component';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfirmService {
  bsModalRef: BsModalRef;

  constructor(private modalService: BsModalService) { }

  confirm(title = 'Confirmation', 
  message = 'Are you sure you want to do this?', 
  btnOkText = 'Ok', 
  btnCancelText = 'Cancel'): Observable<boolean> {
    const config = {
      initialState: {
        title,
        message,
        btnOkText,
        btnCancelText
      }
    }

    this.bsModalRef = this.modalService.show(ConfirmDialogueComponent, config); 
  
    return new Observable<boolean>(this.getResult());
  }

  private getResult() {
    return (observer) => {
      const subscription = this.bsModalRef.onHidden.subscribe(() => {
        observer.next(this.bsModalRef.content.result);
        observer.complete();
      });

      return {
        unsubscribe() {
          subscription.unsubscribe();
        }
      }
    }
  }
}
