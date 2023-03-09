import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.css']
})
export class ConfirmationDialogComponent {
  @Input() title: string | undefined;
  @Input() message: string | undefined;
  @Input() confirmButtonText = 'Confirm';
  @Input() cancelButtonText = 'Cancel';
  @Output() confirm = new EventEmitter();

  constructor() { }

  onConfirm(): void {
    this.confirm.emit();
  }
}
