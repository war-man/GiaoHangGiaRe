import { HttpService } from '../http-service';
import { Injectable } from '@angular/core';
import { error } from 'selenium-webdriver';
import { Router } from '@angular/router';

@Injectable()
export class LoginService {
  userData: any;
  constructor(private httpService: HttpService, private router: Router) {
    this.userData = { ja: 'aa' };
  }
  stoteUserData(input: any) {
    localStorage.setItem('userProfile', JSON.stringify(input));
  }
  getUserData(): any {
    return new Promise((resolve, reject) => {
      this.httpService.get('').then((res) => {
        resolve(res);
      });
    });
  }
  login(input: any): any {
    return new Promise((resolve, reject) => {
      this.httpService.post('token', input).subscribe((res) => {
        resolve(res);
      });
    });
  }
}
