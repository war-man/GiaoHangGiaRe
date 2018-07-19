import { Component, OnInit } from '@angular/core';
import { Router, Params, Route, ActivatedRoute } from '@angular/router';
import {DonHangService} from '../../providers/donhang_service/donhang.service';
import { DataService } from '../../providers/data_services';

@Component({
  selector: 'app-don-hang-details',
  templateUrl: './don-hang-details.component.html',
  styleUrls: ['./don-hang-details.component.scss']
})
export class DonHangDetailsComponent implements OnInit {
  DonHang: any;
  kienhang_array: any;
  id: number;
  private sub: any;
  constructor(private router: Router, private route: ActivatedRoute,
    private donhang_Service: DonHangService) {
   
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; 
    })
  this.donhang_Service.getDonHangDetails(this.id).then(res=>{
      console.log(res);
      if (res.kienhang) {
        this.kienhang_array = res.kienhang;
      }
      this.DonHang = res.donhang;
    })
  }

  ngOnInit() {
  }
  editDonHang(id) {
    // this.router.navigateByUrl('/donhang-them', {});
    this.router.navigate(['/donhang-them',id]);
  }
  theoDoiDonHang(id) {

  }
  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
