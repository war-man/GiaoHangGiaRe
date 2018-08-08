//
//  DonHangDetailsViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/31/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit

class DonHangDetailsViewController: UIViewController,UICollectionViewDelegate,UICollectionViewDataSource {
    
    var MaDonHang: Int?
    @IBOutlet weak var lblTitle: UILabel!
    @IBOutlet weak var btnBack: UIButton!
    
    
    @IBOutlet weak var lblNoiDung: UILabel!
    @IBOutlet weak var lblMaDonHang: UILabel!
    @IBOutlet weak var collectionDonHangDetails: UICollectionView!
    
    override func viewDidLoad() {
        collectionDonHangDetails.delegate = self
        collectionDonHangDetails.dataSource = self
        super.viewDidLoad()
        lblMaDonHang.text = "\(MaDonHang!)"
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    

    @IBAction func btnBack_Clicked(_ sender: Any) {
    self.navigationController?.popViewController(animated: true)
    }
    
    func collectionView(_ collectionView: UICollectionView, numberOfItemsInSection section: Int) -> Int {
        return 2
    }
    
    func collectionView(_ collectionView: UICollectionView, cellForItemAt indexPath: IndexPath) -> UICollectionViewCell {
        let cell = collectionView.dequeueReusableCell(withReuseIdentifier: "DetailsCollectionViewCell", for: indexPath) as! DetailDHCollectionViewCell
        cell.layer.borderWidth = 1
        cell.layer.borderColor = UIColor.orange.cgColor
        cell.lblTenNguoiGui.text = "nguoi gui"
        cell.lblSDTNguoiGui.text = "sdt"
        cell.lblDiaChiGui.text = "dia chi"
        return cell
    }
    
    //api goi
}
