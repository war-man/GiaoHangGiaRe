import { HttpService } from '../http-service';
import { Injectable } from '@angular/core';
import { error } from 'selenium-webdriver';
import { Router } from '@angular/router';

@Injectable()
export class DonHangService {
  constructor(private httpService: HttpService, private router: Router) {
  }
  getDonHang() : any{
    return new Promise((resolve, reject) => {
      this.httpService.get('user/api/donhang/get-all').subscribe((res) => {
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
}
