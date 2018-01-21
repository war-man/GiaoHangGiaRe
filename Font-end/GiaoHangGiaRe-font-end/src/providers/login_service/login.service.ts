import { HttpService } from '../http-service';
import { Injectable } from '@angular/core';

@Injectable()
export class LoginService {
  userData: any;
  constructor(private httpService: HttpService) {
    this.userData = { ja: 'aa' };
  }
  getUserData(): any {
    return new Promise((resolve, reject) => {
      this.httpService.get('usermanager').then((res) => {
        resolve(res);
      });
    });
  }
}
