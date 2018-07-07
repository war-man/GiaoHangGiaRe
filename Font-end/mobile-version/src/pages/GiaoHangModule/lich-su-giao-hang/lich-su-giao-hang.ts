import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { DonhangServicesProvider } from '../../../providers/donhang-services/donhang-services';

/**
 * Generated class for the LichSuGiaoHangPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-lich-su-giao-hang',
  templateUrl: 'lich-su-giao-hang.html',
})
export class LichSuGiaoHangPage {
  lishSuGiaoHang: any;
  constructor(public navCtrl: NavController, public navParams: NavParams,
    public DonhangServices: DonhangServicesProvider) {
    this.DonhangServices.getLishSuDonHangShipper().then(res => {
      this.lishSuGiaoHang = res.list;
    })
  }

  gotoDetailsDonHang(){
    
  }
}
