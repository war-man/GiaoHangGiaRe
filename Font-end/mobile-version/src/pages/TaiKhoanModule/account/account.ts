import { Component } from '@angular/core';

import { AlertController, NavController } from 'ionic-angular';
import { Camera, CameraOptions } from '@ionic-native/camera';

import { UserData } from '../../../providers/user-data';


@Component({
  selector: 'page-account',
  templateUrl: 'account.html'
})
export class AccountPage {
  user: any;
  constructor(public alertCtrl: AlertController, public nav: NavController, public userData: UserData,
    private camera: Camera) {
    this.userData.getUser().then(res =>{
      this.user = res;
    })
  }

  ngAfterViewInit() {
    
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
  changeUsername(){
    
  }
  // Present an alert with the current username populated
  // clicking OK will update the username and display it
  // clicking Cancel will close the alert and do nothing

  changePassword() {
    console.log('Clicked to change password');
  }

  logout() {
    this.userData.logout();
    this.nav.setRoot('LoginPage');
  }

  support() {
    this.nav.push('SupportPage');
  }
}
