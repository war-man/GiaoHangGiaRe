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

class LoginViewController: UIViewController, RegisterViewControlleDelegete, UITextFieldDelegate {
    
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
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
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
        guard  UserDefaults.standard.object(forKey: "access_token") != nil else {
            return
        }
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
    func textView(_ textView: UITextView, shouldChangeTextIn range: NSRange, replacementText text: String) -> Bool {
        if text == "\n" {
            textView.resignFirstResponder()
            return false
        }
        return true
    }
    var user: User?
    @IBAction func btnDangNhap_Clicked(_ sender: Any) {
        if validate() {
            let host = "http://giaohanggiare.gearhostpreview.com/"
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
                                if role == "shipper"{
                                    UserDefaults.standard.setValue("shipper", forKey: "role")
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
        self.tfTenTaiKhoan.text = TenTaiKhoan
    }
    
    // MARK:
    func textFieldShouldReturn(_ textField: UITextField) -> Bool {
        print("event raise")
        self.view.endEditing(true)
        return true
    }
}
