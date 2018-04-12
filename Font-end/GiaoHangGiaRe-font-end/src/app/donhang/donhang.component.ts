import { Component, OnInit } from '@angular/core';
import { DonHangService } from '../../providers/donhang_service/donhang.service';
import { Router, Route } from '@angular/router';
import { DonHangDetailsComponent } from '../don-hang-details/don-hang-details.component';
import { DataService } from '../../providers/data_services';

@Component({
  selector: 'app-donhang',
  templateUrl: './donhang.component.html',
  styleUrls: ['./donhang.component.scss']
})
export class DonhangComponent implements OnInit {
  listDonHang: any[];
  donHangStatus: any;
  active: boolean[];
  constructor(private donhang_Service: DonHangService, public dataservice: DataService, private router: Router) {
    this.active = [];
    for (let i = 0; i < 5; i++) {
      this.active[i] = false;
    }
  }
  ngOnInit() {
    this.donhang_Service.getDonHangStatus().then(res => {
      this.donHangStatus = res._statusDonHang;
    })
    this.donhang_Service.getDonHang().then(res => {
      this.listDonHang = res.list;
    })
  }
  getActive(index) {
    for (let i = 0; i < this.active.length; i++) {
      if (i == index) {
        this.active[i] = true;
      } else {
        this.active[i] = false;
      }
    }
  }
  getHuy(event) {
    this.getActive(0);
    this.donhang_Service.getDonHang(-1).then(res => {
      this.listDonHang = res.list;
    })
  }
  getDangGiao() {
    this.getActive(2);
    this.donhang_Service.getDonHang(1).then(res => {
      this.listDonHang = res.list;
    })
  }
  getNhapKho() {
    this.getActive(3);
    this.donhang_Service.getDonHang(2).then(res => {
      this.listDonHang = res.list;
    })
  }
  getDangCho() {
    this.getActive(1);
    this.donhang_Service.getDonHang(0).then(res => {
      this.listDonHang = res.list;
    })
  }
  getGiaoThanhCong() {
    this.getActive(4);
    this.donhang_Service.getDonHang(3).then(res => {
      this.listDonHang = res.list;
    })
  }
}
