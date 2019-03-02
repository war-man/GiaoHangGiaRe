//
//  KienHang.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 8/10/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

struct KienHang {
    public var NoiDung: String
    public var ChieuDai: Int
    public var ChieuRong: Int
    public var MoTa: String
    public var TrongLuong: Int
    public var SoLuong: Int
//    "NoiDung":"Keo2","MoTa":"huhihi","TrongLuong":1,"ChieuRong":2,"ChieuDai":2,"SoLuong":1
    func toJSON() -> [String: Any] {
        return [
            "NoiDung": NoiDung as Any,
            "ChieuDai": ChieuDai as Any,
            "ChieuRong": ChieuRong as Any,
            
            "MoTa": MoTa as Any,
            "TrongLuong": TrongLuong as Any,
            "SoLuong": SoLuong as Any,
        ]
    }
}
