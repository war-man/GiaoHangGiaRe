//
//  UserOrderViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 9/15/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import NVActivityIndicatorView
import Alamofire

class UserOrderViewController: UIViewController,UITableViewDataSource,UITableViewDelegate  {
    @IBOutlet weak var lblTitle: UILabel!
    var TinhTrang: Int?
    var title2: String?
    var activityIndicatorView : NVActivityIndicatorView!
    var overlay : UIView?
    var refreshControl: UIRefreshControl?
    var listDonHang: [OrderUser] = []
    @IBOutlet weak var tableViewUserOrder: UITableView!
    override func viewDidLoad() {
        super.viewDidLoad()
        lblTitle.text = title2
        tableViewUserOrder.delegate = self
        tableViewUserOrder.dataSource = self
        initLoadingUI()
        addUIRefreshControl()
        getDonHang()
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    @IBAction func btnBackAction(_ sender: Any) {
        navigationController?.popViewController(animated: true)
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
        tableViewUserOrder.addSubview(refreshControl!)
    }
    @objc func getDonHang() {
        //Start Loading
        activityIndicatorView.startAnimating()
        view.addSubview(overlay!)
        let token = UserDefaults.standard.object(forKey: "access_token")
        let host = "http://giaohanggiare.gearhostpreview.com/"
        let params = [
            "TinhTrang": TinhTrang]
        let header: HTTPHeaders = ["Authorization":token as! String]
        
        Alamofire.request(host+"api/donhang/get-donhang-curent-user", method: .get, parameters: params, encoding: URLEncoding(destination: .queryString), headers: header).responseData{ (response) in
            switch(response.result) {
            case .success(_):
            if let data = response.result.value {
                let list = try? JSONDecoder().decode([OrderUser].self, from: data)
                self.listDonHang = list!
               
                //Stop Loading
                self.activityIndicatorView.stopAnimating()
                self.overlay?.removeFromSuperview()
                self.refreshControl?.endRefreshing()
                DispatchQueue.main.async {
                    self.tableViewUserOrder.reloadData()
                }
            }
                break
            case .failure(_):
                //Stop Loading
                self.activityIndicatorView.stopAnimating()
                self.overlay?.removeFromSuperview()
                self.refreshControl?.endRefreshing()
                break
            }
        }
      
    }
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return listDonHang.count
    }

    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "UserOrderCell", for: indexPath) as! UserOrderTableViewCell
        cell.lblThoiDiemDatHang.text = listDonHang[indexPath.row].thoiDiemDatDonHang
        cell.lblDiaChiNhan.text = listDonHang[indexPath.row].diaChiNhan
        cell.lblSoDienThoaiNhan.text = listDonHang[indexPath.row].soDienThoaiNguoiNhan
        cell.imageUserOrder.image = UIImage(named: "box")
        return cell
    }
    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        let vc = self.storyboard?.instantiateViewController(withIdentifier: "DonHangDetailsViewController") as! DonHangDetailsViewController
        vc.MaDonHang = listDonHang[indexPath.row].maDonHang
        self.navigationController?.pushViewController( vc , animated: true)
    }
}
