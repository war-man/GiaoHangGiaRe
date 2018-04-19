import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ViewController } from 'ionic-angular';
import { DonhangServicesProvider } from '../../../providers/donhang-services/donhang-services';

/**
 * Generated class for the DonHangKienHangPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-don-hang-kien-hang',
  templateUrl: 'don-hang-kien-hang.html',
})
export class DonHangKienHangPage {
  DonHang: any;
  arrayKienHang: any[];
  constructor(public navCtrl: NavController, public navParams: NavParams, public viewCtrl: ViewController,
    public DonhangServices: DonhangServicesProvider) {
    this.DonHang = this.navParams.get('DonHang');
    this.DonhangServices.getKienHangDonHang(this.DonHang.MaDonHang).then(res => {
      this.arrayKienHang = res;
    })
  }
  tiepNhanDonHang(MaDonHang){
    this.DonhangServices.ship_receive(MaDonHang).then(res => {
      console.log(res);
    })
  }
}
