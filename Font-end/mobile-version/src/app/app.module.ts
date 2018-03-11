import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { NgModule, ErrorHandler } from '@angular/core';

import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';

import { InAppBrowser } from '@ionic-native/in-app-browser';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Camera } from '@ionic-native/camera';
import { IonicStorageModule } from '@ionic/storage';

import { ConferenceApp } from './app.component';
import { Geolocation } from '@ionic-native/geolocation';

import { DonHangPage } from '../pages/DonHangModule/donhang/donhang';
import {DonHangDetailPage} from '../pages/DonHangModule/don-hang-detail/don-hang-detail';
import {CreateDonHangPage} from '../pages/DonHangModule/create-don-hang/create-don-hang';
import {UpdateDonHangPage} from '../pages/DonHangModule/update-don-hang/update-don-hang';
import {DonHanGiaoHangPage} from '../pages/DonHangModule/don-han-giao-hang/don-han-giao-hang';
import {KienHangFormPage} from '../pages/kien-hang-form/kien-hang-form';

import { AboutPage } from '../pages/about/about';
import { AccountPage } from '../pages/TaiKhoanModule/account/account';
import { LoginPage } from '../pages/TaiKhoanModule/login/login';
import { MapPage } from '../pages/map/map';
import { SignupPage } from '../pages/TaiKhoanModule/signup/signup';
import { TabsPage } from '../pages/tabs-page/tabs-page';
import { SupportPage } from '../pages/support/support';

import { ConferenceData } from '../providers/conference-data';
import {HttpService} from '../providers/http_services';
import { UserData } from '../providers/user-data';
import { UserServices } from '../providers/user-services/user-services';
import { DonhangServicesProvider } from '../providers/donhang-services/donhang-services';


@NgModule({
  declarations: [
    ConferenceApp,
    AboutPage,
    AccountPage,
    LoginPage,
    MapPage,
    SignupPage,
    TabsPage,
    SupportPage,

    DonHangPage,
    DonHangDetailPage,
    CreateDonHangPage,
    UpdateDonHangPage,
    DonHanGiaoHangPage,

    KienHangFormPage
  ],
  imports: [
    BrowserModule,
    HttpModule,
    IonicModule.forRoot(ConferenceApp, {}, {
      links: [
        { component: TabsPage, name: 'TabsPage', segment: 'tabs-page' },
        { component: MapPage, name: 'Map', segment: 'map' },
        { component: AboutPage, name: 'About', segment: 'about' },
        { component: SupportPage, name: 'SupportPage', segment: 'support' },
        { component: LoginPage, name: 'LoginPage', segment: 'login' },
        { component: AccountPage, name: 'AccountPage', segment: 'account' },
        { component: SignupPage, name: 'SignupPage', segment: 'signup' },
        { component: DonHangPage, name: 'DonHangPage', segment: 'page-donhang' },
        { component: DonHangDetailPage, name: 'DonHangDetailPage', segment: 'page-donhang-details' }, 
        { component: CreateDonHangPage, name: 'CreateDonHangPage', segment: 'create-donhang' }, 
        { component: UpdateDonHangPage, name: 'UpdateDonHangPage', segment: 'update-donhang' },
        { component: KienHangFormPage, name: 'KienHangFormPage', segment: 'kienhang-form' }
      ]
    }),
    IonicStorageModule.forRoot()
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    ConferenceApp,
    AboutPage,
    AccountPage,
    LoginPage,
    MapPage,
    SignupPage,
    TabsPage,
    SupportPage,

    DonHangPage,
    DonHangDetailPage,
    CreateDonHangPage,
    UpdateDonHangPage,
    DonHanGiaoHangPage,
    KienHangFormPage
  ],
  providers: [
    Camera,
    { provide: ErrorHandler, useClass: IonicErrorHandler },
    HttpService,
    ConferenceData,
    UserData,
    InAppBrowser,
    SplashScreen,
    Geolocation,
    UserServices,
    DonhangServicesProvider
   
  ]
})
export class AppModule { }
