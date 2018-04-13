import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../providers/login_service/login.service';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  model = { username: '', password: '' };
  userData: any;
  login_err: any;
  base64textString = "";
  registerForm: FormGroup;
  constructor(private loginService: LoginService, private router: Router, private formBuilder: FormBuilder) {
    this.registerForm = this.formBuilder.group({
      TenTaiKhoan: ['', [Validators.required]],
      HoTen: ['', [Validators.required]],
      DiaChi: ['', [Validators.required]],
      SoDienThoai: ['', [Validators.required]],
      Email: ['', [Validators.required]],
      Password: ['', [Validators.required]],
      ConfirmPassword: ['', [Validators.required]]
    });
    this.registerForm.valueChanges.subscribe(()=>{
    })
  }
  ngOnInit() {

  }
  submitData() {
    if (this.registerForm.valid) {
      if (this.registerForm.value.Password == this.registerForm.value.ConfirmPassword) {
        // this.registerForm.value.Base64 = this.base64textString;
        this.loginService.register(this.registerForm.value).then((res) => {
          if (res) {
            window.location.reload();
          }
        }, err => {
          this.login_err = err.error_description;
        });
      } else {
        this.login_err = 'Mật khẩu xác nhận không trùng khớp.';
      }

    }
  }

  handleFileSelect(evt) {
    let files = evt.target.files;
    if (files && files[0]) {
      var reader = new FileReader();
      reader.onload = this._handleReaderLoaded.bind(this);
      reader.readAsBinaryString(files[0]);
    }
  }
  _handleReaderLoaded(readerEvt) {
    //let binaryString = readerEvt.target.result;
    //this.registerForm.value.Base64 = btoa(binaryString);
    //console.log(this.registerForm.value.Base64);
    this.base64textString = btoa(readerEvt.target.result);
    //let review = document.getElementById('blah');
    //review.setAttribute('src', readerEvt.target.result);

    //var img = document.createElement("img");
    //img.src = readerEvt.target.result;
  }
}
