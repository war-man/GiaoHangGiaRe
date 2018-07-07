import { Component } from '@angular/core';
import {DANGCHO,DATIEPNHAN,GIAOTHANHCONG,GUIVAOKHO,DANGLAYHANG, DANGGIAO} from '../../constValue';
import { App, NavController, ModalController, ViewController } from 'ionic-angular';

@Component({
  template: `
    <ion-list>
      <button ion-item (click)="close(DANGCHO)">Đang chờ</button>
      <button ion-item (click)="close(DATIEPNHAN)">Đã tiếp nhận</button>
      <button ion-item (click)="close(DANGLAYHANG)">Đang lấy hàng</button>
      <button ion-item (click)="close(DANGGIAO)">Đang giao</button>
      <button ion-item (click)="close(GUIVAOKHO)">Trong kho</button>
      <button ion-item (click)="close(GIAOTHANHCONG)">Hoàn thành</button>
      <button ion-item (click)="close()">Tất cả</button>
    </ion-list>
  `
})
export class PopoverDonHangPage {
  DANGCHO = DANGCHO;
  DATIEPNHAN = DATIEPNHAN;
  DANGLAYHANG = DANGLAYHANG;
  DANGGIAO = DANGGIAO;
  GIAOTHANHCONG= GIAOTHANHCONG;
  GUIVAOKHO = GUIVAOKHO;

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