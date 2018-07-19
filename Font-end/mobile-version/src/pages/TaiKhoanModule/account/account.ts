import { Component } from '@angular/core';

import { AlertController, NavController,ActionSheetController } from 'ionic-angular';
import { Camera } from '@ionic-native/camera';

import { UserData } from '../../../providers/user-data';


@Component({
  selector: 'page-account',
  templateUrl: 'account.html'
})
export class AccountPage {
  user: any;
  base64Image: any;
  constructor(public alertCtrl: AlertController, public nav: NavController, public userData: UserData,
    public actionSheetCtrl: ActionSheetController,
    private camera: Camera) {
    this.userData.getUser().then(res =>{
      this.user = res;
    })
  }

  ngAfterViewInit() {
    
  }
  editAvatar() {
    this.openCamera();
  }
  openCamera() {
    let actionSheet = this.actionSheetCtrl.create({
      title: 'Chụp ảnh hoặc chọn ảnh',
      buttons: [
        {
          text: 'Chụp ảnh',
          handler: () => {
            this.takePhoto(0);
          }
        },
        {
          text: 'Chọn ảnh trong máy',
          handler: () => {
            this.takePhoto(1);
          }
        },
        {
          text: 'Hủy bỏ',
          role: 'cancel',
          handler: () => {
          }
        },
      ],
    });
    actionSheet.present();
  }
  takePhoto(check) {
    var options = {
      quality: 100,
      destinationType: this.camera.DestinationType.DATA_URL,
      sourceType: this.camera.PictureSourceType.PHOTOLIBRARY,
      encodingType: this.camera.EncodingType.JPEG,
      allowEdit: true,
      mediaType: this.camera.MediaType.PICTURE,
      targetWidth: 300,
      targetHeight: 300,
      saveToPhotoAlbum: false
    };
    if (check == 0) { // Take photo
      options.sourceType = this.camera.PictureSourceType.CAMERA;
    } else if (check == 1) { //Choose Photo
      options.sourceType = this.camera.PictureSourceType.PHOTOLIBRARY;
    }
    this.camera.getPicture(options).then((imageData) => {
      this.base64Image = imageData;
    }, (err) => {
      console.log(err);
    })
  }

  changeUsername(){
    
  }

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
