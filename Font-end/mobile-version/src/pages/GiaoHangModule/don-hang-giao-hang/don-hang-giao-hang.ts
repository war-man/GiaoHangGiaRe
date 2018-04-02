import { Component } from '@angular/core';
import { SignalrServiceProvider } from '../../../providers/signalr-service/signalr-service';
import { NavController, NavParams } from 'ionic-angular';
import { DonhangServicesProvider } from '../../../providers/donhang-services/donhang-services';


/**
 * Generated class for the DonHanGiaoHangPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-don-hang-giao-hang',
  templateUrl: 'don-hang-giao-hang.html',
})
export class DonHangGiaoHangPage {
  nick = '';
  message = '';
  messages: string[] = [];
  listDonHang: any;
  constructor(public navCtrl: NavController, public navParams: NavParams, public SignalrProvider: SignalrServiceProvider,
    public DonhangServices: DonhangServicesProvider) {
    this.DonhangServices.getAllDonHangShipper().then(res => {
      this.listDonHang = res.list;
      console.log(this.listDonHang);
    })
  }

  ngOnInit() {
    // this.SignalrProvider.startConnection();
  }
}
