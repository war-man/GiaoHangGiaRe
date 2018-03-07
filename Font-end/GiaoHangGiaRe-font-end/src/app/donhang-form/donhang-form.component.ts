import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { DonHangService } from '../../providers/donhang_service/donhang.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-donhang-form',
  templateUrl: './donhang-form.component.html',
  styleUrls: ['./donhang-form.component.css']
})
export class DonhangFormComponent implements OnInit {
  id: number;
  private sub: any;
  kienhangForm: FormGroup;
  donhangForm: FormGroup;
  DonHang = {
    NguoiGui: '',
    SoDienThoaiNguoiGui: '',DiaChiGui: '',NguoiNhan: '',SoDienThoaiNhan: '',DiaChiNhan: '',GhiChu: '', ThanhTien: ''
  };
  kienhang_array = [];
  selected_kienhang: any;
  isCreate = true;
  donHangCreate = true;
  constructor(private formBuilder: FormBuilder, private donhang_Service: DonHangService,
    private router: Router, private route: ActivatedRoute) {
      this.sub = this.route.params.subscribe(params => {
        this.id = +params['id']; 

      if (this.id) {
        this.donhang_Service.getDonHangDetails(params['id']).then(res => {
          if (res.kienhang) {
            this.kienhang_array = res.kienhang;
          }
          this.DonHang = res.donhang;
          this.donhangForm.controls['nguoiGui'].setValue(this.DonHang.NguoiGui);
          this.donhangForm.controls['sdtNguoiGui'].setValue(this.DonHang.SoDienThoaiNguoiGui);
          this.donhangForm.controls['diaChiGui'].setValue(this.DonHang.DiaChiGui);
          this.donhangForm.controls['nguoiNhan'].setValue(this.DonHang.NguoiNhan);
          this.donhangForm.controls['sdtNguoiNhan'].setValue(this.DonHang.SoDienThoaiNhan);
          this.donhangForm.controls['diaChiNhan'].setValue(this.DonHang.DiaChiNhan);
          this.donhangForm.controls['ghiChu'].setValue(this.DonHang.GhiChu);
          this.donhangForm.controls['thanhTien'].setValue(this.DonHang.ThanhTien);
        })
        this.donHangCreate = false;
      }else{
        this.donHangCreate = true;
      }
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
    this.kienhangForm = this.formBuilder.group({
      TrongLuong: ['', [Validators.required]],
      ChieuDai: [''],
      ChieuRong: [''],
      MoTa: ['', [Validators.required]],
      SoLuong: ['', [Validators.required]],
      NoiDung: ['', [Validators.required]],
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
    if (this.donhangForm.valid) {
      this.donhang_Service.taoDonHang({ donHang: this.donhangForm.value, kienHang: this.kienhang_array }).then(res => {
        console.log(res);
        this.router.navigateByUrl('/donhang');
      })
    }
  }
  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
