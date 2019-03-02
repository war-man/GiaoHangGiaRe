//
//  UserHomeViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire

class UserHomeViewController: UIViewController,UICollectionViewDelegate,UICollectionViewDataSource {
    @IBOutlet weak var collectionView: UICollectionView!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        collectionView.delegate = self
        collectionView.dataSource = self
    }
    func collectionView(_ collectionView: UICollectionView, numberOfItemsInSection section: Int) -> Int {
        return 5
    }
    func collectionView(_ collectionView: UICollectionView, cellForItemAt indexPath: IndexPath) -> UICollectionViewCell {
        let cell = collectionView.dequeueReusableCell(withReuseIdentifier: "CollectionCell", for: indexPath) as! HomeCollectionViewCell
        cell.ImageContent.layer.cornerRadius = 16.9
        var color:UIColor = UIColor.orange
        var title: String = "Tất cả"
        switch indexPath.row {
        case 0:
            color = UIColor.purple
            title = "Đơn hàng đang giao"
            cell.ImageIcon.image = #imageLiteral(resourceName: "danggiao")
        case 1:
            color = UIColor.orange
            title = "Đơn hàng đang chờ"
            cell.ImageIcon.image = #imageLiteral(resourceName: "dangcho")
        case 2:
            color = UIColor.magenta
            title = "Đơn hàng hoàn thành"
            cell.ImageIcon.image = #imageLiteral(resourceName: "hoanthanh")
        case 3:
            color = UIColor.blue
            title = "Đơn hàng bị huỷ"
            cell.ImageIcon.image = #imageLiteral(resourceName: "huy")
        case 4:
            color = UIColor.brown
            title = "Tất cả"
            cell.ImageIcon.image = #imageLiteral(resourceName: "dangcho")
        default:
            cell.ImageContent.backgroundColor = UIColor.orange
            title = "Tất cả"
            cell.ImageIcon.image = #imageLiteral(resourceName: "dangcho")
        }
        cell.ImageContent.backgroundColor = color
        cell.lblTitle.text = title
        
        return cell
    }
    func collectionView(_ collectionView: UICollectionView, didSelectItemAt indexPath: IndexPath) {
        let vc = self.storyboard?.instantiateViewController(withIdentifier: "UserOrderViewController") as! UserOrderViewController
        switch indexPath.row {
        case 0:
            vc.TinhTrang = 4 //DangGiao = 4
            vc.title2 = "Đơn hàng đang giao"
            break
        case 1:
            vc.TinhTrang = 0 //dang cho = 4
            vc.title2 = "Đơn hàng đang chờ"
            break
        case 2:
            vc.TinhTrang = 6 //DangGiao = 4
            vc.title2 = "Đơn hàng hoàn thành"
            break
        case 3:
            vc.TinhTrang = -1 //Huy =. 1
            vc.title2 = "Đơn hàng bị huỷ"
            break
        case 4:
            vc.TinhTrang = -10
            vc.title2 = "Tất cả"
            break
        default:
            vc.TinhTrang = -10
            vc.title2 = "Tất cả"
            break
        }
        self.navigationController?.pushViewController( vc , animated: true)
    }
}


