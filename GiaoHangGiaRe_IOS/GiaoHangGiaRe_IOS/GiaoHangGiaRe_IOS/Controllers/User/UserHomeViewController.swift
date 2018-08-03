//
//  UserHomeViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire

class UserHomeViewController: UIViewController, UISearchBarDelegate {

    @IBOutlet weak var searchBar: UISearchBar!
    override func viewDidLoad() {
        super.viewDidLoad()
        getDonHang()
        searchBar.delegate = self
        self.searchBar.delegate = self
        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    func getDonHang() {
        let host = "http://127.0.0.1:8080/"
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


