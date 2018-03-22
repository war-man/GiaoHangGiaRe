import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NavController } from 'ionic-angular';
import { UserServices } from '../../../providers/user-services/user-services';

import { UserData } from '../../../providers/user-data';

import { UserOptions } from '../../../interfaces/user-options';

import { TabsPage } from '../../tabs-page/tabs-page';


@Component({
  selector: 'page-user',
  templateUrl: 'signup.html'
})
export class SignupPage {
  signup_err: any;
  submitted = false;
  signupForm: FormGroup;
  constructor(public navCtrl: NavController, public userData: UserData,
    private formBuilder: FormBuilder,
    private user_Services: UserServices) {

    }
  ngOnInit() {
    this.signupForm = this.formBuilder.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],
      
    });
  }
  submitData() {
    this.submitted = true;
    if(this.signupForm.valid){
      this.user_Services.signup(this.signupForm.value).then(res =>{
        this.signup_err = '';
        this.userData.login(res);
      }, err =>{
        this.signup_err = err.json().error_description;
      })
    }
  }
}
