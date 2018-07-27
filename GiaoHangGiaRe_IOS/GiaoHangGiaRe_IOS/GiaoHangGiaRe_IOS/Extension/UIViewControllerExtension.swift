//
//  UIViewControllerExtension.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/27/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

extension UIViewController{
    func alertMessager(title: String, message:String) {
        let alert = UIAlertController(title: title, message: message, preferredStyle: UIAlertControllerStyle.alert)
        alert.addAction(UIAlertAction(title: "Ok", style: UIAlertActionStyle.default, handler: nil))
        self.present(alert, animated: true, completion: nil)
    }
}
