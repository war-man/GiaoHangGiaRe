import { Component } from '@angular/core';
import { NavController, NavParams, ModalController } from 'ionic-angular';
import {DonHangKienHangPage} from '../don-hang-kien-hang/don-hang-kien-hang';
import { DonhangServicesProvider } from '../../../providers/donhang-services/donhang-services';

/**
 * Generated class for the DonHanGiaoHangPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-don-hang-waitting',
  templateUrl: 'don-hang-waitting.html',
})
export class DonHangWaittingPage {
  lishDonHangWaitting: any;
  constructor(public navCtrl: NavController, public navParams: NavParams,
    public ModalCtrl: ModalController,
    public donhangServices: DonhangServicesProvider) {
    this.donhangServices.getAllDonHangWaitting().then(res => {
      this.lishDonHangWaitting = res.list;
    })
  }

  ngOnInit() {
  }
  doRefresh(refresh) {
    refresh.complete();
  }
  doInfinite(infinite) {
    infinite.complete();
  }
  gotoDetailsDonHang(item){
    let donhangKienHang =  this.ModalCtrl.create(DonHangKienHangPage, {DonHang: item});
    donhangKienHang.present();
    console.log(item);
  }
}
