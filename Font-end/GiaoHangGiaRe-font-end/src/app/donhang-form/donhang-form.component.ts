import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { DonHangService } from '../../providers/donhang_service/donhang.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-donhang-form',
  templateUrl: './donhang-form.component.html',
  styleUrls: ['./donhang-form.component.css']
})
export class DonhangFormComponent implements OnInit {
  kienhangForm: FormGroup;
  donhangForm: FormGroup;
  kienhang_array = [];
  selected_kienhang: any;
  isCreate = true;
  constructor(private formBuilder: FormBuilder, private donhang_Service: DonHangService,
    private router: Router) {
    this.kienhangForm = this.formBuilder.group({
      TrongLuong: ['', [Validators.required]],
      ChieuDai: [''],
      ChieuRong: [''],
      MoTa: ['', [Validators.required]],
      SoLuong: ['', [Validators.required]],
      NoiDung: ['', [Validators.required]],
    });

    this.donhangForm = this.formBuilder.group({
      nguoiGui: ['', [Validators.required]],
      sdtNguoiGui: ['', [Validators.required]],
      diaChiGui: ['', [Validators.required]],
      nguoiNhan: ['', [Validators.required]],
      sdtNguoiNhan: ['', [Validators.required]],
      diaChiNhan: ['', [Validators.required]],
      ghiChu: ['', [Validators.required]],
      thanhTien: ['', [Validators.required]],
    });

  }
  ngOnInit() {
  }
  deleteKienHang(i) {
    this.kienhang_array.splice(i, 1);
  }
  editKienHang(i, j) {
    this.isCreate = false;
    this.kienhangForm.controls['TrongLuong'].setValue(this.kienhang_array[i].TrongLuong);
    this.kienhangForm.controls['ChieuDai'].setValue(this.kienhang_array[i].ChieuDai);
    this.kienhangForm.controls['ChieuRong'].setValue(this.kienhang_array[i].ChieuRong);
    this.kienhangForm.controls['MoTa'].setValue(this.kienhang_array[i].MoTa);
    this.kienhangForm.controls['SoLuong'].setValue(this.kienhang_array[i].SoLuong);
    this.kienhangForm.controls['NoiDung'].setValue(this.kienhang_array[i].NoiDung);
    this.selected_kienhang = i;
  }
  updateData() {
    if (this.kienhangForm.valid) {
      this.kienhang_array[this.selected_kienhang] = this.kienhangForm.value;
      this.kienhangForm.reset();
    }
    this.isCreate = true;
  }
  submitData() {
    if (this.kienhangForm.valid) {
      this.kienhang_array = this.kienhang_array.concat(this.kienhangForm.value);
      this.kienhangForm.reset();
    }
  }
  submitDonHangData() {
    debugger
    if (this.donhangForm.valid) {
      this.donhang_Service.taoDonHang({ donHang: this.donhangForm.value, kienHang: this.kienhang_array }).then(res => {
        console.log(res);
        this.router.navigateByUrl('/donhang');
      })
    }
  }
}
