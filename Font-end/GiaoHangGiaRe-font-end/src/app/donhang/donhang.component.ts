import { Component, OnInit } from '@angular/core';
import {DonHangService} from '../../providers/donhang_service/donhang.service';
import { Router, Route } from '@angular/router';
import {DonHangDetailsComponent} from '../don-hang-details/don-hang-details.component';
import { DataService } from '../../providers/data_services';

@Component({
  selector: 'app-donhang',
  templateUrl: './donhang.component.html',
  styleUrls: ['./donhang.component.scss']
})
export class DonhangComponent implements OnInit {
  listDonHang: any[];
  constructor(private donhang_Service: DonHangService, public dataservice: DataService, private router: Router) { }

  ngOnInit() {
    this.donhang_Service.getDonHang().then(res =>{
      console.log(res);
      this.listDonHang = res.list;
    })
  }
  gotoDonHangDetails(id){
    this.donhang_Service.getDonHangDetails(id).then(res=>{
      console.log(res);
      this.router.navigateByUrl('chittiet-donhang');
      this.dataservice.DonHangDetails = res;
    })
  }
}
