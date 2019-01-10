//
//  TaiKhoanApi.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/25/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire

class TaiKhoanApi {
    let host = "http://localhost:8080"
    func DangNhap(){
        Alamofire.request(host + "/token").validate().responseJSON { response in
            switch response.result {
            case .success:
                print("Validation Successful")
            case .failure(let error):
                print(error)
            }
        }
    }
    func DangKy(){
        Alamofire.request(host + "/token").validate().responseJSON { response in
            switch response.result {
            case .success:
                print("Validation Successful")
            case .failure(let error):
                print(error)
            }
        }
    }
}
