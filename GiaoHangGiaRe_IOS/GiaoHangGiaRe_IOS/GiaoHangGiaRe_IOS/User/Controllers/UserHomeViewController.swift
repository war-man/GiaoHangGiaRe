//
//  UserHomeViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire

class UserHomeViewController: UIViewController, UISearchBarDelegate,UITableViewDataSource,UITableViewDelegate {
    
    var listTask:[String] = ["Đơn hàng đang giao","Đơn hàng đang chờ","Đơn hàng hoàn thành","Đơn hàng bị huỷ","Tất cả"]
    var searchResult : [String] = []
    
    @IBOutlet weak var tableViewUserMain: UITableView!
    @IBOutlet weak var searchBar: UISearchBar!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        getDonHang()
        self.searchBar.delegate = self
        
        tableViewUserMain.delegate = self
        tableViewUserMain.dataSource = self
        // Do any additional setup after loading the view.
        searchResult = listTask
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    
    func searchBar(_ searchBar: UISearchBar, textDidChange searchText: String) {
        if searchText == "" {
            searchResult = listTask
        } else {
            searchResult.removeAll()
            for taks in listTask {
                if taks.lowercased().contains(searchText.lowercased()) {
                    searchResult.append(taks)
                }
            }
        }
        tableViewUserMain.reloadData()
    }
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return searchResult.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "UserMainCell", for: indexPath) as! UserMainTableViewCell
        cell.lblTitle.text = searchResult[indexPath.row]
        return cell
    }
    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        let vc = self.storyboard?.instantiateViewController(withIdentifier: "UserOrderViewController") as! UserOrderViewController
        switch indexPath.row {
        case 0:
            vc.TinhTrang = 4 //DangGiao = 4
            vc.title2 = "Đơn hàng đang giao"
            break
        case 1:
            vc.TinhTrang = 0 //dang cho = 4
            vc.title2 = "Đơn hàng đang chờ"
            break
        case 2:
            vc.TinhTrang = 6 //DangGiao = 4
            vc.title2 = "Đơn hàng hoàn thành"
            break
        case 3:
            vc.TinhTrang = -1 //Huy =. 1
            vc.title2 = "Đơn hàng bị huỷ"
            break
        case 4:
            vc.TinhTrang = -10
            vc.title2 = "Tất cả"
            break
        default:
            vc.TinhTrang = -10
            vc.title2 = "Tất cả"
            break
        }
        self.navigationController?.pushViewController( vc , animated: true)
    }

    func getDonHang() {
        let params = [
            "grant_type": "password"]
        Alamofire.request(root_host + "token", method: .post, parameters: params, encoding: URLEncoding.httpBody).responseJSON { response in
            switch(response.result) {
            case .success(_):
                if response.result.value != nil{
                        
                    }else{
                        self.alertMessager(title: "Không thể đăng nhập", message: "Tài khoản hoặc mật khẩu sai, hãy thử lại")
                    }
            case .failure(_):
                break
            }
        }
    }
}


