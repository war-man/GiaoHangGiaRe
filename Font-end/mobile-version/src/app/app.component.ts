import { Component, ViewChild } from '@angular/core';

import { Events, MenuController, Nav, Platform } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';

import { Storage } from '@ionic/storage';

import { AboutPage } from '../pages/about/about';
import { AccountPage } from '../pages/TaiKhoanModule/account/account';
import { LoginPage } from '../pages/TaiKhoanModule/login/login';
import { MapPage } from '../pages/map/map';
import { SignupPage } from '../pages/TaiKhoanModule/signup/signup';
import { TabsPage } from '../pages/tabs-page/tabs-page';
import { SupportPage } from '../pages/support/support';
import { DonHangPage } from '../pages/DonHangModule/donhang/donhang';
import { DonHangGiaoHangPage } from '../pages/GiaoHangModule/don-hang-giao-hang/don-hang-giao-hang';
import { BangGiaPage } from '../pages/bang-gia/bang-gia';

import {DonHangWaittingPage} from '../pages/GiaoHangModule/don-hang-waitting/don-hang-waitting';
import {LichSuGiaoHangPage} from '../pages/GiaoHangModule/lich-su-giao-hang/lich-su-giao-hang';

import { ConferenceData } from '../providers/conference-data';
import { UserData } from '../providers/user-data';

export interface PageInterface {
  title: string;
  name: string;
  component: any;
  icon: string;
  logsOut?: boolean;
  index?: number;
  tabName?: string;
  tabComponent?: any;
}

@Component({
  templateUrl: 'app.template.html'
})
export class ConferenceApp {
  // the root nav is a child of the root app component
  // @ViewChild(Nav) gets a reference to the app's root nav
  @ViewChild(Nav) nav: Nav;
  GiaoHang = "GiaoHang";
  // List of pages that can be navigated to from the left menu
  // the left menu only works after login
  // the login page disables the left menu
  appPages: PageInterface[] = [
    { title: 'Bản đồ', name: 'TabsPage', component: TabsPage, tabComponent: MapPage, index: 0, icon: 'map' },
    { title: 'Giới thiệu', name: 'TabsPage', component: TabsPage, tabComponent: AboutPage, index: 1, icon: 'information-circle' }
  ];
  loggedInPages: PageInterface[] = [
    { title: 'Tài khoản', name: 'AccountPage', component: AccountPage, icon: 'person' },
    { title: 'Hỗ trợ', name: 'SupportPage', component: SupportPage, icon: 'help' },
    { title: 'Bảng giá tham khảo', name: 'BangGiaPage', component: BangGiaPage, icon: 'card' },
    { title: 'Đơn hàng', name: 'DonHangPage', component: DonHangPage, icon: 'information-circle' },
    { title: 'Đăng xuất', name: 'TabsPage', component: TabsPage, icon: 'log-out', logsOut: true }
  ];
  loggedInPagesGiaoHang: PageInterface[] = [
    { title: 'Tài khoản', name: 'AccountPage', component: AccountPage, icon: 'person' },
    { title: 'Hỗ trợ', name: 'SupportPage', component: SupportPage, icon: 'help' },
    { title: 'Bảng giá tham khảo', name: 'BangGiaPage', component: BangGiaPage, icon: 'card' },
    { title: 'Đơn hàng chờ', name: 'DonHangWaittingPage', component: DonHangWaittingPage, icon: 'cart' },
    { title: 'Đơn hàng tiếp nhận', name: 'DonHangGiaoHangPage', component: DonHangGiaoHangPage, icon: 'clipboard' },
    {title:'Lịch sử giao hàng', name: 'LichSuGiaoHangPage', component: LichSuGiaoHangPage, icon:'ios-code'},
    { title: 'Đăng xuất', name: 'TabsPage', component: TabsPage, icon: 'log-out', logsOut: true }
  ];
  loggedOutPages: PageInterface[] = [
    { title: 'Đăng nhập', name: 'LoginPage', component: LoginPage, icon: 'log-in' },
    { title: 'Hỗ trợ', name: 'SupportPage', component: SupportPage, icon: 'help' },
    { title: 'Bảng giá tham khảo', name: 'BangGiaPage', component: BangGiaPage, icon: 'card' },
    { title: 'Đăng ký', name: 'SignupPage', component: SignupPage, icon: 'person-add' }
  ];
  rootPage: any;

  constructor(
    public events: Events,
    public userData: UserData,
    public menu: MenuController,
    public platform: Platform,
    public confData: ConferenceData,
    public storage: Storage,
    public splashScreen: SplashScreen
  ) {

    // Check if the user has already seen the tutorial
    // load the conference data
    confData.load();

    // decide which menu items should be hidden by current login status stored in local storage
    this.userData.hasLoggedIn().then((hasLoggedIn) => {
      if (hasLoggedIn) {
        this.rootPage = AboutPage;
      } else {
        this.rootPage = LoginPage;
      }
      this.platformReady()
      this.userData.checkIsShip().then(isShip =>{
        this.enableMenu(hasLoggedIn === true, isShip=== true );
      })
      
    });
    this.enableMenu(true);

    this.listenToLoginEvents();
  }

  openPage(page: PageInterface) {
    let params = {};

    // the nav component was found using @ViewChild(Nav)
    // setRoot on the nav to remove previous pages and only have this page
    // we wouldn't want the back button to show in this scenario
    if (page.index) {
      params = { tabIndex: page.index };
    }

    // If we are already on tabs just change the selected tab
    // don't setRoot again, this maintains the history stack of the
    // tabs even if changing them from the menu
    if (this.nav.getActiveChildNavs().length && page.index != undefined) {
      this.nav.getActiveChildNavs()[0].select(page.index);
    } else {
      // Set the root of the nav with params if it's a tab index
      this.nav.setRoot(page.name, params).catch((err: any) => {
        console.log(`Didn't set nav root: ${err}`);
      });
    }

    if (page.logsOut === true) {
      // Give the menu time to close before changing to logged out
      this.userData.logout();
    }
  }

  listenToLoginEvents() {
    this.events.subscribe('user:login', () => {
      this.nav.setRoot(AboutPage);
      this.enableMenu(true);
    });

    this.events.subscribe('user:loginShipper', () => {
      this.nav.setRoot(AboutPage);
      this.enableMenu(true, true);
    });

    this.events.subscribe('user:signup', () => {
      this.enableMenu(true);
    });

    this.events.subscribe('user:logout', () => {
      this.nav.setRoot(LoginPage);
      this.enableMenu(false);
    });
  }

  enableMenu(loggedIn: boolean, shipper?: any) {
    this.menu.enable(loggedIn && shipper , 'loggedInPagesGiaoHang');
    this.menu.enable(loggedIn && !shipper, 'loggedInMenu');
    this.menu.enable(!loggedIn, 'loggedOutMenu');
  }

  platformReady() {
    // Call any initial plugins when ready
    this.platform.ready().then(() => {
      this.splashScreen.hide();
    });
  }

  isActive(page: PageInterface) {
    let childNav = this.nav.getActiveChildNavs()[0];

    // Tabs are a special case because they have their own navigation
    if (childNav) {
      if (childNav.getSelected() && childNav.getSelected().root === page.tabComponent) {
        return 'primary';
      }
      return;
    }

    if (this.nav.getActive() && this.nav.getActive().name === page.name) {
      return 'primary';
    }
    return;
  }
}
