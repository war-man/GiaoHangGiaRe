import { Component } from '@angular/core';
import { DonhangServicesProvider } from '../../providers/donhang-services/donhang-services';

@Component({
  selector: 'page-donhang',
  templateUrl: 'donhang.html'
})
export class DonHangPage {
  listDonHang: any;
  constructor(private donhang_Services: DonhangServicesProvider) {
  }
  ngOnInit() {
    this.donhang_Services.getAllDonHang().then(res => {
      this.listDonHang = res.list;
    }, err => {
      console.log(err);
    })
  }
  gotoDetailsDonHang(MaDonHang){
    console.log(MaDonHang);
  }
}
