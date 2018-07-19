//
//  LoginViewController.swift
//  GiaoHangGiaRe_IOS
//
//  Created by admin on 7/19/18.
//  Copyright © 2018 admin. All rights reserved.
//

import UIKit
import SwiftValidator

class LoginViewController: UIViewController{

    @IBOutlet weak var tfTaiKhoan: UITextField!
    @IBOutlet weak var tfMatKhau: UITextField!
    
    
    @IBOutlet weak var btnRegister: UIButton!
    @IBOutlet weak var btnlogin: UIButton!
    let validator = Validator()
    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    @IBAction func btnLogin_click(_ sender: Any) {
    }
    
    @IBAction func btnRegister_click(_ sender: Any) {
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
