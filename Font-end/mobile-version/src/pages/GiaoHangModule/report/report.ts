import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ViewController } from 'ionic-angular';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DonhangServicesProvider } from '../../../providers/donhang-services/donhang-services';

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
    public DonhangServices: DonhangServicesProvider,
    private formBuilder: FormBuilder,
    public ViewCtrl: ViewController) {
    this.donHang = this.navParams.get('DonHang');
    this.reportForm = this.formBuilder.group({
      Report_Content: ['',[Validators.required]]
    })
  }

  ionViewDidLoad() {

  }
  submitData() {
    console.log();
    if(this.reportForm.valid){
      this.DonhangServices.reportDonHang(this.reportForm.value).then(res =>{
        console.log(res);
      })
    }
  }
  closemodal() {
    this.ViewCtrl.dismiss();
  }
}
