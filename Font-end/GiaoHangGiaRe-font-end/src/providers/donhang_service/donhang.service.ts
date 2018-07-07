import { HttpService } from '../http-service';
import { Injectable } from '@angular/core';
import { error } from 'selenium-webdriver';
import { Router } from '@angular/router';
import { Http, Headers, RequestOptions, URLSearchParams } from '@angular/http';

@Injectable()
export class DonHangService {
  constructor(private httpService: HttpService, private router: Router) {
  }
  getDonHang(tinhtrang?) : any{
    let params: URLSearchParams  = new URLSearchParams();
   params.set('tinhtrang', tinhtrang);
    return new Promise((resolve, reject) => {
      this.httpService.get('user/api/donhang/get-all', params).subscribe((res) => {
        resolve(res);
      }, err => {
        err = err.json();
        reject(err);
      })
    });
  }
  taoDonHang(input) : any{
    return new Promise((resolve, reject) => {
        this.httpService.post('user/api/donhang/create', input).subscribe((res) => {
          resolve(res);
        }, err => {
          err = err.json();
          reject(err);
        })
      });
  }
  getDonHangStatus(): any {
    return new Promise((resolve, reject) => {
      this.httpService.get('user/api/donhang/get-status').subscribe((res) => {
        resolve(res);
      }, err => {
        err = err.json();
        reject(err);
      })
    });
  }
  updateDonHang(input) : any{
    return new Promise((resolve, reject) => {
        this.httpService.put('user/api/donhang/update', input).subscribe((res) => {
          resolve(res);
        }, err => {
          err = err.json();
          reject(err);
        })
      });
  }
  getDonHangDetails(id) : any{
   let params: URLSearchParams  = new URLSearchParams();
   params.set('id', id);
    return new Promise((resolve, reject) => {
      this.httpService.get('user/api/donhang/get-by-id', params).subscribe((res) => {
        resolve(res);
      }, err => {
        err = err.json();
        reject(err);
      })
    });
  }
}
