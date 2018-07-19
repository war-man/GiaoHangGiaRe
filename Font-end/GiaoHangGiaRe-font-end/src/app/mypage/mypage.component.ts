import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mypage',
  templateUrl: './mypage.component.html',
  styleUrls: ['./mypage.component.scss']
})
export class MypageComponent implements OnInit {
  userProfile: any;
  constructor() {
    this.userProfile = JSON.parse(JSON.parse(localStorage.getItem('userProfile')).user);
  }
  ngOnInit() {
  }
}
