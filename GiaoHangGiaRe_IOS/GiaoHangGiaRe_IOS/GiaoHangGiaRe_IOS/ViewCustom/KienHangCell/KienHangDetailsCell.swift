//
//  KienHangDetailsCell.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 9/22/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

class KienHangDetailsCell: UITableViewCell {

    @IBOutlet weak var lblNoiDung: UILabel!
    @IBOutlet weak var lblDai: UILabel!
    @IBOutlet weak var lblRong: UILabel!
    @IBOutlet weak var lblKhoiLuong: UILabel!
    @IBOutlet weak var lblSoLuong: UILabel!
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }

}
