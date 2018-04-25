import { Component } from '@angular/core';
//import { SignalrServiceProvider } from '../../../providers/signalr-service/signalr-service';
import { NavController, NavParams , AlertController, ModalController } from 'ionic-angular';
import { DonhangServicesProvider } from '../../../providers/donhang-services/donhang-services';
import {DANGLAYHANG, DANGGIAO,LAYTHANHCONG, DATIEPNHAN, GIAOTHANHCONG} from '../../constValue';
import {ReportPage} from '../../GiaoHangModule/report/report';

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
  DANGLAYHANG = DANGLAYHANG;
  DANGGIAO = DANGGIAO;
  DATIEPNHAN = DATIEPNHAN;
  LAYTHANHCONG = LAYTHANHCONG;
  constructor(public navCtrl: NavController, public navParams: NavParams, public ModalCtrl: ModalController,
    private alertCtrl: AlertController,
    public DonhangServices: DonhangServicesProvider) {
      this.getData();
  }
  getData(){
    this.DonhangServices.getAllDonHangShipper().then(res => {
      this.listDonHangKienHang = res.list;
    })
  }
  ngOnInit() {

  }
  getKienHangDetails(){

  }
  todo_layHang(MaDonHang){
    this.DonhangServices.changeStatusDonHang({TinhTrang: DANGLAYHANG, MaDonHang: MaDonHang}).then(res => {
      if(res){
        this.presentAlert("ĐANG LẤY HÀNG.");
      }
    })
  }
  todo_giaoHang(MaDonHang){
    this.DonhangServices.changeStatusDonHang({TinhTrang: DANGGIAO, MaDonHang: MaDonHang}).then(res => {
      if(res){
        this.presentAlert("ĐANG GIAO HÀNG.");
      }
    })
  }
  todo_doneLayHang(MaDonHang){
    this.DonhangServices.changeStatusDonHang({TinhTrang: LAYTHANHCONG, MaDonHang: MaDonHang}).then(res => {
      if(res){
        this.presentAlert("Đã lấy hàng.");
      }
    })
  }
  todo_HoanThanh(MaDonHang){
    this.DonhangServices.changeStatusDonHang({TinhTrang: GIAOTHANHCONG, MaDonHang: MaDonHang}).then(res => {
      if(res){
        this.presentAlert("Giao hàng hoàn thành.");
      }
    })
  }
  reportDonHang(donhang){
    let Modal = this.ModalCtrl.create(ReportPage, {DonHang: donhang});
    Modal.present();
  }
  presentAlert(mess: string) {
    let alert = this.alertCtrl.create({
      title: 'Thông báo',
      subTitle: mess,
      buttons: [ {
        text: 'Xác nhận',
        role: 'Ok',
        handler: () => {
          this.getData();
        }
      }]
    });
    alert.present();
  }
}
