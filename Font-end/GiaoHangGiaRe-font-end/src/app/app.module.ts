import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import {Routes, RouterModule} from "@angular/router";

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { MypageComponent } from './mypage/mypage.component';
import { DonhangComponent } from './donhang/donhang.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'mypage', component: MypageComponent },
  { path: 'donhang', component: DonhangComponent },
  { path: 'login', component: LoginComponent }
 ];
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    MypageComponent,
    DonhangComponent,
    LoginComponent
  ],
  
  imports: [
    
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(routes, {useHash: true})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
