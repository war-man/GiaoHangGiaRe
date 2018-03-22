import { Injectable } from '@angular/core';
import { HttpService } from '../http_services';

/*
  Generated class for the DonhangServicesProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class DonhangServicesProvider {

  constructor(private http_Service: HttpService) {
  }
  getAllDonHang() : any{
    return new Promise((resolve, reject) => {
      this.http_Service.get('user/api/donhang/get-all').subscribe(res => {
        resolve(res);
      }, err => {
        reject(err);
      })
    })
  }
  getAllDonHangWaitting() : any{
    return new Promise((resolve, reject) => {
      this.http_Service.get('user/api/donhang/get-all-waitting').subscribe(res => {
        resolve(res);
      }, err => {
        reject(err);
      })
    })
  }
  getAllDonHangShipper() : any{
    return new Promise((resolve, reject) => {
      this.http_Service.get('user/api/donhang/get-all-shipper').subscribe(res => {
        resolve(res);
      }, err => {
        reject(err);
      })
    })
  }
  createDonHang(input) : any{
    return new Promise((resolve, reject) => {
      this.http_Service.post('user/api/donhang/create', input).subscribe(res => {
        resolve(res);
      }, err => {
        reject(err);
      })
    })
  }
}
