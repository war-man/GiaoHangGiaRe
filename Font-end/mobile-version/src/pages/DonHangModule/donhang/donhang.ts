import { Component } from '@angular/core';
import {NavController} from 'ionic-angular'
import { DonhangServicesProvider } from '../../../providers/donhang-services/donhang-services';
import {DonHangDetailPage} from '../don-hang-detail/don-hang-detail';
import {CreateDonHangPage} from '../create-don-hang/create-don-hang';

@Component({
  selector: 'page-donhang',
  templateUrl: 'donhang.html'
})
export class DonHangPage {
  listDonHang: any;
  constructor(private donhang_Services: DonhangServicesProvider,
  private navCtr: NavController) {
  }
  ngOnInit() {
    this.donhang_Services.getAllDonHang().then(res => {
      this.listDonHang = res.list;
    }, err => {
      console.log(err);
    })
  }
  gotoDetailsDonHang(DonHang){
    this.navCtr.push(DonHangDetailPage, {DonHang: DonHang});
    console.log(DonHang);
  }
  createDonHang(){
    this.navCtr.push(CreateDonHangPage);
  }
}
