//
//  LoginViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/24/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import Alamofire

class LoginViewController: UIViewController {
    
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
        if tfTenTaiKhoan.text!.count < 6{
            lblError.text = "Tên tài khoản tối thiểu 6 ký tự."
        }
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
    @IBAction func btnDangNhap_Clicked(_ sender: Any) {
        if validate() {
            let host = "http://127.0.0.1:8080/"
//            let params :[String: AnyObject] = [
//                "user_name" : "abc" as AnyObject,
//                "passwork" : "123" as AnyObject,
//            ]
//            let params = ["username": tfTenTaiKhoan.text!, "password": tfMatKhau.text!]
//            Alamofire.request(host+"token", method: .post, parameters: params, encoding: JSONEncoding.default).responseJSON { response in
//                switch(response.result) {
//
//                case .success(_):
//                    if response.result.value != nil{
//                        print(response.result)
//                        let statusCode = (response.response?.statusCode)!
//                        print("...HTTP code: \(statusCode)")
//                    }
//                    break
//
//                case .failure(_):
//                    print(response.result)
//                    break
//
//                }
//            }
            let number = 0
            if number > 0{
                   self.performSegue(withIdentifier: "gotoUserMainView", sender: nil)
            }else{
                self.performSegue(withIdentifier: "gotoShipperViewMain", sender: nil)
            }
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
