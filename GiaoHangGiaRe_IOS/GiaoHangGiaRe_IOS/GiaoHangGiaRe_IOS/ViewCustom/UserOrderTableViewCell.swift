//
//  UserOrderTableViewCell.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 9/16/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

class UserOrderTableViewCell: UITableViewCell {

    @IBOutlet weak var lblThoiDiemDatHang: UILabel!
    @IBOutlet weak var imageUserOrder: UIImageView!
    @IBOutlet weak var lblSoDienThoaiNhan: UILabel!
    @IBOutlet weak var lblDiaChiNhan: UILabel!
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }

}
