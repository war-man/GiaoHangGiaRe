import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NavController, AlertController } from 'ionic-angular';
import { UserServices } from '../../../providers/user-services/user-services';

import { UserData } from '../../../providers/user-data';


@Component({
  selector: 'page-user',
  templateUrl: 'signup.html'
})
export class SignupPage {
  signup_err: any;
  submitted = false;
  signupForm: FormGroup;
  constructor(public navCtrl: NavController, public userData: UserData,
    private formBuilder: FormBuilder, public AlertCtrl: AlertController,
    private user_Services: UserServices) {

    }
  ngOnInit() {
    this.signupForm = this.formBuilder.group({
      TenTaiKhoan: ['', [Validators.required]],
      Password: ['', [Validators.required]],
      email: ['', [Validators.required]],
      HoTen: ['', [Validators.required]],
      DiaChi: ['', [Validators.required]],
      CongTy: ['', [Validators.required]],
      SoDienThoai: ['', [Validators.required]]
    });
  }
  submitData() {
    this.submitted = true;
    if(this.signupForm.valid){
      this.user_Services.signup(this.signupForm.value).then((res) =>{
        this.signup_err = res.Errors;
        if(res.Succeeded === true){
          let noti = this.AlertCtrl.create({
            message: 'Đăng ký thành công.'
          })
          noti.present();
          noti.onDidDismiss(()=>{
            
          })
        }
      }, err =>{
        this.signup_err = err.json().error_description;
      })
    }
  }
}
