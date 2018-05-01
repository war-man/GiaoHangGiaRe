import { Component, OnInit } from '@angular/core';
import { DonHangService } from '../../providers/donhang_service/donhang.service';
import { Router, Route } from '@angular/router';
import { DonHangDetailsComponent } from '../don-hang-details/don-hang-details.component';
import { DataService } from '../../providers/data_services';
import {GIAOTHANHCONG, GUIVAOKHO, DANGCHO, HUY, DANGGIAO} from '../constanValue';

@Component({
  selector: 'app-donhang',
  templateUrl: './donhang.component.html',
  styleUrls: ['./donhang.component.scss']
})
export class DonhangComponent implements OnInit {
  HUY = HUY;
  DANGGIAO = DANGGIAO;
  GIAOTHANHCONG = GIAOTHANHCONG;
  GUIVAOKHO = GUIVAOKHO;
  DANGCHO = DANGCHO;
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
    this.donhang_Service.getDonHang(HUY).then(res => {
      this.listDonHang = res.list;
    })
  }
  getDangGiao() {
    this.getActive(2);
    this.donhang_Service.getDonHang(DANGGIAO).then(res => {
      this.listDonHang = res.list;
    })
  }
  getNhapKho() {
    this.getActive(3);
    this.donhang_Service.getDonHang(GUIVAOKHO).then(res => {
      this.listDonHang = res.list;
    })
  }
  getDangCho() {
    this.getActive(1);
    this.donhang_Service.getDonHang(DANGCHO).then(res => {
      this.listDonHang = res.list;
    })
  }
  getGiaoThanhCong() {
    this.getActive(4);
    this.donhang_Service.getDonHang(GIAOTHANHCONG).then(res => {
      this.listDonHang = res.list;
    })
  }
}
