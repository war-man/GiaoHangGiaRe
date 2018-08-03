//
//  GHButton.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 8/2/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

@IBDesignable
class GHButton: UIButton {
    
    var borderWidth = 2.0
    var borderColor = UIColor.white.cgColor
    
    
    
    var titleText: String? {
        didSet {
            self.setTitle(titleText, for: .normal)
            self.setTitleColor(UIColor.black, for: .normal)
        }
    }
    override init(frame: CGRect){
        super.init(frame: frame)
    }
    
    required init?(coder aDecoder: NSCoder) {
        super.init(coder: aDecoder)
    }
    override func layoutSubviews() {
        setup()
    }
    
    func setup() {
        self.clipsToBounds = true
        self.layer.cornerRadius = self.frame.size.width / 2.0
        self.layer.borderColor = borderColor
        self.layer.borderWidth = CGFloat(borderWidth)
    }
    /*
    // Only override draw() if you perform custom drawing.
    // An empty implementation adversely affects performance during animation.
    override func draw(_ rect: CGRect) {
        // Drawing code
    }
    */

}
