import { Component, OnInit } from '@angular/core';
import {BangGiaService} from '../../providers/banggia_services/banggia_services';

@Component({
  selector: 'app-bang-gia',
  templateUrl: './bang-gia.component.html',
  styleUrls: ['./bang-gia.component.scss']
})
export class BangGiaComponent implements OnInit {
  listBangGia: any;
  constructor( private _bangGiaService: BangGiaService ) {
    this._bangGiaService.getBangGia().then(res => {
      this.listBangGia = res.data;
    });
   }

  ngOnInit() {
  }

}
