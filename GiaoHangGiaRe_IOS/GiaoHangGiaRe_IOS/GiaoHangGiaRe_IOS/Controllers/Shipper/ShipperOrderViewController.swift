//
//  ShipperOrderViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 9/7/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire
import NVActivityIndicatorView

class ShipperOrderViewController: UIViewController,UITableViewDataSource,UITableViewDelegate {
    var activityIndicatorView : NVActivityIndicatorView!
    var overlay : UIView?
    @IBOutlet weak var tableViewShipperOrder: UITableView!
    var donhangList: [Json4Swift_Base] = []
    override func viewDidLoad() {
        tableViewShipperOrder.delegate = self
        tableViewShipperOrder.dataSource = self
        initLoadingUI()
        super.viewDidLoad()
        getDonHangTiepNhan()
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    func initLoadingUI() {
        let xAxis = self.view.center.x
        let yAxis = self.view.center.y
        let frame = CGRect(x: (xAxis - 25), y: (yAxis - 35), width: 50, height: 50)
        activityIndicatorView = NVActivityIndicatorView(frame: frame)
        activityIndicatorView.type = . ballClipRotate // add your type
        activityIndicatorView.color = UIColor.orange // add your color
        overlay = UIView(frame: view.frame)
        overlay?.backgroundColor = UIColor.black
        overlay?.alpha = 0.3
        self.view.addSubview(activityIndicatorView)
    }
    func getDonHangTiepNhan(){
        //Start Loading
        activityIndicatorView.startAnimating()
        view.addSubview(overlay!)
        let token = UserDefaults.standard.object(forKey: "access_token")
        let host = "http://giaohanggiare.gearhostpreview.com/"
        let header: HTTPHeaders = ["Authorization":token as! String]
        
        Alamofire.request(host+"api/donhang/get-current-shipper", method: .get, encoding: URLEncoding.httpBody, headers: header).responseData { (response) in
            if response.result.isSuccess{
                if let data = response.result.value {
                    let base = try? JSONDecoder().decode([Json4Swift_Base].self, from: data)
                    self.donhangList = base!;
                    //Stop Loading
                    self.activityIndicatorView.stopAnimating()
                    self.overlay?.removeFromSuperview()
                    
                    DispatchQueue.main.async {
                        self.tableViewShipperOrder.reloadData()
                    }
                }
            }
        }
    }
    @objc func btnChuyenTrangThai (sender: UIButton){
        if donhangList[sender.tag].donHang?.tinhTrang == 1{
            self.alertMessager(title: "Chuyển trạng thái", message: "Đơn hàng sẽ chuyển trạng thái \"ĐANG LẤY HÀNG\"")
            tableViewShipperOrder.reloadData()
        }
        if donhangList[sender.tag].donHang?.tinhTrang == 2{
            self.alertMessager(title: "Chuyển trạng thái", message: "Đơn hàng sẽ chuyển trạng thái \"ĐANG GIAO\"")
            tableViewShipperOrder.reloadData()
        }
    }
    @objc func btnHuyDonHang (sender: UIButton){
        self.alertMessager(title: "Huỷ đơn hàng", message: "Đơn hàng sẽ được huỷ !")
        tableViewShipperOrder.reloadData()
    }
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return donhangList.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "DonHangTiepNhanCell", for: indexPath) as! ShipperOrderCell
        cell.lblDiaChiGui.text = donhangList[indexPath.row].donHang?.diaChiGui
        cell.lblDiaChiNhan.text = donhangList[indexPath.row].donHang?.diaChiNhan
         cell.btnChuyenTrangThai.tag = indexPath.row
        cell.btnHuyDonHang.tag = indexPath.row
        cell.btnThoiDiemNhanDonHang.text = donhangList[indexPath.row].donHang?.thoiDiemTiepNhanDon
        cell.btnChuyenTrangThai.addTarget(self, action: #selector(self.btnChuyenTrangThai(sender:)), for: UIControlEvents.touchUpInside)
        cell.btnHuyDonHang.addTarget(self, action: #selector(self.btnHuyDonHang(sender:)), for: UIControlEvents.touchUpInside)
        if donhangList[indexPath.row].donHang?.tinhTrang == 1{
            cell.btnChuyenTrangThai.setTitle("Lấy hàng", for: .normal) // Đơn hàng đã tiếp nhận. Hiển thị btn lấy hàng
        }
        if donhangList[indexPath.row].donHang?.tinhTrang == 2{
            cell.btnChuyenTrangThai.setTitle("Giao", for: .normal) // Trạng thái: Nhân viên đi lấy hàng
        }
        return cell
    }
    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        let vc = self.storyboard?.instantiateViewController(withIdentifier: "DonHangDetailsViewController") as! DonHangDetailsViewController
        vc.MaDonHang = donhangList[indexPath.row].donHang?.maDonHang
        self.navigationController?.pushViewController( vc , animated: true)
    }
}
