import { Component } from '@angular/core';

import { App, NavController, ModalController, ViewController } from 'ionic-angular';

@Component({
  template: `
    <ion-list>
      <button ion-item (click)="close(0)">Chưa tiếp nhận</button>
      <button ion-item (click)="close(1)">Đợi tiếp nhận</button>
      <button ion-item (click)="close(2)">Đang giao</button>
      <button ion-item (click)="close(3)">Hoàn thành</button>
      <button ion-item (click)="close()">Tất cả</button>
    </ion-list>
  `
})
export class PopoverDonHangPage {

  constructor(
    public viewCtrl: ViewController,
    public navCtrl: NavController,
    public app: App,
    public modalCtrl: ModalController
  ) { }

  close(input) {
    this.viewCtrl.dismiss(input);
  }
}