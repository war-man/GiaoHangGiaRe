//
//  DonHangDetailsViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/31/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire

class DonHangDetailsViewController: UIViewController,UICollectionViewDelegate,UICollectionViewDataSource {
    var MaDonHang: Int?
    @IBOutlet weak var lblTitle: UILabel!
    @IBOutlet weak var btnBack: UIButton!
    @IBOutlet weak var lblNoiDung: UILabel!
    @IBOutlet weak var lblMaDonHang: UILabel!
    @IBOutlet weak var collectionDonHangDetails: UICollectionView!
    var DonHangDetails: Donhang? = nil;
    var listKienHang: [Kienhang] = [];
    
    override func viewDidLoad() {
        collectionDonHangDetails.delegate = self
        collectionDonHangDetails.dataSource = self
        super.viewDidLoad()
        lblMaDonHang.text = "\(MaDonHang!)"
        if MaDonHang != nil{
            getDonHangDetail()
        }
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
        cell.layer.borderWidth = 2
        cell.layer.borderColor = UIColor.orange.cgColor
        
        cell.lblTenNguoiGui.text = DonHangDetails?.nguoiGui
        
        cell.lblSDTNguoiGui.text = DonHangDetails?.soDienThoaiNguoiGui
        cell.lblDiaChiGui.text = DonHangDetails?.diaChiGui
        if indexPath.row == 0 {
            
            cell.lblDiaChiGui.text = "Presenting view controllers on detached view controllers is discouraged <GiaoHangGiaRe_IOS.LoginViewController: 0x7ff48d05e800>."
        }
        return cell
    }
    
    //api goi
    private func getDonHangDetail() {
        let token = UserDefaults.standard.object(forKey: "access_token")
        let host = "http://giaohanggiare.gearhostpreview.com/"
        let params = [
            "id": self.MaDonHang!]
        let header: HTTPHeaders = ["Authorization":token as! String]
        Alamofire.request(host+"api/donhang/get-by-id", method: .get, parameters: params, encoding: URLEncoding.queryString, headers: header).responseData { (response) in
            response.result.ifSuccess {
                if let data = response.result.value {
                    let jsbase = try? JSONDecoder().decode(DonHangDetais_Base.self, from: data)
                    guard let dh = jsbase?.donhang else{
                        return;
                    }
                    guard let kh = jsbase?.kienhang else {
                        return;
                    }
                    self.listKienHang = kh
                    self.DonHangDetails = dh
                    self.lblNoiDung.text = dh.ghiChu
                    self.collectionDonHangDetails.reloadData()
                }
            }
            response.result.ifFailure {
                print(response.result.error ?? "0")
            }
            
        }
    }
}
