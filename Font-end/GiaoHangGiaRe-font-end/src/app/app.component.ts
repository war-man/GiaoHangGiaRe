import { Component } from '@angular/core';
import {LoginService} from '../providers/login_service/login.service';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { MypageComponent } from './mypage/mypage.component';
import { DonhangComponent } from './donhang/donhang.component';
import { LoginComponent } from './login/login.component';

@Component({
  providers: [ LoginService ],
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app works!';
}
