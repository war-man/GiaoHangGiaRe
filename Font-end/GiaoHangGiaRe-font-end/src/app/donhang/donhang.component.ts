import { Component, OnInit } from '@angular/core';
import {DonHangService} from '../../providers/donhang_service/donhang.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-donhang',
  templateUrl: './donhang.component.html',
  styleUrls: ['./donhang.component.scss']
})
export class DonhangComponent implements OnInit {

  constructor(private donhang_Service: DonHangService, private router: Router) { }

  ngOnInit() {
    this.donhang_Service.getDonHang().then(res =>{
      console.log(res);
    })
  }

}
