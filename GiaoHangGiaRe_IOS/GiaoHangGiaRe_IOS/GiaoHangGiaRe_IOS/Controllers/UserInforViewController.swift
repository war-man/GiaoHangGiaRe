//
//  UserInforViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire

class UserInforViewController: UIViewController,UITableViewDelegate, UITableViewDataSource {
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return listTask.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "UserViewCell", for: indexPath) as! UserViewTableViewCell
        cell.lblTitle?.text = listTask[indexPath.row]
//        cell.btnNext.addTarget(self, action: #selector(self.btnNext(sender:)), for: UIControlEvents.touchUpInside)
//        cell.btnNext.tag = indexPath.row
        return cell
    }
    func tableView(_ tableView: UITableView, willSelectRowAt indexPath: IndexPath) -> IndexPath? {
        if indexPath.row == (listTask.count-1 ){
            self.navigationController?.popToRootViewController(animated: true)
        }
        return indexPath
    }
//    @objc func btnNext (sender: UIButton){
//        alertMessager(title: "\(sender.tag)", message: "2")
//    }
    var listTask = ["User infor", "Đăng xuất"]
    @IBOutlet weak var tableUserView: UITableView!
    @IBOutlet weak var LoadingSpinner: UIActivityIndicatorView!
    var userInfo: User?
    override func viewDidLoad() {
        super.viewDidLoad()
        LoadingSpinner.startAnimating()
        getUserInfo()
        tableUserView.delegate = self
        tableUserView.dataSource = self
        self.LoadingSpinner.hidesWhenStopped = true
        DispatchQueue.main.asyncAfter(deadline: .now() + 2) {
            self.LoadingSpinner.stopAnimating()
            
        }
        // Do any additional setup after loading the view.
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func getUserInfo() {
        let host = "http://127.0.0.1:8080/"
        let token = UserDefaults.standard.object(forKey: "access_token")
        let header: HTTPHeaders = ["Authorization":token as! String]
        Alamofire.request(host + "user/api/taikhoan/get-current-user", method: HTTPMethod.get, parameters: nil, encoding: JSONEncoding.default, headers: header).responseJSON { response in
            switch response.result {
            case .success:
                if response.result.value != nil{
                    print(response.result.value!)
                }
                break
            case .failure(let error):
                print(error)
                break
            }
        }
    }    
}
