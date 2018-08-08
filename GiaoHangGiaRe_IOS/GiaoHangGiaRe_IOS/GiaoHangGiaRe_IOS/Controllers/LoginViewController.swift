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

class LoginViewController: UIViewController, RegisterViewControlleDelegete {
    
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
        checkLogined()
        // Do any additional setup after loading the view.
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    @IBAction func tfTenTaiKhoanChanged(_ sender: Any) {
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
    func checkLogined() {
        guard  let token = UserDefaults.standard.object(forKey: "access_token") else {
            return
        }
//        print(token)
        alertMessager(title: "Đăng nhập đã quá hạn", message: "Hãy đăng nhập lại")
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
    
    var user: User?
    @IBAction func btnDangNhap_Clicked(_ sender: Any) {
        if validate() {
            let host = "http://127.0.0.1:8080/"
            loadingSpinner.startAnimating()
            UIApplication.shared.beginIgnoringInteractionEvents()
            let params = [
                "grant_type": "password",
                "username": tfTenTaiKhoan.text!, "password": tfMatKhau.text!]
            
            Alamofire.request(host+"token", method: .post, parameters: params, encoding: URLEncoding.httpBody).responseJSON { response in
                switch(response.result) {
                case .success(_):
                    if response.result.value != nil{
                        self.loadingSpinner.stopAnimating()
                        UIApplication.shared.endIgnoringInteractionEvents()
                        _ = (response.response?.statusCode)!
                        let res = response.result.value! as! NSDictionary
                        let access_token = res.object(forKey: "access_token")
                        let token_type = res.object(forKey: "token_type")
                        if (access_token != nil){
                            UserDefaults.standard.setValue("\(String(describing: token_type!)) \(String(describing: access_token!))", forKey: "access_token")
                            let roles = res["roles"] as? String
                            let rolesArray = self.convertToArray(str: roles!)
                            for role in rolesArray!{
//                                print(role)
                                if role == "shipper"{
                                    self.performSegue(withIdentifier: "gotoShipperViewMain", sender: nil)
                                    return
                                }
                            }
                            self.performSegue(withIdentifier: "gotoUserMainView", sender: nil)
                            
                        }else{
                            self.alertMessager(title: "Không thể đăng nhập", message: "Tài khoản hoặc mật khẩu sai, hãy thử lại")
                        }
                    }else{
                        self.loadingSpinner.stopAnimating()
                        UIApplication.shared.endIgnoringInteractionEvents()
                        self.alertMessager(title: "Không thể đăng nhập", message: "Tài khoản hoặc mật khẩu sai, hãy thử lại")
                    }
                    break
                    
                case .failure(_):
                    self.loadingSpinner.stopAnimating()
                    UIApplication.shared.endIgnoringInteractionEvents()
                    self.alertMessager(title: "Kết nối thất bại", message: "Hãy thử lại")
                    break
                }
            }
        }
    }
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if segue.identifier == "gotoRegister"{
            let des = segue.destination as? RegisterViewController
            des?.delegate = self as RegisterViewControlleDelegete
        }
    }
    @IBAction func btnDangKy_Clicked(_ sender: Any) {
        
    }
    func regiterSucecss(TenTaiKhoan: String) {
        print(TenTaiKhoan)
        self.tfTenTaiKhoan.text = TenTaiKhoan
    }
    
}
