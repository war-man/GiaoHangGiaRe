import { Component } from '@angular/core';
//import { SignalrServiceProvider } from '../../../providers/signalr-service/signalr-service';
import { NavController, NavParams } from 'ionic-angular';
import { DonhangServicesProvider } from '../../../providers/donhang-services/donhang-services';
import {DANGLAYHANG, DANGGIAO} from '../../constValue';

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
  listDonHangKienHang: any;
  constructor(public navCtrl: NavController, public navParams: NavParams,
    public DonhangServices: DonhangServicesProvider) {
    this.DonhangServices.getAllDonHangShipper().then(res => {
      this.listDonHangKienHang = res.list;
    })
  }

  ngOnInit() {

  }
  getKienHangDetails(){

  }
  todo_layHang(){
    
  }
  todo_giaoHang(){

  }
}