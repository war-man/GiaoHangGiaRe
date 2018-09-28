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

class DonHangDetailsViewController: UIViewController,UITableViewDelegate,UITableViewDataSource {
    
    var MaDonHang: Int?
    @IBOutlet weak var lblTitle: UILabel!
    @IBOutlet weak var btnBack: UIButton!
    @IBOutlet weak var lblNoiDung: UILabel!
    @IBOutlet weak var lblMaDonHang: UILabel!
    @IBOutlet weak var lblNguoiGui: UILabel!
    @IBOutlet weak var lblsdtGui: UILabel!
    @IBOutlet weak var lblDiaChiNguoiGui: UILabel!
    @IBOutlet weak var lblNguoiNhan: UILabel!
    @IBOutlet weak var lblSoDienThoaiNhan: UILabel!
    @IBOutlet weak var lblDiaChiNhan: UILabel!
    
    @IBOutlet weak var lblSoKienHang: UILabel!
    @IBOutlet weak var tableViewDonHangDetail: UITableView!
    var DonHangDetails: Donhang? = nil;
    var listKienHang: [Kienhang] = [];
    var overlay : UIView?
    var activityIndicatorView : NVActivityIndicatorView!
    
    override func viewDidLoad() {
        tableViewDonHangDetail.delegate = self
        tableViewDonHangDetail.dataSource = self
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
    //set data
    func setData() {
        lblNguoiGui.text = DonHangDetails?.nguoiGui
        lblsdtGui.text = DonHangDetails?.soDienThoaiNguoiGui
        lblDiaChiNguoiGui.text = DonHangDetails?.diaChiGui
        
        lblNguoiNhan.text = DonHangDetails?.nguoiNhan
        lblDiaChiNhan.text = DonHangDetails?.diaChiNhan
        lblSoDienThoaiNhan.text = DonHangDetails?.soDienThoaiNguoiNhan
        lblSoKienHang.text = "\(listKienHang.count)"
        tableViewDonHangDetail.reloadData()
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
                    guard let dh = jsbase?.donhang else{
                        self.alertMessager(title: "Thông báo", message: "Dữ liệu đơn hàng bị thiếu")
                        return;
                    }
                    guard let kh = jsbase?.kienhang else {
                        self.alertMessager(title: "Thông báo", message: "Dữ liệu kiện hàng bị thiếu")
                        return;
                    }
                    self.listKienHang = kh
                    self.DonHangDetails = dh

                    self.lblNoiDung.text = dh.ghiChu
                    DispatchQueue.main.async {
                        self.setData()
                    }

                }else{
                    //Stop loading
                    self.activityIndicatorView.stopAnimating()
                    self.overlay?.removeFromSuperview()
                }
            }
            response.result.ifFailure {
                print(response.result.error ?? "0")
                 self.alertMessager(title: "Thông báo", message: "Kết nối thất bại")
            }            
        }
    }
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return listKienHang.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "DonHangDetailsCell", for: indexPath) as! KienHangDetailsCell
        cell.lblNoiDung.text = listKienHang[indexPath.row].noiDung
        cell.lblDai.text = "\(listKienHang[indexPath.row].chieuDai!)"
        cell.lblRong.text = "\(listKienHang[indexPath.row].chieuRong!)"
        cell.lblKhoiLuong.text = "\(listKienHang[indexPath.row].trongLuong!)"
        cell.lblSoLuong.text = "\(listKienHang[indexPath.row].soLuong!)"
        return cell
    }
}
