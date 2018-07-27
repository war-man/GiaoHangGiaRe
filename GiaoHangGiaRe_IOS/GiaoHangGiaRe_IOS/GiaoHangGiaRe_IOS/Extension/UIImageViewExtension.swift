//
//  UIImageViewExtension.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/27/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

extension UIImageView {
    func getImageFormUrl(url: String) {
        DispatchQueue.global().async {
            let urlLink = URL(string: url)
            
            if urlLink == nil {
                return
            }
            
            let data = try? Data(contentsOf: urlLink!)
            DispatchQueue.main.async {
                if data == nil{
                    return
                }
                self.image = UIImage(data: data!)
            }
        }
    }
    func getImageURL(url: URL) {
        DispatchQueue.global().async {
            
            if url == nil {
                return
            }
            
            let data = try? Data(contentsOf: url)
            DispatchQueue.main.async {
                if data == nil{
                    return
                }
                self.image = UIImage(data: data!)
            }
        }
    }
}
