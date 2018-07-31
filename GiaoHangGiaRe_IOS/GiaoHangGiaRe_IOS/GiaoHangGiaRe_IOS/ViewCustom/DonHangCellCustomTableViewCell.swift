//
//  DonHangCellCustomTableViewCell.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/30/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

class DonHangCellCustomTableViewCell: UITableViewCell {

    
    @IBOutlet weak var imgtitleImage: UIImageView!
    @IBOutlet weak var lblDiaChiNhan: UILabel!
    @IBOutlet weak var lblDiaChiDen: UILabel!
    @IBOutlet weak var btnChiTiet: UIButton!
    @IBOutlet weak var lblThoiDiemTaoDH: UILabel!
    @IBOutlet weak var btnTiepNhan: UIButton!
    
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }

}
