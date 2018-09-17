//
//  UserInfoViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 8/9/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire
import NVActivityIndicatorView

class UserDetailsViewController: UIViewController, UITableViewDelegate,UITableViewDataSource {
    
    @IBOutlet weak var imageAvatar: UIImageView!
    @IBOutlet weak var tableViewUserDetails: UITableView!
    @IBOutlet weak var btnBack: UIButton!
    var activityIndicatorView : NVActivityIndicatorView!
    var overlay : UIView?
    var user: UserDetails_Base? = nil
    override func viewDidLoad() {
        tableViewUserDetails.delegate = self
        tableViewUserDetails.dataSource = self
        initLoadingUI()
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
    @IBAction func btnBackClicked(_ sender: Any) {
        self.navigationController?.popViewController(animated: true)
    }
    func getUserInfo() {
        //Start Loading
        activityIndicatorView.startAnimating()
        view.addSubview(overlay!)
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
            //Stop Loading
            self.activityIndicatorView.stopAnimating()
            self.overlay?.removeFromSuperview()
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
