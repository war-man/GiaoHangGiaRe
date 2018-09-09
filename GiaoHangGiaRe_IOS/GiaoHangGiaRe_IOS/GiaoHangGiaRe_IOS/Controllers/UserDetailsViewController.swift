//
//  UserInfoViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 8/9/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire

class UserDetailsViewController: UIViewController, UITableViewDelegate,UITableViewDataSource {
    
    @IBOutlet weak var imageAvatar: UIImageView!
    @IBOutlet weak var tableViewUserDetails: UITableView!
    @IBOutlet weak var btnBack: UIButton!
    var user: UserDetails_Base? = nil
    override func viewDidLoad() {
        tableViewUserDetails.delegate = self
        tableViewUserDetails.dataSource = self
        getUserInfo()
        super.viewDidLoad()
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    func setvaule() {
        guard let imgUrl = user?.imageLink else {
            return;
        }
        imageAvatar.getImageFormUrl(url: imgUrl)
    }
    
    @IBAction func btnBackClicked(_ sender: Any) {
        self.navigationController?.popViewController(animated: true)
    }
    func getUserInfo() {
        let host = "http://giaohanggiare.gearhostpreview.com/"
        let token = UserDefaults.standard.object(forKey: "access_token")
        let header: HTTPHeaders = ["Authorization":token as! String]
        Alamofire.request(host + "user/api/taikhoan/get-current-user", method: HTTPMethod.get, parameters: nil, encoding: JSONEncoding.default, headers: header).responseData { (response) in
            if response.result.isSuccess{
                guard let res = response.result.value else{
                    return;
                }
                self.user = try! JSONDecoder().decode(UserDetails_Base.self, from: res)
                _ = self.user?.roles
                self.setvaule()
                self.tableViewUserDetails.reloadData()
                
            }else{
                return;
            }
        }
    }    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return 5
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "UserDetailsViewCell", for: indexPath) as! UserDetailsViewCell
        if indexPath.row == 0{
            cell.lblTitle.text = user?.tenTaiKhoan
        }
        if indexPath.row == 1{
            cell.lblTitle.text = user?.phoneNumber
        }
        if indexPath.row == 2{
            cell.lblTitle.text = user?.diaChi
        }
        if indexPath.row == 3{
            cell.lblTitle.text = user?.email
        }
        if indexPath.row == 4{
            cell.lblTitle.text = user?.hoTen
        }

        return cell
    }
}
