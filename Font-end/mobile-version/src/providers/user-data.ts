import { Injectable } from '@angular/core';

import { Events } from 'ionic-angular';
import { Storage } from '@ionic/storage';


@Injectable()
export class UserData {
  _favorites: string[] = [];
  HAS_LOGGED_IN = 'hasLoggedIn';
  HAS_SEEN_TUTORIAL = 'hasSeenTutorial';

  constructor(
    public events: Events,
    public storage: Storage
  ) { }

  hasFavorite(sessionName: string): boolean {
    return (this._favorites.indexOf(sessionName) > -1);
  };

  addFavorite(sessionName: string): void {
    this._favorites.push(sessionName);
  };

  removeFavorite(sessionName: string): void {
    let index = this._favorites.indexOf(sessionName);
    if (index > -1) {
      this._favorites.splice(index, 1);
    }
  };

  login(user: any): void {
    this.storage.set(this.HAS_LOGGED_IN, true);
    this.setUser(JSON.parse(user.user));
    this.setUserAuth(user);
    var user1 = JSON.parse(user.user);
    let isShipper;
    for (let i = 0; i < user1.Roles.length; i++) {
      if (user1.Roles[i].RoleId == 'ship') {
        isShipper = true;
      }
    }
    if (isShipper) {
      this.events.publish('user:loginShipper');
    } else {
      this.events.publish('user:login');
    }
  };

  signup(user: string): void {
    this.storage.set(this.HAS_LOGGED_IN, true);
    this.setUser(user);
    this.events.publish('user:signup');
  };

  logout(): void {
    this.storage.remove(this.HAS_LOGGED_IN);
    this.storage.remove('user');
    this.events.publish('user:logout');
  };

  setUserAuth(userAuth: any): void {
    this.storage.set('userAuth', userAuth);
  }

  setUser(user: any): void {
    this.storage.set('user', user);
  };

  getUser(): Promise<any> {
    return this.storage.get('user').then((value) => {
      return value;
    });
  };

  getUserAuth(): Promise<any> {
    return this.storage.get('userAuth').then((userAuth) => {
      return userAuth;
    });
  };

  hasLoggedIn(): Promise<boolean> {
    return this.storage.get(this.HAS_LOGGED_IN).then((value) => {
      return value === true;
    });
  };

  checkIsShip(): Promise<boolean> {
    return this.getUser().then(user1 => {
      if(user1 && user1.Roles){
        for (let i = 0; i < user1.Roles.length; i++) {
          if (user1.Roles[i].RoleId == 'ship') {
            return true;
          }
        }
      }
      return false;
    })
  }

  checkHasSeenTutorial(): Promise<string> {
    return this.storage.get(this.HAS_SEEN_TUTORIAL).then((value) => {
      return value;
    });
  };
}
