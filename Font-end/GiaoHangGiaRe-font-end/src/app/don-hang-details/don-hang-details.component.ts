import { Component, OnInit } from '@angular/core';
import { Router, Params, Route } from '@angular/router';
import { DataService } from '../../providers/data_services';

@Component({
  selector: 'app-don-hang-details',
  templateUrl: './don-hang-details.component.html',
  styleUrls: ['./don-hang-details.component.scss']
})
export class DonHangDetailsComponent implements OnInit {
  DonHang: any;
  kienhang_array: any;
  constructor(private router: Router, public dataservice: DataService) {
    let tam = this.dataservice.DonHangDetails;
    if (tam.kienhang) {
      this.kienhang_array = tam.kienhang;
    }
    this.DonHang = tam.donhang;
  }

  ngOnInit() {
  }
  editDonHang() {

  }
  theoDoiDonHang() {

  }
  ngOnDestroy() {
  }
}
