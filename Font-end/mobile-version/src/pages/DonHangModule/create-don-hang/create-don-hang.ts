import { Component } from '@angular/core';
import { NavController, NavParams, ModalController } from 'ionic-angular';
import { UserData } from '../../../providers/user-data';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {KienHangFormPage} from '../../kien-hang-form/kien-hang-form';
import { DonhangServicesProvider } from '../../../providers/donhang-services/donhang-services';

/**
 * Generated class for the CreateDonHangPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-create-don-hang',
  templateUrl: 'create-don-hang.html',
})
export class CreateDonHangPage {
  user: any;
  kienHangArray=[];
  donhangForm: FormGroup;
  error_kienhang: any;
  constructor(public navCtrl: NavController, public navParams: NavParams, 
    private formBuilder: FormBuilder,
    public userData: UserData,
    public donhang_Services: DonhangServicesProvider,
    public ModalCtrl: ModalController) {
      this.donhangForm = this.formBuilder.group({
        NguoiGui: ['', [Validators.required]],
        DiaChiGui: ['', [Validators.required]],
        DiaChiNhan: ['', [Validators.required]],
        GhiChu: ['', [Validators.required]],
        NguoiNhan: ['', [Validators.required]],
        SoDienThoaiNguoiGui: ['', [Validators.required]],
        SoDienThoaiNguoiNhan: ['', [Validators.required]],
      });
  }

  ionViewDidLoad() {
    this.userData.getUser().then(res =>{
      this.user = res;
    })
  }
  createKienHang(){
    let modal =  this.ModalCtrl.create(KienHangFormPage);
    modal.present();
    modal.onDidDismiss(res =>{
      if(res){
        this.kienHangArray.push(res) ;
        console.log(this.kienHangArray);
      }
    });
  }
  editKienHang(index){
    console.log(index);
    let modal =  this.ModalCtrl.create(KienHangFormPage, {kienHangArray: this.kienHangArray , index: index});
    modal.present();
    modal.onDidDismiss(res =>{
      if(res){
        this.kienHangArray[res.index]=res ;
        console.log(this.kienHangArray);
      }
    });
  }
  submitData(){
    if(this.kienHangArray.length ==0){
      this.error_kienhang = true;
    }else {
      this.error_kienhang = false;
    }
    if(this.donhangForm.valid && !this.error_kienhang){
      this.donhang_Services.createDonHang(JSON.stringify({donHang: this.donhangForm.value, kienHang: this.kienHangArray})).then(res=>{
        console.log(res);
        this.navCtrl.pop();
      });
    }
  }

}
