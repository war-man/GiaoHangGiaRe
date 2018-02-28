import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';

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
  constructor(private formBuilder: FormBuilder) {
    this.kienhangForm = this.formBuilder.group({
      first: ['', [Validators.required]],
      last: ['', [Validators.required]],
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
    this.kienhangForm.controls['first'].setValue(this.kienhang_array[i].first);
    this.kienhangForm.controls['last'].setValue(this.kienhang_array[i].last);
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

  }
}
