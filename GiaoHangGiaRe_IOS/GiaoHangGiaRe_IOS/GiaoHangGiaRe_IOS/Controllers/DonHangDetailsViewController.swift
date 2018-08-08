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
        cell.lblTenNguoiGui.text = "nguoi gui"
        cell.lblSDTNguoiGui.text = "sdt"
        cell.lblDiaChiGui.text = "dia chi"
        return cell
    }
    
    //api goi
    private func getDonHangDetail() {
        let token = UserDefaults.standard.object(forKey: "access_token")
        let host = "http://127.0.0.1:8080/"
        let params = [
            "id": self.MaDonHang!]
        let header: HTTPHeaders = ["Authorization":token as! String]
        Alamofire.request(host+"api/donhang/get-by-id", method: .get, parameters: params, encoding: URLEncoding.queryString, headers: header).responseData { (response) in
            response.result.ifSuccess {
                print(response.result)
                if let data = response.result.value {
                    print(data)
                }
            }
            response.result.ifFailure {
                print(response.result.error ?? "0")
            }

        }
    }
}
