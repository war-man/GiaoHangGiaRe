import { Injectable } from '@angular/core';
import { HttpService } from '../http_services';
import { HttpParams } from '@angular/common/http';

/*
  Generated class for the BangGiaProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class BangGiaProvider {

  constructor(private http_Service: HttpService) {
  }

  getBangGia(): any{
    return new Promise((resolve, reject) => {
      this.http_Service.get('user/api/banggia/get-all').subscribe(res => {
        resolve(res);
      }, err => {
        reject(err);
      })
    })
  }
  getGia(params: HttpParams): any{
    if(!params){
      params = new HttpParams();
    }
    return new Promise((resolve, reject) => {
      this.http_Service.get('user/api/banggia/get-calculate-price', params).subscribe(res => {
        resolve(res);
      }, err => {
        reject(err);
      })
    })
  }
}
