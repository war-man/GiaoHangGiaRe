import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NavController } from 'ionic-angular';
import { UserData } from '../../../providers/user-data';
import { UserServices } from '../../../providers/user-services/user-services';


@Component({
  selector: 'page-user',
  templateUrl: 'login.html'
})
export class LoginPage {
  lgonForm: FormGroup;
  login_err: any;
  constructor(public navCtrl: NavController,
    public userData: UserData,
    private formBuilder: FormBuilder,
    private user_Services: UserServices) {

  }
  ngOnInit() {
    this.lgonForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }
  submitData() {
    if(this.lgonForm.valid){
      this.user_Services.login(this.lgonForm.value).then(res =>{
        this.login_err = '';
        this.userData.login(res);
      }, err =>{
        this.login_err = err.json().error_description;
      })
    }
  }
}
