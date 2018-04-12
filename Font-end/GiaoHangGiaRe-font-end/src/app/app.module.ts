import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';
import { AgmCoreModule } from '@agm/core';

import { DataService } from '../providers/data_services';
import { HttpService } from '../providers/http-service';
import { LoginService } from '../providers/login_service/login.service';
import {DonHangService} from '../providers/donhang_service/donhang.service';

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
import { DonHangDetailsComponent } from './don-hang-details/don-hang-details.component';
import { ContactComponent } from './contact/contact.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
      { path: '', component: HomeComponent },
      { path: 'home', component: HomeComponent },
      { path: 'about', component: AboutComponent },
      { path: 'contact', component: ContactComponent },
      { path: 'mypage', component: MypageComponent },
      { path: 'donhang', component: DonhangComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent },
      { path: 'logout', component: LogoutComponent },
      { path: 'donhang-them/:id', component: DonhangFormComponent },//update
      { path: 'donhang-them', component: DonhangFormComponent }, //them
      { path: 'chittiet-donhang/:id', component: DonHangDetailsComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    MypageComponent,
    ContactComponent,
    DonhangComponent,
    LoginComponent,
    DonhangFormComponent,
    LogoutComponent,
    ModalDirective,
    KienhangModalComponent,
    DonHangDetailsComponent,
    RegisterComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule,
    FormsModule,
    HttpModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyBv5_hf7TmyJiZIkOnLJEJpcotnQfn4rQE'
    }),
    RouterModule.forRoot(routes, { useHash: true })
  ],
  providers: [
    DataService,
    HttpService,
    LoginService,
    DonHangService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
