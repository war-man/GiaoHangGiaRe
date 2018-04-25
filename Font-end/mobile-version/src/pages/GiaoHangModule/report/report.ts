import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ViewController } from 'ionic-angular';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

/**
 * Generated class for the ReportPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-report',
  templateUrl: 'report.html',
})
export class ReportPage {
  reportForm: FormGroup;
  donHang: any;
  constructor(public navCtrl: NavController, public navParams: NavParams,
    private formBuilder: FormBuilder,
    public ViewCtrl: ViewController) {
    this.donHang = this.navParams.get('DonHang');
    this.reportForm = this.formBuilder.group({
      NoiDung: [''],
      ChonNhanhNoiDung: ['', [Validators.required]]
    })
  }

  ionViewDidLoad() {

  }
  submitData() {
    console.log(this.reportForm.value);
  }
  closemodal() {
    this.ViewCtrl.dismiss();
  }
}
