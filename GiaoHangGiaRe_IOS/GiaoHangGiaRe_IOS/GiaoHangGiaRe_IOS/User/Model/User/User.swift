//
//  User.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/27/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

struct User: Decodable {
    let Roles : [String]
    let ImageLink: String
    let TenTaiKhoan: String
    let Email: String
    let PhoneNumber: String
    let HoTen: String
    let DiaChi: String
}
