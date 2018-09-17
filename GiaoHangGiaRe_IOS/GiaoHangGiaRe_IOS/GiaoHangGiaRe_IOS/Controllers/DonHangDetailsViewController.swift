//
//  DonHangDetailsViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/31/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire
import NVActivityIndicatorView

class DonHangDetailsViewController: UIViewController,UICollectionViewDelegate,UICollectionViewDataSource {
    var MaDonHang: Int?
    @IBOutlet weak var lblTitle: UILabel!
    @IBOutlet weak var btnBack: UIButton!
    @IBOutlet weak var lblNoiDung: UILabel!
    @IBOutlet weak var lblMaDonHang: UILabel!
    @IBOutlet weak var collectionDonHangDetails: UICollectionView!
    var DonHangDetails: Donhang? = nil;
    var listKienHang: [Kienhang] = [];
    var overlay : UIView?
    var activityIndicatorView : NVActivityIndicatorView!
    
    override func viewDidLoad() {
        collectionDonHangDetails.delegate = self
        collectionDonHangDetails.dataSource = self
        initLoadingUI()
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
    func initLoadingUI() {
        let xAxis = self.view.center.x // or use (view.frame.size.width / 2) // or use (faqWebView.frame.size.width / 2)
        let yAxis = self.view.center.y // or use (view.frame.size.height / 2) // or use (faqWebView.frame.size.height / 2)
        let frame = CGRect(x: (xAxis - 25), y: (yAxis - 35), width: 50, height: 50)
        activityIndicatorView = NVActivityIndicatorView(frame: frame)
        activityIndicatorView.type = . ballClipRotate // add your type
        activityIndicatorView.color = UIColor.orange // add your color
        overlay = UIView(frame: view.frame)
        overlay?.backgroundColor = UIColor.black
        overlay?.alpha = 0.3
        self.view.addSubview(activityIndicatorView)
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
       
        return cell
    }
    
    //api goi
    private func getDonHangDetail() {
        //Start loading
        activityIndicatorView.startAnimating()
        view.addSubview(overlay!)
        let token = UserDefaults.standard.object(forKey: "access_token")
        let host = "http://giaohanggiare.gearhostpreview.com/"
        let params = [
            "id": self.MaDonHang!]
        let header: HTTPHeaders = ["Authorization":token as! String]
        Alamofire.request(host+"api/donhang/get-by-id", method: .get, parameters: params, encoding: URLEncoding.queryString, headers: header).responseData { (response) in
            response.result.ifSuccess {
                if let data = response.result.value {
                    //Stop loading
                    self.activityIndicatorView.stopAnimating()
                    self.overlay?.removeFromSuperview()
                    
                    let jsbase = try? JSONDecoder().decode(DonHangDetais_Base.self, from: data)
//                    guard let dh = jsbase?.donhang else{
//                        return;
//                    }
//                    guard let kh = jsbase?.kienhang else {
//                        return;
//                    }
                    let dh = jsbase?.donhang
                    let kh = jsbase?.kienhang
                    if kh == nil {
                        self.listKienHang = []
                    }else{
                                            self.listKienHang = kh!
                    }
                    if dh == nil{
                        self.DonHangDetails = nil
                    }else{
                                            self.DonHangDetails = dh
                    }


                    self.lblNoiDung.text = dh?.ghiChu
                    DispatchQueue.main.async {
                        self.collectionDonHangDetails.reloadData()
                    }

                }else{
                    //Stop loading
                    self.activityIndicatorView.stopAnimating()
                    self.overlay?.removeFromSuperview()
                }
            }
            response.result.ifFailure {
                print(response.result.error ?? "0")
            }
            
        }
    }
}
