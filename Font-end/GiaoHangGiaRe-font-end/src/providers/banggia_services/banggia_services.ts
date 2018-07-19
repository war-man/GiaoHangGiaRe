import { HttpService } from '../http-service';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable()
export class BangGiaService {
  userData: any;
  constructor(private httpService: HttpService, private router: Router) {
  }
  getBangGia(): any {
    return new Promise((resolve, reject) => {
      this.httpService.get('user/api/banggia/get-all').subscribe((res) => {
        resolve(res);
      });
    });
  }
}
