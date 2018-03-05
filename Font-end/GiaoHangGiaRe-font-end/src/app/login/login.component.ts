import { Component, OnInit, Injectable } from '@angular/core';
import { LoginService } from '../../providers/login_service/login.service';
import { Router } from '@angular/router';
@Injectable()
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  model = { username: '', password: '' };
  userData: any;
  login_err: any;
  constructor(private loginService: LoginService, private router: Router) {
  }
  ngOnInit() {
  }
  submitData() {
    const input = 'grant_type=password&username=' + this.model.username + '&password=' + this.model.password;
    this.loginService.login(input).then((res) => {
      if (res) {
        this.userData = res;
        this.loginService.stoteUserData(this.userData);
        this.router.navigateByUrl('/home');
        window.location.reload();
      }
    }, err => {
      this.login_err = err.error_description;
    });
  }
}
