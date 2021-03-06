//
//  HistoryOrderViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 9/9/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire
import NVActivityIndicatorView

class HistoryOrderViewController: UIViewController, UITableViewDelegate, UITableViewDataSource {
    var activityIndicatorView : NVActivityIndicatorView!
    var overlay : UIView?
    
    @IBOutlet weak var btnBack: UIButton!
    var donhangList: [DonHangShip_Base] = []
    @IBOutlet weak var tableViewHistoryOrder: UITableView!
    var refreshControl: UIRefreshControl?
    override func viewDidLoad() {
        super.viewDidLoad()
        setupUI()
        addUIRefreshControl()
        getHistoryOrder()
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }

    @IBAction func btnBackAction(_ sender: Any) {
        navigationController?.popViewController(animated: true)
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return donhangList.count
    }
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "HistoryOrderCell", for: indexPath) as! HistoryOrderCell
        cell.imageTitie.layer.cornerRadius = 10
        guard let donhang = donhangList[indexPath.row].donHang else {
            return cell
        }
        cell.lblDiaChiGui.text = donhang.diaChiGui
        cell.lblDiaChiNhan.text = donhang.diaChiNhan
        cell.lblThoiDiemDatHang.text = donhang.thoiDiemDatDonHang
        cell.lblThanhTien.text = "\(donhang.thanhTien)"
        return cell
    }
    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        let storyboard = UIStoryboard(name: "Main", bundle: nil)
        let vc = storyboard.instantiateViewController(withIdentifier: "DonHangDetailsViewController") as! DonHangDetailsViewController
        vc.MaDonHang = donhangList[indexPath.row].donHang!.maDonHang
        self.navigationController?.pushViewController( vc , animated: true)
    }
}

// MARK: --
extension HistoryOrderViewController{
    func setupUI() {
        //Thêm loading
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
        refreshControl?.addTarget(self, action: #selector(getHistoryOrder), for: .valueChanged)
        tableViewHistoryOrder.addSubview(refreshControl!)
    }
     @objc func getHistoryOrder(){
        //Start Loading
        activityIndicatorView.startAnimating()
        view.addSubview(overlay!)
        
        let token = UserDefaults.standard.object(forKey: "access_token")
        let header: HTTPHeaders = ["Authorization":token as! String]
        Alamofire.request(root_host+"api/donhang/get-history-shipper", method: .get, encoding: URLEncoding.httpBody, headers: header).responseData { (response) in
            if response.result.isSuccess{
                if let data = response.result.value {
                    //Stop Loading
                    self.activityIndicatorView.stopAnimating()
                    self.overlay?.removeFromSuperview()
                    self.refreshControl?.endRefreshing()
                    
                    guard let base = try? JSONDecoder().decode([DonHangShip_Base].self, from: data)
                        else{
                            self.alertMessager(title: "Thông báo", message: "Dữ liệu bị lỗi")
                            return
                    }
                    self.donhangList = base;
                    
                    DispatchQueue.main.async {
                        self.tableViewHistoryOrder.reloadData()
                    }
                }
            }else{
                //Stop Loading
                self.activityIndicatorView.stopAnimating()
                self.overlay?.removeFromSuperview()
                self.refreshControl?.endRefreshing()
            }
        }
    }
}
