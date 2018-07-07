import { Component } from '@angular/core';
import { LoginService } from '../providers/login_service/login.service';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { MypageComponent } from './mypage/mypage.component';
import { DonhangComponent } from './donhang/donhang.component';
import { LoginComponent } from './login/login.component';

import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isLoggedIn: boolean;
  userProfile: any;
  title = 'app works!';
  constructor(private router: Router) {
    this.userProfile = localStorage.getItem('userProfile');
    this.userProfile = JSON.parse(this.userProfile);
    if (this.userProfile) {
      this.isLoggedIn = true;
      this.router.navigate(['/']);
    } else {
      this.isLoggedIn = false;
      this.router.navigate(['/login']);
    }
  }
}
