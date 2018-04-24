import { Component } from '@angular/core';
import {NavController, PopoverController } from 'ionic-angular'
import { DonhangServicesProvider } from '../../../providers/donhang-services/donhang-services';
import {DonHangDetailPage} from '../don-hang-detail/don-hang-detail';
import {CreateDonHangPage} from '../create-don-hang/create-don-hang';
import {PopoverDonHangPage} from '../popover-donhang/donhang-popover';
import {DEFAULT_IMAGE} from '../../constValue';

@Component({
  selector: 'page-donhang',
  templateUrl: 'donhang.html'
})
export class DonHangPage {
  listDonHang: any;
  respostory: any;
  popover: any;
  DEFAULT_IMAGE = DEFAULT_IMAGE;
  listDonHangFillter: any;
  constructor(private donhang_Services: DonhangServicesProvider,
    public popoverCtrl: PopoverController,
  private navCtr: NavController) {
  }
  ngOnInit() {
    this.donhang_Services.getAllDonHang().then(res => {
      this.respostory = res.list;
      this.listDonHang = res.list;
    }, err => {
      console.log(err);
    })
  }
  gotoDetailsDonHang(DonHang){
    this.navCtr.push(DonHangDetailPage, {DonHang: DonHang});
  }
  presentPopover(myEvent) {
    this.popover = this.popoverCtrl.create(PopoverDonHangPage);
    this.popover.present({
      ev: myEvent
    });
    this.popover.onDidDismiss(type =>{
      if(type != undefined){
        this.listDonHangFillter = [];
        for( let i=0; i< this.listDonHang.length; i++)
        {
          if(this.listDonHang[i].TinhTrang == type){
            this.listDonHangFillter.push(this.listDonHang[i]);
          }
        }
        this.listDonHang = this.listDonHangFillter;
      } else{
        this.listDonHang = this.respostory;
      }
    })
  }
  createDonHang(){
    this.navCtr.push(CreateDonHangPage);
  }
}
