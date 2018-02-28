import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { HttpService } from '../providers/http-service';
import { LoginService } from '../providers/login_service/login.service';

import { AppComponent } from './app.component';

import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { MypageComponent } from './mypage/mypage.component';
import { DonhangComponent } from './donhang/donhang.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { DonhangFormComponent } from 'app/donhang-form/donhang-form.component';
import { ModalDirective } from './modal.directive';
import { KienhangModalComponent } from './kienhang-modal/kienhang-modal.component';

const routes: Routes = [
      { path: '', component: HomeComponent },
      { path: 'home', component: HomeComponent },
      { path: 'about', component: AboutComponent },
      { path: 'mypage', component: MypageComponent },
      { path: 'donhang', component: DonhangComponent },
      { path: 'login', component: LoginComponent },
      { path: 'logout', component: LogoutComponent },
      { path: 'donhang-them', component: DonhangFormComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    MypageComponent,
    DonhangComponent,
    LoginComponent,
    DonhangFormComponent,
    LogoutComponent,
    ModalDirective,
    KienhangModalComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(routes, { useHash: true })
  ],
  providers: [
    HttpService,
    LoginService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
