//
//  DonHangCreate.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 10/1/18.
//  Copyright © 2018 admin. All rights reserved.
//

import Foundation
struct DonHangModel {
    public var NguoiGui: String
    public var SoDienThoaiNguoiGui: String
    public var DiaChiGui: String
    
    public var NguoiNhan: String
    public var SoDienThoaiNguoiNhan: String
    public var DiaChiNhan: String
    public var GhiChu: String
    
    public var cod: Int
    func toJSON() -> [String: Any] {
        return [
            "NguoiGui": NguoiGui as Any,
            "SoDienThoaiNguoiGui": SoDienThoaiNguoiGui as Any,
            "DiaChiGui": DiaChiGui as Any,
            
            "NguoiNhan": NguoiNhan as Any,
            "SoDienThoaiNguoiNhan": SoDienThoaiNguoiNhan as Any,
            "DiaChiNhan": DiaChiNhan as Any,
            
            "GhiChu": GhiChu as Any,
            "cod": cod as Any
        ]
    }
}
