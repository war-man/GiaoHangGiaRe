//
//  WaittingOrderViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire
import NVActivityIndicatorView

class WaittingOrderViewController: UIViewController, UITableViewDelegate, UITableViewDataSource {
   
    @IBOutlet weak var tableDonHangCho: UITableView!
    var listDonHang : [DonHangList] = []
    var overlay : UIView?
    var activityIndicatorView : NVActivityIndicatorView!
    var refreshControl: UIRefreshControl?
    override func viewDidLoad() {
        super.viewDidLoad()
        tableDonHangCho.delegate = self
        tableDonHangCho.dataSource = self
        addUIRefreshControl()
        initLoadingUI()
        getDonHang()
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if segue.identifier == "registerSegue"{
            _ = segue.destination as? DonHangDetailsViewController
        }
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
    func addUIRefreshControl() {
        refreshControl = UIRefreshControl()
        refreshControl?.tintColor = UIColor.orange
        refreshControl?.addTarget(self, action: #selector(getDonHang), for: .valueChanged)
        tableDonHangCho.addSubview(refreshControl!)
    }
    @objc private func getDonHang() {
        //Start loading
        activityIndicatorView.startAnimating()
        view.addSubview(overlay!)
        
        let token = UserDefaults.standard.object(forKey: "access_token")
        let host = "http://giaohanggiare.gearhostpreview.com/"
        let params = [
            "TinhTrang": 7,
            "size": 15]
        let header: HTTPHeaders = ["Authorization":token as! String]
        
        Alamofire.request(host+"api/donhang/get-all", method: .post, parameters: params, encoding: URLEncoding.httpBody, headers: header).responseData { (response) in
            
            if let data = response.result.value {
                let list = try? JSONDecoder().decode(DonHang.self, from: data)
                self.listDonHang = (list?.list)!
                //Stop loading
                self.activityIndicatorView.stopAnimating()
                self.overlay?.removeFromSuperview()
                self.refreshControl?.endRefreshing()
                DispatchQueue.main.async {
                    self.tableDonHangCho.reloadData()
                }
            }
        }
    }
    private func tiepNhanDonHang(MaDonHang: Int) {
        //Start loading
        activityIndicatorView.startAnimating()
        view.addSubview(overlay!)
        let token = UserDefaults.standard.object(forKey: "access_token")
        let host = "http://giaohanggiare.gearhostpreview.com/"
        let params = [
            "MaDonHang": MaDonHang]
        let header: HTTPHeaders = ["Authorization":token as! String]
        
        Alamofire.request(host+"api/donhang/tiep-nhan-don-hang", method: .put, parameters: params, encoding: URLEncoding(destination: .queryString), headers: header).responseJSON{ (response) in
            switch(response.result) {
            case .success(_):
                //Stop loading
                self.activityIndicatorView.stopAnimating()
                self.overlay?.removeFromSuperview()
                
                self.getDonHang()
                _ = response.result.value
                self.alertMessager(title: "Thông báo", message: "Đã tiếp nhận đơn hàng thành công đơn hàng.")
                break
            case .failure(_):
                //Stop loading
                self.activityIndicatorView.stopAnimating()
                self.overlay?.removeFromSuperview()
                break
            }
        }
    }
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return listDonHang.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "DonHangChoCell", for: indexPath) as! DonHangCellCustomTableViewCell
        cell.btnChiTiet.addTarget(self, action: #selector(self.btnChiTiet(sender:)), for: UIControlEvents.touchUpInside)
        cell.btnTiepNhan.addTarget(self, action: #selector(self.btnTiepNhanDonHang(sender:)), for: UIControlEvents.touchUpInside)
        cell.btnChiTiet.tag = indexPath.row
        cell.btnTiepNhan.tag = listDonHang[indexPath.row].maDonHang!
        cell.lblDiaChiDen.text = listDonHang[indexPath.row].diaChiNhan
        return cell
    }
    @objc func btnChiTiet (sender: UIButton){
        let vc = self.storyboard?.instantiateViewController(withIdentifier: "DonHangDetailsViewController") as! DonHangDetailsViewController
        vc.MaDonHang = sender.tag
        self.navigationController?.pushViewController( vc , animated: true)
    }
    @objc func btnTiepNhanDonHang (sender: UIButton){
        tiepNhanDonHang(MaDonHang: sender.tag)
    }
}
