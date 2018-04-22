import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import {BangGiaProvider} from '../../providers/bang-gia/bang-gia';

/**
 * Generated class for the BangGiaPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-bang-gia',
  templateUrl: 'bang-gia.html',
})
export class BangGiaPage {
  listBangGia: any;
  constructor(public navCtrl: NavController, public navParams: NavParams,
    public bangGiaProvider: BangGiaProvider) {
      this.bangGiaProvider.getBangGia().then(res=>{
        this.listBangGia = res.data;
      })
  }

  ionViewDidLoad() {
  }

}
