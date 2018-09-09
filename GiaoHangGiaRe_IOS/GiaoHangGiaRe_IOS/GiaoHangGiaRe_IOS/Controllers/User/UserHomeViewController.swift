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
    
    var listTask:[String] = ["Đơn hàng đang giao","Đơn hàng đang chờ","Đơn hàng hoàn thành","Đơn hàng bị huỷ"]
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

    func getDonHang() {
        let host = "http://giaohanggiare.gearhostpreview.com/"
        let params = [
            "grant_type": "password"]
        Alamofire.request(host+"token", method: .post, parameters: params, encoding: URLEncoding.httpBody).responseJSON { response in
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


