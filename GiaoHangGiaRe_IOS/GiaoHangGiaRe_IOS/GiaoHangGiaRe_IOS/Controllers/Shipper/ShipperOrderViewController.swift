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
    func changeTrangThaiDonHang(TrangThai: Int, MaDonHang: Int){
        //Start Loading
        activityIndicatorView.startAnimating()
        view.addSubview(overlay!)
        let token = UserDefaults.standard.object(forKey: "access_token")
        let host = "http://giaohanggiare.gearhostpreview.com/"
        let params = [
            "MaDonHang": MaDonHang]
        let header: HTTPHeaders = ["Authorization":token as! String]
        var url=""
        if TrangThai == 2{
            url = host+"api/donhang/lay-hang"
        }
        if TrangThai == 3{
            url = host+"api/donhang/lay-thanh-cong"
        }
        if TrangThai == -2{
            url = host+"api/donhang/khong-the-lay-hang"
        }
        Alamofire.request(url, method: .put, parameters: params, encoding: URLEncoding(destination: .queryString), headers: header).responseJSON{ (response) in
            switch(response.result) {
            case .success(_):
                //Stop Loading
                self.activityIndicatorView.stopAnimating()
                self.overlay?.removeFromSuperview()
                DispatchQueue.main.async { self.tableViewShipperOrder.reloadData() }
                break
            case .failure(_):
                break
            }
        }
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
            self.changeTrangThaiDonHang(TrangThai: 2,MaDonHang: (donhangList[sender.tag].donHang?.maDonHang)!)// Tinh Trang = 2 đang lấy hàng
            self.alertMessager(title: "Chuyển trạng thái", message: "Đơn hàng sẽ chuyển trạng thái \"ĐANG LẤY HÀNG\"")
        }
        if donhangList[sender.tag].donHang?.tinhTrang == 2{
            self.changeTrangThaiDonHang(TrangThai: 3,MaDonHang: (donhangList[sender.tag].donHang?.maDonHang)!)// Tinh Trang = 3 lấy hàng thành công
            self.alertMessager(title: "Chuyển trạng thái", message: "Đơn hàng sẽ chuyển trạng thái \"ĐANG GIAO\"")
        }
    }
    @objc func btnHuyDonHang (sender: UIButton){
        if donhangList[sender.tag].donHang?.tinhTrang == 1{
            //chuyen trang thai sang 4
            self.alertMessager(title: "Huỷ đơn hàng", message: "Đơn hàng sẽ được huỷ !")
            tableViewShipperOrder.reloadData()
        }
        if donhangList[sender.tag].donHang?.tinhTrang == 2 {
            self.changeTrangThaiDonHang(TrangThai: -2,MaDonHang: (donhangList[sender.tag].donHang?.maDonHang)!)// Tinh Trang = -2 khong the lay hang
            self.alertMessager(title: "Chuyển trạng thái", message: "Đơn hàng sẽ chuyển trạng thái \"KHÔNG THỂ LẤY HÀNG\"")
        }
       
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
            cell.btnChuyenTrangThai.setBackgroundImage(#imageLiteral(resourceName: "ok"), for: .normal) // Trạng thái: Nhân viên đi lấy hàng
            cell.btnChuyenTrangThai.setTitle("", for: .normal)
            cell.btnChuyenTrangThai.backgroundColor = UIColor.clear
            cell.btnChuyenTrangThai.frame = CGRect(x: cell.btnChuyenTrangThai.frame.minX, y: cell.btnChuyenTrangThai.frame.minY, width: 40, height: 40)
            
            cell.btnHuyDonHang.setTitle("", for: .normal)
            cell.btnHuyDonHang.setBackgroundImage(#imageLiteral(resourceName: "cancel"), for: .normal)
            cell.btnHuyDonHang.backgroundColor = UIColor.clear
            cell.btnHuyDonHang.frame = CGRect(x: cell.btnHuyDonHang.frame.minX, y: cell.btnHuyDonHang.frame.minY, width: 40, height: 40)
        }
        if donhangList[indexPath.row].donHang?.tinhTrang == -2{
            cell.btnChuyenTrangThai.isHidden = true
            cell.btnHuyDonHang.isHidden = true
            cell.backgroundColor = UIColor.gray
        }
        return cell
    }
    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        let vc = self.storyboard?.instantiateViewController(withIdentifier: "DonHangDetailsViewController") as! DonHangDetailsViewController
        vc.MaDonHang = donhangList[indexPath.row].donHang?.maDonHang
        self.navigationController?.pushViewController( vc , animated: true)
    }
}
