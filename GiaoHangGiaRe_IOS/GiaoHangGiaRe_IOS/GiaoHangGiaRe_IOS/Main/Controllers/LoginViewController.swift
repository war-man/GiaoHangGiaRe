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
import NVActivityIndicatorView

class LoginViewController: UIViewController, RegisterViewControlleDelegete, UITextFieldDelegate {
    var activityIndicatorView : NVActivityIndicatorView!
    var overlay : UIView?
    
    @IBOutlet weak var viewContent: UIView!
    @IBOutlet weak var tfTenTaiKhoan: UITextField!
    @IBOutlet weak var tfMatKhau: UITextField!
    @IBOutlet weak var btnDangNhap: UIButton!
    @IBOutlet weak var btnDangKy: UIButton!
    @IBOutlet weak var lblError: UILabel!
    override func viewDidLoad() {
        borderButton()
        super.viewDidLoad()
        viewContent.layer.cornerRadius = 5
        checkLogined()
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    @IBAction func tfTenTaiKhoanChanged(_ sender: Any) {
    }
    
    //Check nhap mat khau
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

    //MASK: Kiem tra da dang nhap chua
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
//MASK: BTN Dang Nhap
    @IBAction func btnDangNhap_Clicked(_ sender: Any) {
        if validate() {
            //Start Loading
            activityIndicatorView.startAnimating()
            view.addSubview(overlay!)

            let params = [
                "grant_type": "password",
                "username": tfTenTaiKhoan.text!, "password": tfMatKhau.text!]
            
            Alamofire.request(root_host+"token", method: .post, parameters: params, encoding: URLEncoding.httpBody).responseJSON { response in
                switch(response.result) {
                case .success(_):
                    if response.result.value != nil{
                        //Stop Loading
                        self.activityIndicatorView.stopAnimating()
                        self.overlay?.removeFromSuperview()

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
                        //Stop Loading
                        self.activityIndicatorView.stopAnimating()
                        self.overlay?.removeFromSuperview()

                        self.alertMessager(title: "Không thể đăng nhập", message: "Tài khoản hoặc mật khẩu sai, hãy thử lại")
                    }
                    break
                    
                case .failure(_):
                    //Stop Loading
                    self.activityIndicatorView.stopAnimating()
                    self.overlay?.removeFromSuperview()
                    
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
 
}

//MARK: Setup UI
extension LoginViewController{
    func borderButton() {
        btnDangKy.layer.cornerRadius = 5
        btnDangNhap.layer.cornerRadius = 5
        
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
    func regiterSucecss(TenTaiKhoan: String) {
        self.tfTenTaiKhoan.text = TenTaiKhoan
    }
    
    func textFieldShouldReturn(_ textField: UITextField) -> Bool {
        print("event raise")
        self.view.endEditing(true)
        return true
    }
}
