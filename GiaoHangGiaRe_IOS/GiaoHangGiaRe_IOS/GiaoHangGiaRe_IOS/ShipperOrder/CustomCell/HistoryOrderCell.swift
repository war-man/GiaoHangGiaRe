//
//  HistoryOrderCell.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 2/22/19.
//  Copyright © 2019 admin. All rights reserved.
//

import UIKit

class HistoryOrderCell: UITableViewCell {

    @IBOutlet weak var lblDiaChiGui: UILabel!
    @IBOutlet weak var lblDiaChiNhan: UILabel!
    @IBOutlet weak var imageTitie: UIImageView!
    @IBOutlet weak var lblThoiDiemDatHang: UILabel!
    @IBOutlet weak var lblThanhTien: UILabel!
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }

}
