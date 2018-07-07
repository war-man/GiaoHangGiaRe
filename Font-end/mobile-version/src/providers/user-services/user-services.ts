import { Injectable } from '@angular/core';
import { HttpService } from '../../providers/http_services';
/*
  Generated class for the UserServicesProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class UserServices {

  constructor(private http_Service: HttpService) {
  }
  login(input: any): any {
    input = 'grant_type=password&username=' + input.username + '&password=' + input.password;
    return new Promise((resolve, reject) => {
      this.http_Service.post('token', input).subscribe(res => {
        resolve(res);
      }, err => {
        reject(err);
      })
    })
  }
  signup(input: any): any{
    return new Promise((resolve, reject) => {
      this.http_Service.post('user/api/taikhoan/register', input).subscribe(res => {
        resolve(res);
      }, err => {
        reject(err);
      })
    })
  }
}
