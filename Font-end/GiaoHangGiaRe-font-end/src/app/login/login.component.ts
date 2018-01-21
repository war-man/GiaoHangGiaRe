import { Component, OnInit, Injectable  } from '@angular/core';
import {LoginService} from '../../providers/login_service/login.service';
@Injectable()
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  userData: any;

  constructor(private loginService: LoginService) {
  }
  ngOnInit() {
    this.loginService.getUserData().then((res) => {
      this.userData = res;
    });
  }
}
