//
//  KienHangViewCell.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 8/10/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

class KienHangViewCell: UITableViewCell {
    @IBOutlet weak var lblNoiDung: UILabel!
    @IBOutlet weak var lblChieuDai: UILabel!
    @IBOutlet weak var lblChieuRong: UILabel!
    @IBOutlet weak var lblSoLuong: UILabel!
    @IBOutlet weak var lblTrongLuong: UILabel!
    @IBOutlet weak var lblMoTa: UILabel!
    
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }

}
