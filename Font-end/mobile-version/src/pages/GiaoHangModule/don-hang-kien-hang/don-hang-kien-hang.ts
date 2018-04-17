import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ViewController } from 'ionic-angular';

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
  constructor(public navCtrl: NavController, public navParams: NavParams, public viewCtrl: ViewController) {
    this.DonHang = this.navParams.get('DonHang');
    console.log(this.DonHang);
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad DonHangKienHangPage');
  }

}
