import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './kienhang-modal.component.html',
  styleUrls: ['./kienhang-modal.component.css']
})
export class KienhangModalComponent implements OnInit {
  public visible = false;
  public visibleAnimate = false;
  constructor() { }
  ngOnInit() {
  }
  public show(): void {
    this.visible = true;
    setTimeout(() => this.visibleAnimate = true, 100);
  }
  public hide(): void {
    this.visibleAnimate = false;
    setTimeout(() => this.visible = false, 300);
  }
  public onContainerClicked(event: MouseEvent): void {
    if ((<HTMLElement>event.target).classList.contains('modal')) {
    }
  }
}
