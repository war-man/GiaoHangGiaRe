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
    public var ChieuDai: Float
    public var ChieuRong: Float
    public var MoTa: String
    public var TrongLuong: Float
    public var SoLuong: Int
    
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
//    func getDictFormat() -> [String: String]{
//        
//        return ["firstName" : firstName!, "lastName" : lastName!, "email" : email!, "state" : state!]
//    }
}
