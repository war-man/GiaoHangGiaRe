import { Component } from '@angular/core';
import { NavController, NavParams, ViewController } from 'ionic-angular';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Camera, CameraOptions } from '@ionic-native/camera';
import {BangGiaProvider} from '../../providers/bang-gia/bang-gia';
import { HttpParams } from '@angular/common/http';

/**
 * Generated class for the KienHangFormPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-kien-hang-form',
  templateUrl: 'kien-hang-form.html',
})
export class KienHangFormPage {
  kienhanggForm: FormGroup;
  kienHang: any;
  index: any;
  constructor(public navCtrl: NavController, public navParams: NavParams,
    public bangGiaProvider: BangGiaProvider,
    private formBuilder: FormBuilder,
    private camera: Camera,
    public ViewCtrl: ViewController) {
    this.index = this.navParams.get('index');
    let arrayKienHang = this.navParams.get('kienHangArray');
    if(arrayKienHang){
      this.kienHang = arrayKienHang[this.index];
      console.log(this.kienHang);
    }
    else{
      this.kienHang = {};
    }
    this.kienhanggForm = this.formBuilder.group({
      NoiDung: [this.kienHang.NoiDung ?this.kienHang.NoiDung:'', [Validators.required]],
      GhiChu: [this.kienHang.GhiChu ?this.kienHang.GhiChu:'', [Validators.required]],
      TrongLuong: [this.kienHang.TrongLuong ?this.kienHang.TrongLuong:'', [Validators.required]],
      ChieuRong: [this.kienHang.ChieuRong ?this.kienHang.ChieuRong:'', [Validators.required]],
      ChieuDai: [this.kienHang.ChieuDai ?this.kienHang.ChieuDai:'', [Validators.required]],
      MoTa: [this.kienHang.MoTa ?this.kienHang.MoTa:'', [Validators.required]],
      SoLuong: [this.kienHang.SoLuong ?this.kienHang.SoLuong:'', [Validators.required]]
    });
  }
  updatePicture() {
    const options: CameraOptions = {
      quality: 100,
      destinationType: this.camera.DestinationType.DATA_URL,
      encodingType: this.camera.EncodingType.JPEG,
      mediaType: this.camera.MediaType.PICTURE
    }

    this.camera.getPicture(options).then((imageData) => {
      // imageData is either a base64 encoded string or a file URI
      // If it's base64:
      let base64Image = 'data:image/jpeg;base64,' + imageData;
      console.log(base64Image);
    }, (err) => {
      console.log(err);
      // Handle error
    });
  }
  ionViewDidLoad() {
  }
  submitData() {
    if (this.kienhanggForm.valid) {
      this.kienhanggForm.value.index = this.index;
      let params = new HttpParams();
      params = params.append('ChieuDai',this.kienhanggForm.value.ChieuDai).append('ChieuRong',this.kienhanggForm.value.ChieuRong)
      .append('KhoiLuong',this.kienhanggForm.value.TrongLuong);
      this.bangGiaProvider.getGia(params).then(res=>{
        console.log(res);
        this.kienhanggForm.value.ThanhTien = res;
        this.ViewCtrl.dismiss(this.kienhanggForm.value);
      })
    }
  }
  closemodal() {
    this.ViewCtrl.dismiss();
  }
}
