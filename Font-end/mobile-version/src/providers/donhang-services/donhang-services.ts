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
}
