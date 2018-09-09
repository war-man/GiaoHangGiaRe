//
//  UserInforViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/26/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire
import NVActivityIndicatorView

class UserInforViewController: UIViewController,UITableViewDelegate, UITableViewDataSource {
    var activityIndicatorView : NVActivityIndicatorView!
    var overlay : UIView?
    var listTask = ["User infor", "Đăng xuất"]
    @IBOutlet weak var tableUserView: UITableView!
    @IBOutlet weak var LoadingSpinner: UIActivityIndicatorView!
    var userInfo: User?
    override func viewDidLoad() {
        tableUserView.delegate = self
        tableUserView.dataSource = self
        initLoadingUI()
        getUserInfo()
        super.viewDidLoad()
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
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
    func getUserInfo() {
        //Start Loading
        activityIndicatorView.startAnimating()
        view.addSubview(overlay!)
        let host = "http://giaohanggiare.gearhostpreview.com/"
        let token = UserDefaults.standard.object(forKey: "access_token")
        let header: HTTPHeaders = ["Authorization":token as! String]
        Alamofire.request(host + "user/api/taikhoan/get-current-user", method: HTTPMethod.get, parameters: nil, encoding: JSONEncoding.default, headers: header).responseJSON { response in
            switch response.result {
            case .success:
                if response.result.value != nil{
                    if (UserDefaults.standard.object(forKey: "role")as! String == "shipper"){
                        self.listTask.append("Lịch sử giao hàng")
                        self.tableUserView.reloadData()
                    }
                }
                //Stop Loading
                self.activityIndicatorView.stopAnimating()
                self.overlay?.removeFromSuperview()
                break
            case .failure( _):
                //Stop Loading
                self.activityIndicatorView.stopAnimating()
                self.overlay?.removeFromSuperview()
                break
            }
        }
    }
    func convertToArray(str: String) -> [String]? {
        let data = str.data(using: .utf8)
        do {
            return try JSONSerialization.jsonObject(with: data!, options: []) as? [String]
        } catch {
            print(error.localizedDescription)
        }
        return nil
    }
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return listTask.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "UserViewCell", for: indexPath) as! UserViewTableViewCell
        cell.lblTitle?.text = listTask[indexPath.row]
        return cell
    }
    func tableView(_ tableView: UITableView, willSelectRowAt indexPath: IndexPath) -> IndexPath? {
        if indexPath.row == 1 {
            self.navigationController?.popToRootViewController(animated: true)
        }
        if indexPath.row == 0{ //Trang thong tin user
            let vc = self.storyboard?.instantiateViewController(withIdentifier: "UserDetailsView") as! UserDetailsViewController
            self.navigationController?.pushViewController(vc, animated: true)
        }
        if indexPath.row == 2{
            let vc = self.storyboard?.instantiateViewController(withIdentifier: "HistoryOrderView") as! HistoryOrderViewController
            self.navigationController?.pushViewController(vc, animated: true)
        }
        return indexPath
    }
}
