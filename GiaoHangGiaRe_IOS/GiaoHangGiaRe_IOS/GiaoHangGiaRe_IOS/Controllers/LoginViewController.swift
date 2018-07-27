//
//  LoginViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/24/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire
import SwiftyJSON

class LoginViewController: UIViewController {
    
    @IBOutlet weak var loadingSpinner: UIActivityIndicatorView!
    @IBOutlet weak var viewContent: UIView!
    @IBOutlet weak var tfTenTaiKhoan: UITextField!
    @IBOutlet weak var tfMatKhau: UITextField!
    @IBOutlet weak var btnDangNhap: UIButton!
    @IBOutlet weak var btnDangKy: UIButton!
    @IBOutlet weak var lblError: UILabel!
    override func viewDidLoad() {
        super.viewDidLoad()
        viewContent.layer.cornerRadius = 5
        // Do any additional setup after loading the view.
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    @IBAction func tfTenTaiKhoanChanged(_ sender: Any) {
//        if tfTenTaiKhoan.text!.count < 6{
//            lblError.text = "Tên tài khoản tối thiểu 6 ký tự."
//        }
    }
    func validate()->Bool {
        if tfTenTaiKhoan.text!.count == 0 {
            lblError.text = "Tên tài khoản tối thiểu 6 ký tự."
            return false;
        }else{
            if tfMatKhau.text!.count == 0 {
                lblError.text = "Mật khẩu không được để trống."
                return false;
            }
        }
        return true;
    }
    var user: User?
    @IBAction func btnDangNhap_Clicked(_ sender: Any) {
        if validate() {
            let host = "http://127.0.0.1:8080/"
            loadingSpinner.startAnimating()
            let params = [
                "grant_type": "password",
                "username": tfTenTaiKhoan.text!, "password": tfMatKhau.text!]
            
            Alamofire.request(host+"token", method: .post, parameters: params, encoding: URLEncoding.httpBody).responseJSON { response in
   
                switch(response.result) {
                    
                case .success(_):
                    if response.result.value != nil{
                        self.loadingSpinner.stopAnimating()
                        let statusCode = (response.response?.statusCode)!
                        let res = response.result.value! as! NSDictionary
                        
                        let access_token = res.object(forKey: "access_token")
                        let token_type = res.object(forKey: "token_type")
                        if (access_token != nil){
                            UserDefaults.standard.setValue("\(token_type) \(access_token)", forKey: "access_token")
                            
                            self.performSegue(withIdentifier: "gotoUserMainView", sender: nil)
                        }else{
                            self.alertMessager(title: "Không thể đăng nhập", message: "Tài khoản hoặc mật khẩu sai, hãy thử lại")
                        }

                    }else{
                        self.loadingSpinner.stopAnimating()
                         self.alertMessager(title: "Không thể đăng nhập", message: "Tài khoản hoặc mật khẩu sai, hãy thử lại")
                    }
                    break

                case .failure(_):
                    self.loadingSpinner.stopAnimating()
                    self.alertMessager(title: "Kết nối thất bại", message: "Hãy thử lại")
                    break
                }
            }
        
//            let number = 1
//            if number > 0{
//                   self.performSegue(withIdentifier: "gotoUserMainView", sender: nil)
//            }else{
//                self.performSegue(withIdentifier: "gotoShipperViewMain", sender: nil)
//            }
        }
    }
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        
    }
    @IBAction func btnDangKy_Clicked(_ sender: Any) {
    }
    /*
     // MARK: - Navigation
     
     // In a storyboard-based application, you will often want to do a little preparation before navigation
     override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
     // Get the new view controller using segue.destinationViewController.
     // Pass the selected object to the new view controller.
     }
     */
    
}
