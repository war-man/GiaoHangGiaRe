//
//  ShipperOrderCell.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 9/8/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

class ShipperOrderCell: UITableViewCell {

    @IBOutlet weak var lblHistoryOrderThoiDIemHuy: UILabel!
    @IBOutlet weak var lblHistoryOrderThoiDiemDatHang: UILabel!
    @IBOutlet weak var lblHistoryOrderDiaChiGui: UILabel!
    @IBOutlet weak var lblHistoryOrderDiaChiNhan: UILabel!
    @IBOutlet weak var btnHistoryOrderImage: UIImageView!
    @IBOutlet weak var btnChuyenTrangThai: UIButton!
    @IBOutlet weak var btnHuyDonHang: UIButton!
    @IBOutlet weak var DonHangImage: UIImageView!
    @IBOutlet weak var lblDiaChiGui: UILabel!
    @IBOutlet weak var lblDiaChiNhan: UILabel!
    @IBOutlet weak var btnThoiDiemNhanDonHang: UILabel!
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }

}
