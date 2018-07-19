import { Injectable } from '@angular/core';
import { HttpService } from '../http_services';
import { HttpParams } from '@angular/common/http';
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
  getLishSuDonHangShipper() : any{
    return new Promise((resolve, reject) => {
      this.http_Service.get('user/api/donhang/get-lishsu-donhang-shipper').subscribe(res => {
        resolve(res);
      }, err => {
        reject(err);
      })
    })
  }
  getKienHangDonHang(MaDonHang: any) : any{
    let httpParams = new HttpParams().append("MaDonHang", MaDonHang)
    return new Promise((resolve, reject) => {
      this.http_Service.get('user/api/donhang/get-kienhang-donhang', httpParams).subscribe(res => {
        resolve(res);
      }, err => {
        reject(err);
      })
    })
  }
  ship_receive(MaDonHang: any): any{
    let httpParams = new HttpParams().append("MaDonHang", MaDonHang)
    return new Promise((resolve, reject) => {
      this.http_Service.put('user/api/donhang/ship_receive',null, httpParams).subscribe(res => {
        resolve(res);
      }, err => {
        reject(err);
      })
    })
  }
  changeStatusDonHang(input) : any{
    return new Promise((resolve, reject) => {
      this.http_Service.put('user/api/donhang/change_status', input).subscribe(res => {
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
  reportDonHang(input) : any{
    return new Promise((resolve, reject) => {
      this.http_Service.post('user/api/donhang/report_donhang', input).subscribe(res => {
        resolve(res);
      }, err => {
        reject(err);
      })
    })
  }
}
